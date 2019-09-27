using System;

namespace Numpuk2.ExaminationReader.Exceptions
{
    public class InvalidPeselException : Exception
    {
        public InvalidPeselException(string wrongId)
            : base($"The {wrongId} is not a valid PESEL!")
        {

        }
    }
}
