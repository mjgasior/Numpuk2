using NPOI.SS.UserModel;
using Numpuk2.ExaminationReader.Exceptions;
using System;

namespace Numpuk2.ExaminationReader.ReadModels
{
    public class BaseReader
    {
        private readonly ISheet _sheet;

        public string Id { get; private set; }
        public double? Ph { get; private set; }
        public string StoolConsistency { get; private set; }


        public BaseReader(ISheet sheet)
        {
            _sheet = sheet;

            this.Id = GetStringCell(1, 3);
            this.Ph = SetPh();
            this.StoolConsistency = GetStringCell(3, 7);
        }

        protected string GetStringCell(int row, int cell) => GetCell(row, cell)?.StringCellValue;

        protected ICell GetCell(int row, int cell)
        {
            IRow rowData = _sheet.GetRow(row);
            if (rowData == null)
            {
                return null;
            }
            return rowData.GetCell(cell);
        }

        protected bool TryReadExponentialResult(int row, int cell, out double result)
        {
            ICell baseValueCell = GetCell(row, cell);
            if (baseValueCell == null)
            {
                result = -2;
                return false;
            }

            double exponent = ReadExponent(row, cell + 1);
            if (baseValueCell.CellType == CellType.String)
            {
                string baseValue = DeleteAllWhiteSpace(baseValueCell.StringCellValue);
                string[] split = baseValue.ToLower().Split('x');

                if (split[0] == "o")
                {
                    result = 0;
                }
                else
                {
                    result = double.Parse($"{split[0]}E{exponent}");
                }
                return true;
            }
            else if (baseValueCell.CellType == CellType.Numeric)
            {
                result = double.Parse($"{baseValueCell.NumericCellValue}E{exponent}");
                return true;
            }
            result = -1;
            return false;
        }

        private string DeleteAllWhiteSpace(string stringCellValue)
        {
            return stringCellValue.Replace(" ", string.Empty);
        }

        protected double ReadExponent(int row, int cell)
        {
            ICell exponentCell = GetCell(row, cell);
            if (exponentCell == null)
            {
                throw new ExponentIsNullException(row, cell);
            }

            if (exponentCell.CellType == CellType.Numeric || exponentCell.CellType == CellType.Blank)
            {
                return exponentCell.NumericCellValue;
            }
            else if (exponentCell.CellType == CellType.String)
            {
                if (String.IsNullOrWhiteSpace(exponentCell.StringCellValue))
                {
                    return 0;
                }
                return double.Parse(exponentCell.StringCellValue);
            }
            throw new Exception("Exponent cell value set wrong!");
        }

        private double? SetPh()
        {
            ICell cell = GetCell(2, 7);
            if (cell.CellType == CellType.Numeric)
            {
                return cell.NumericCellValue;
            }
            else if (cell.CellType == CellType.String)
            {
                if (double.TryParse(cell.StringCellValue, out double result))
                {
                    return result;
                }
                Console.WriteLine($"Ph field message: {cell.StringCellValue}");
                return null;
            }
            throw new Exception("Ph field invalid format!");
        }
    }
}
