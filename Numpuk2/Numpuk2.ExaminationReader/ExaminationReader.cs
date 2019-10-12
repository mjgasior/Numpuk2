using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Numpuk2.ExaminationReader.Exceptions;
using Numpuk2.ExaminationReader.Models;
using Numpuk2.ExaminationReader.ReadModels;
using Numpuk2.ExaminationReader.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Numpuk2.ExaminationReader
{
    public class ExaminationReader
    {
        public Examination Read(string filePath)
        {
            XSSFWorkbook xssfBook;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                xssfBook = new XSSFWorkbook(file);
            }

            ISheet sheet = xssfBook.GetSheet(xssfBook.GetSheetName(0));

            Patient client = ReadClient(sheet);

            ExaminationType type = sheet.GetExaminationType();
            if (type == ExaminationType.UNKNOWN)
            {
                throw new UnknownExaminationTypeException(Path.GetFileName(filePath));
            }
            else if (type == ExaminationType.CANDIDIASIS)
            {
                return CreateCandidiasisExamination(sheet, type, client);
            }
            else
            {
                return CreateExamination(sheet, type, client);
            }
        }

        private Examination CreateExamination(ISheet sheet, ExaminationType type, Patient client)
        {
            var reader = new ExtendedExaminationReader(sheet);
            var examination = new Examination
            {
                Type = type,
                Hash = Hash.Generate(reader.Id + client.Id),
                Owner = client,
                Ph = reader.Ph,
                StoolConsistency = Converter.SetConsistency(reader.StoolConsistency),
                GeneralNumberOfBacteria = reader.GeneralNumberOfBacteria,
                Results = reader.Results
            };

            if (type == ExaminationType.EXTENDED)
            {
                return SetExtendedValues(reader, examination);
            }
            return examination;
        }

        private Examination CreateCandidiasisExamination(ISheet sheet, ExaminationType type, Patient client)
        {
            var examination = new CandidiasisExamination(sheet);
            var candidiasisExamination = new Examination
            {
                Type = type,
                Hash = Hash.Generate(examination.Id + client.Id),
                Owner = client,
                Ph = examination.Ph,
                StoolConsistency = Converter.SetConsistency(examination.StoolConsistency),
                Results = SetCandidiasisResults(examination)
            };

            return candidiasisExamination;
        }

        private Examination SetExtendedValues(ExtendedExaminationReader reader, Examination extendedExamination)
        {
            extendedExamination.HasAkkermansiaMuciniphila = Converter.HasMarkers(reader.HasAkkermansiaMuciniphila);
            extendedExamination.HasFaecalibactriumPrausnitzii = Converter.HasMarkers(reader.HasFaecalibactriumPrausnitzii);
            return extendedExamination;
        }

        private Dictionary<string, double> SetCandidiasisResults(CandidiasisExamination examination)
        {
            return new Dictionary<string, double>
            {
                ["Candida albicans"] = examination.CandidaAlbicans,
                ["Candida non-albicans"] = examination.CandidaNonAlbicans,
                ["Grzyby pleśniowe"] = examination.MoldFungus
            };
        }

        private Patient ReadClient(ISheet sheet)
        {
            var patient = new ExaminationPatient(sheet);

            if (!DateTime.TryParse(patient.Birthday, out DateTime birthday))
            {
                var pesel = new Pesel(patient.Pesel);
                birthday = pesel.GetBirthday();
            }

            var materialRegistrationDate = DateTime.Parse(patient.MaterialRegistrationDate);
            if (materialRegistrationDate == DateTime.MinValue)
            {
                throw new ArgumentException($"Material registration date is empty for {patient.Name}!");
            }

            var client = new Patient
            {
                Birthday = birthday,
                Gender = Converter.SetGender(patient.Gender),
                // Id = Hash.Generate(patient.Pesel),
                Id = patient.Name,
                Address = patient.Address,
                MaterialRegistrationDate = materialRegistrationDate
            };
            return client;
        }
    }
}
