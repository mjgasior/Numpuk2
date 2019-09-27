using NPOI.SS.UserModel;

namespace Numpuk2.ExaminationReader.ReadModels
{
    public enum ExaminationType
    {
        UNKNOWN,
        CANDIDIASIS,
        REGULAR,
        EXTENDED
    }

    public static class ExaminationTypeExtension
    {
        public static ExaminationType GetExaminationType(this ISheet sheet)
        {
            if (IsExtended(sheet))
            {
                return ExaminationType.EXTENDED;
            }

            if (IsRegular(sheet))
            {
                return ExaminationType.REGULAR;
            }

            if (IsCandidiasis(sheet))
            {
                return ExaminationType.CANDIDIASIS;
            }

            return ExaminationType.UNKNOWN;
        }

        private static bool IsExtended(ISheet sheet)
        {
            ICell hasAkkermansiaCell = sheet.GetRow(13).GetCell(15);
            ICell hasFaecalibactriumCell = sheet.GetRow(16).GetCell(15);

            if (hasAkkermansiaCell != null && hasFaecalibactriumCell != null)
            {
                return !string.IsNullOrWhiteSpace(hasAkkermansiaCell.StringCellValue) 
                    && !string.IsNullOrWhiteSpace(hasFaecalibactriumCell.StringCellValue);
            }
            return false;
        }

        private static bool IsCandidiasis(ISheet sheet)
        {
            string testDescriptionField = sheet.GetRow(7).GetCell(5).StringCellValue;
            ICell emptySpaceCell = sheet.GetRow(23).GetCell(6);
            return !string.IsNullOrWhiteSpace(testDescriptionField) && emptySpaceCell == null;
        }

        private static bool IsRegular(ISheet sheet)
        {
            ICell testDescriptionCell = sheet.GetRow(23).GetCell(6);
            if (testDescriptionCell != null)
            {
                string testDescriptionField = testDescriptionCell.StringCellValue;
                return !string.IsNullOrWhiteSpace(testDescriptionField);
            }
            return false;
        }
    }
}