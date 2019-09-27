using System;

namespace Numpuk2.ExaminationReader.Utils
{
    public class Pesel
    {
        private readonly string _personalIdString;
        private readonly int[] _peselNumbers;

        public bool IsAWoman { get; private set; }

        public Pesel(string personalIdString)
        {
            _personalIdString = personalIdString;
            _peselNumbers = PeselParser.GetPeselNumbers(personalIdString);
            IsAWoman = IsEven(_peselNumbers[9]);
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public int GetAge()
        {
            DateTime birthday = GetBirthday();
            DateTime today = DateTime.Today;
            int age = today.Year - GetBirthday().Year;

            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public DateTime GetBirthday()
        {
            return PeselParser.GetBirthday(_peselNumbers);
        }

        public static bool IsValid(string pesel)
        {
            return PeselParser.IsValid(pesel);
        }

        public override string ToString()
        {
            return _personalIdString;
        }
    }

}
