using Microsoft.EntityFrameworkCore;
using Numpuk2.Data;
using Numpuk2.Domain;
using Numpuk2.Domain.Parameters;
using Numpuk2.Queries.Pagination;
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

        public PagedResult<Examination> GetAllExaminations(int page, int count, int? gender, double[] ph, Consistency[] consistency)
        {
            double minPh = ph.Length < 2 ? 0 : ph[0];
            double maxPh = ph.Length < 2 ? 14 : ph[1];

            IQueryable<Examination> examinationsSet = _context.Examinations.Where(x => x.PhValue != null && x.PhValue >= minPh && x.PhValue <= maxPh);

            /*if (gender != null)
            {
                examinationsSet = examinationsSet.Where(x => x.Client.Gender == (Gender)gender);
            }

            if (consistency.Length > 0)
            {
                examinationsSet = examinationsSet.Where(x => consistency.Any(y => y == (Consistency)x.Consistency));
            }*/

            var examinations = examinationsSet.Include(x => x.Client)
                .Include(x => x.Results)
                .GetPaged(page, count);

            var newList = new List<Examination>();

            foreach (Examination examination in examinations.Results)
            {
                newList.Add(new Examination
                {
                    Client = new Client
                    {
                        Address = examination.Client.Address,
                        Birthday = examination.Client.Birthday,
                        Gender = examination.Client.Gender,
                        Id = examination.Client.Id
                    },
                    Consistency = examination.Consistency,
                    GeneralNumberOfBacteria = examination.GeneralNumberOfBacteria,
                    HasAkkermansiaMuciniphila = examination.HasAkkermansiaMuciniphila,
                    HasFaecalibactriumPrausnitzii = examination.HasFaecalibactriumPrausnitzii,
                    Id = examination.Id,
                    PhValue = examination.PhValue,
                    Results = examination.Results.Select(x => new Result(x.Name, x.Value)).ToList(),
                    Type = examination.Type
                });
            }

            var result = new PagedResult<Examination>
            {
                CurrentPage = examinations.CurrentPage,
                PageCount = examinations.PageCount,
                PageSize = examinations.PageSize,
                RowCount = examinations.RowCount,
                Results = newList
            };

            return result;
        }
    }
}
