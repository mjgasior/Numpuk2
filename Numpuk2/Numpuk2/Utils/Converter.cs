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
                AgeOfClient = CalculateAge(readerExamination.Owner.MaterialRegistrationDate, readerExamination.Owner.Birthday),
                Type = (ExaminationType)readerExamination.Type,
                Id = readerExamination.Hash,
                Consistency = (Consistency)readerExamination.StoolConsistency,
                PhValue = readerExamination.Ph,
                Results = readerExamination.Results.Select(element => new Result(element)).ToList(),
                Client = client,
                HasAkkermansiaMuciniphila = readerExamination.HasAkkermansiaMuciniphila,
                HasFaecalibactriumPrausnitzii = readerExamination.HasFaecalibactriumPrausnitzii,
                GeneralNumberOfBacteria = readerExamination.GeneralNumberOfBacteria,
                MaterialRegistrationDate = readerExamination.Owner.MaterialRegistrationDate
            };
        }

        private static double CalculateAge(DateTime materialRegistrationDate, DateTime birthdate)
        {
            int age = materialRegistrationDate.Year - birthdate.Year;
            if (birthdate.Date > materialRegistrationDate.AddYears(-age))
            {
                age--;
            }

            double days = materialRegistrationDate.DayOfYear - birthdate.DayOfYear;
            double daysAsFraction;
            const double DAYS_IN_A_YEAR_IGNORING_LEAP_YEARS = 365;
            if (days < 0)
            {
                daysAsFraction = -days / DAYS_IN_A_YEAR_IGNORING_LEAP_YEARS;
            } 
            else
            {
                daysAsFraction = materialRegistrationDate.DayOfYear / DAYS_IN_A_YEAR_IGNORING_LEAP_YEARS;
            }

            return (double)age + daysAsFraction;
        }
    }
}
