using Numpuk2.ExaminationReader.Exceptions;
using Numpuk2.ExaminationReader.Models;

namespace Numpuk2.ExaminationReader.Utils
{
    public static class Converter
    {
        public static bool HasMarkers(string marker)
        {
            switch (marker)
            {
                case "DODATNI":
                    return true;
                case "UJEMNY":
                    return false;
            }
            throw new UnknownMarkerException(marker);
        }

        public static Gender SetGender(string gender)
        {
            switch (gender)
            {
                case "K":
                    return Gender.FEMALE;
                case "M":
                    return Gender.MALE;
                default:
                    return Gender.UNKNOWN;
            }
        }

        public static Consistency SetConsistency(string stoolConsistency)
        {
            switch (stoolConsistency)
            {
                case "stała":
                    return Consistency.RIGID;
                case "płynna":
                    return Consistency.LIQUID;
                case "półpłynna":
                    return Consistency.HALF_LIQUID;
                default:
                    return Consistency.UNKNOWN;
            }
        }
    }
}
