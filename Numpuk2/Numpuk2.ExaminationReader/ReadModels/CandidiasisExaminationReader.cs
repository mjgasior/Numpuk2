using NPOI.SS.UserModel;
using Numpuk2.ExaminationReader.ReadModels;

namespace Numpuk2.ExaminationReader.Models
{
    public class CandidiasisExamination : BaseReader
    {
        public double CandidaAlbicans { get; set; }
        public double CandidaNonAlbicans { get; set; }
        public double MoldFungus { get; set; }

        public CandidiasisExamination(ISheet sheet) : base(sheet)
        {

        }
    }
}
