using NPOI.SS.UserModel;
using Numpuk2.ExaminationReader.Exceptions;
using System;
using System.Collections.Generic;

namespace Numpuk2.ExaminationReader.ReadModels
{
    public class ExtendedExaminationReader : BaseReader
    {
        public string HasAkkermansiaMuciniphila { get; private set; }
        public string HasFaecalibactriumPrausnitzii { get; private set; }

        public double GeneralNumberOfBacteria { get; private set; }
        public Dictionary<string, double> Results { get; private set; }

        public ExtendedExaminationReader(ISheet sheet) : base(sheet)
        {
            this.Results = SetResults();
            this.GeneralNumberOfBacteria = SetBacteriaCount();

            this.HasAkkermansiaMuciniphila = GetStringCell(13, 15);
            this.HasFaecalibactriumPrausnitzii = GetStringCell(16, 15);
        }

        private double SetBacteriaCount()
        {
            if (TryReadExponentialResult(5, 7, out double result))
            {
                return result;
            }
            else throw new Exception("General number of bacteria not set properly!");
        }

        private Dictionary<string, double> SetResults()
        {
            var dictionary = new Dictionary<string, double>();
            int o = 0;
            int i = 0;
            for (; i < 36; i++)
            {
                try
                {
                    ICell cell = GetCell(i + 23, 6);
                    if (cell == null || cell.CellType == CellType.Blank)
                    {
                        o++;
                        continue;
                    }

                    string name = cell.StringCellValue;
                    if (TryReadExponentialResult(i + 23, 7, out double result))
                    {
                        dictionary.Add(name, result);
                    }
                }
                catch (Exception e)
                {
                    throw new ResultsException(i, e);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{i - o} is max");
            Console.ResetColor();

            return dictionary;
        }
    }
}
