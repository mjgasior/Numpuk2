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
        }

        public PagedResult<ExaminationResponse> GetAllExaminations(int page, int count, Gender? gender, double[] ph, Consistency[] consistency, 
            ExaminationStatus[] akkermansiaMuciniphila, ExaminationStatus[] faecalibactriumPrausnitzii)
        {
            double minPh = ph.Length < 2 ? 0 : ph[0];
            double maxPh = ph.Length < 2 ? 14 : ph[1];

            IQueryable<Examination> examinationsSet = _context.Examinations.Where(x => x.PhValue != null && x.PhValue >= minPh && x.PhValue <= maxPh);

            if (gender != null)
            {
                examinationsSet = examinationsSet.Where(x => x.Client.Gender == gender);
            }

            List<int> consistencyNumbers = consistency.Select(item => (int)item).ToList();
            if (consistencyNumbers.Count > 0 && consistencyNumbers.Count < 4)
            {
                examinationsSet = examinationsSet.Where(x => consistencyNumbers.Any(y => y == (int)x.Consistency));
            }

            /*List<int> akkermansiaMuciniphilaNumbers = akkermansiaMuciniphila.Select(item => (int)item).ToList();
            if (akkermansiaMuciniphilaNumbers.Count > 0 && akkermansiaMuciniphilaNumbers.Count < 3)
            {
                examinationsSet = examinationsSet.Where(x => akkermansiaMuciniphilaNumbers.Any(y => y == (int)x.));
            }*/

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
                        Age = GetClientAge(examination),
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
                    Type = examination.Type
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

        private int GetClientAge(Examination examination)
        {
            return (int)((examination.MaterialRegistrationDate - examination.Client.Birthday).TotalDays / 365);
        }
    }
}
