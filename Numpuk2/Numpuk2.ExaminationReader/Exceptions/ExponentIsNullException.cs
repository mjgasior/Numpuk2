using System;

namespace Numpuk2.ExaminationReader.Exceptions
{
    public class ExponentIsNullException : Exception
    {
        public ExponentIsNullException(int row, int cell)
            : base($"Exponent for row {row} and cell {cell} is null!")
        {

        }
    }
}
