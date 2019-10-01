using NPOI.SS.UserModel;
using Numpuk2.ExaminationReader.Exceptions;

namespace Numpuk2.ExaminationReader.ReadModels
{
    public class ExaminationPatient
    {
        private ISheet _sheet;

        public string Name { get;  }
        public string Birthday { get;  }
        public string Gender { get; }
        public string Pesel { get; }
        public string Address { get; }

        public string MaterialFetchDate { get; }
        public string MaterialRegistrationDate { get; }
        public string TestEndDate { get; }

        public ExaminationPatient(ISheet sheet)
        {
            _sheet = sheet;
            this.Name = GetStringCell(3, 3);

            this.Gender = GetStringCell(5, 3);
            this.Pesel = GetStringCell(6, 3);
            if (!Utils.Pesel.IsValid(this.Pesel))
            {
                throw new InvalidPeselException(this.Pesel);
            }

            this.Address = GetStringCell(7, 3);
            this.Birthday = GetDate(4, 3);

            this.MaterialFetchDate = GetDate(9, 3);
            this.MaterialRegistrationDate = GetDate(10, 3);
            this.TestEndDate = GetDate(11, 3);
        }

        private string GetDate(int row, int cell)
        {
            var cellData = GetCell(row, cell);
            if (cellData.CellType == CellType.String)
            {
                return cellData.StringCellValue;
            }
            else
            {
                return DateUtil.IsCellDateFormatted(cellData)
                        ? cellData.DateCellValue.ToString()
                        : cellData.NumericCellValue.ToString();
            }
        }

        private string GetStringCell(int row, int cell) => GetCell(row, cell).StringCellValue;

        private ICell GetCell(int row, int cell)
        {
            IRow rowData = _sheet.GetRow(row);
            if (rowData == null)
            {
                return null;
            }
            return rowData.GetCell(cell);
        }
    }
}
