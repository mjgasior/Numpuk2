using NPOI.SS.UserModel;
using Numpuk2.ExaminationReader.Exceptions;

namespace Numpuk2.ExaminationReader.ReadModels
{
    public class ExaminationPatient
    {
        private ISheet _sheet;

        public string Name { get; private set; }
        public string Birthday { get; private set; }
        public string Gender { get; private set; }
        public string Pesel { get; private set; }
        public string Address { get; private set; }

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
            this.Birthday = GetDate();            
        }

        private string GetDate()
        {
            var cell = GetCell(4, 3);
            if (cell.CellType == CellType.String)
            {
                return cell.StringCellValue;
            }
            else
            {
                return DateUtil.IsCellDateFormatted(cell)
                        ? cell.DateCellValue.ToString()
                        : cell.NumericCellValue.ToString();
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
