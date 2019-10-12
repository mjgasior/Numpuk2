using Microsoft.EntityFrameworkCore;
using Numpuk2.Data;
using Numpuk2.Domain;
using Numpuk2.Domain.Parameters;
using Numpuk2.Queries.Models;
using Numpuk2.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Numpuk2.Queries
{
    public class ExaminationService
    {
        private readonly NumpukContext _context;

        public ExaminationService(string password, string port)
        {
            _context = new NumpukContext(password, port);
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Migrating data base...");
                _context.Database.Migrate();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Migration successful!");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PagedResult<ExaminationResponse> GetAllExaminations(int page, int count, Gender? gender, double[] age, double[] ph, Consistency[] consistency, 
            ExaminationStatus[] akkermansiaMuciniphila, ExaminationStatus[] faecalibactriumPrausnitzii)
        {
            IQueryable<Examination> examinationsSet = _context.Examinations;

            double minPh = ph.Length < 2 ? 0 : ph[0];
            double maxPh = ph.Length < 2 ? 14 : ph[1];

            if (minPh > 0 || maxPh < 14)
            {
                examinationsSet.Where(x => x.PhValue != null && x.PhValue >= minPh && x.PhValue <= maxPh);
            }

            double minAge = age.Length < 2 ? 0 : age[0];
            double maxAge = age.Length < 2 ? 140 : age[1];

            if (minAge > 0 || maxAge < 140)
            {
                examinationsSet.Where(x => x.ClientAge >= minAge && x.ClientAge <= maxAge);
            }

            if (gender != null)
            {
                examinationsSet = examinationsSet.Where(x => x.Client.Gender == gender);
            }

            List<int> consistencyNumbers = consistency.Select(item => (int)item).ToList();
            if (consistencyNumbers.Count > 0 && consistencyNumbers.Count < 4)
            {
                examinationsSet = examinationsSet.Where(x => consistencyNumbers.Any(y => y == (int)x.Consistency));
            }

            List<bool?> akkermansiaMuciniphilaNumbers = akkermansiaMuciniphila.Select(item => SetItem(item)).ToList();
            if (akkermansiaMuciniphilaNumbers.Count > 0 && akkermansiaMuciniphilaNumbers.Count < 3)
            {
                examinationsSet = examinationsSet.Where(x => akkermansiaMuciniphilaNumbers.Any(y => y == x.HasAkkermansiaMuciniphila));
            }

            List<bool?> faecalibactriumPrausnitziiNumbers = faecalibactriumPrausnitzii.Select(item => SetItem(item)).ToList();
            if (faecalibactriumPrausnitziiNumbers.Count > 0 && faecalibactriumPrausnitziiNumbers.Count < 3)
            {
                examinationsSet = examinationsSet.Where(x => faecalibactriumPrausnitziiNumbers.Any(y => y == x.HasFaecalibactriumPrausnitzii));
            }

            var examinations = examinationsSet.Include(x => x.Client)
                .Include(x => x.Results)
                .GetPaged(page, count);

            var newList = new List<ExaminationResponse>();

            foreach (Examination examination in examinations.Results)
            {
                newList.Add(new ExaminationResponse
                {
                    Client = new ClientResponse
                    {
                        Age = examination.ClientAge,
                        Gender = examination.Client.Gender,
                        Id = examination.Client.Id
                    },
                    Consistency = examination.Consistency,
                    GeneralNumberOfBacteria = examination.GeneralNumberOfBacteria,
                    HasAkkermansiaMuciniphila = examination.HasAkkermansiaMuciniphila,
                    HasFaecalibactriumPrausnitzii = examination.HasFaecalibactriumPrausnitzii,
                    Id = examination.Id,
                    PhValue = examination.PhValue,
                    Results = examination.Results.Select(x => new ResultResponse(x.Name, x.Value)).ToList(),
                    Type = examination.Type,
                    ClientAge = examination.ClientAge
                });
            }

            var result = new PagedResult<ExaminationResponse>
            {
                CurrentPage = examinations.CurrentPage,
                PageCount = examinations.PageCount,
                PageSize = examinations.PageSize,
                RowCount = examinations.RowCount,
                Results = newList
            };

            return result;
        }

        private bool? SetItem(ExaminationStatus item)
        {
            switch (item)
            {
                case ExaminationStatus.POSITIVE:
                    return true;
                case ExaminationStatus.NEGATIVE:
                    return false;
                case ExaminationStatus.NOT_PERFORMED:
                default:
                    return null;
            }
        }
    }
}
