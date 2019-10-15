using Numpuk2.Domain;
using Numpuk2.Domain.Parameters;
using System;
using System.Linq;

namespace Numpuk2.Utils
{
    public static class Converter
    {
        public static Examination PrepareEntity(ExaminationReader.Models.Examination readerExamination)
        {
            Client client = new Client
            {
                Id = readerExamination.Owner.Id,
                Birthday = readerExamination.Owner.Birthday,
                Gender = (Gender)readerExamination.Owner.Gender
            };

            return new Examination
            {
                ClientAge = GetClientAge(readerExamination.Owner),
                Type = (ExaminationType)readerExamination.Type,
                Id = readerExamination.Hash,
                Consistency = (Consistency)readerExamination.StoolConsistency,
                PhValue = readerExamination.Ph,
                Results = readerExamination.Results.Select(element => new Result(element)).ToList(),
                Client = client,
                ClientId = client.Id,
                HasAkkermansiaMuciniphila = readerExamination.HasAkkermansiaMuciniphila,
                HasFaecalibactriumPrausnitzii = readerExamination.HasFaecalibactriumPrausnitzii,
                GeneralNumberOfBacteria = readerExamination.GeneralNumberOfBacteria,
                MaterialRegistrationDate = readerExamination.Owner.MaterialRegistrationDate
            };
        }

        private static double GetClientAge(ExaminationReader.Models.Patient patient)
        {
            const double DAYS_IN_A_YEAR = 365.0d;
            return (patient.MaterialRegistrationDate - patient.Birthday).TotalDays / DAYS_IN_A_YEAR;
        }
    }
}
