using Numpuk2.Domain;
using Numpuk2.Domain.Parameters;
using System.Linq;

namespace Numpuk2.Utils
{
    public static class Converter
    {
        public static Examination PrepareEntity(Numpuk2.ExaminationReader.Models.Examination readerExamination)
        {
            Client client = new Client
            {
                Id = readerExamination.Owner.Id,
                Address = readerExamination.Owner.Address,
                Birthday = readerExamination.Owner.Birthday,
                Gender = (Gender)readerExamination.Owner.Gender
            };

            return new Examination
            {
                Type = (ExaminationType)readerExamination.Type,
                Id = readerExamination.Hash,
                Consistency = (Consistency)readerExamination.StoolConsistency,
                PhValue = readerExamination.Ph,
                Results = readerExamination.Results.Select(element => new Result(element)).ToList(),
                Client = client,
                HasAkkermansiaMuciniphila = readerExamination.HasAkkermansiaMuciniphila,
                HasFaecalibactriumPrausnitzii = readerExamination.HasFaecalibactriumPrausnitzii,
                GeneralNumberOfBacteria = readerExamination.GeneralNumberOfBacteria
            };
        }
    }
}
