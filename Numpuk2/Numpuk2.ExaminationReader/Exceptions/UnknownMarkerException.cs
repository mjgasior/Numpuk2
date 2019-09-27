using System;

namespace Numpuk2.ExaminationReader.Exceptions
{
    public class UnknownMarkerException : Exception
    {
        public UnknownMarkerException(string marker)
            : base($"Unknown marker of type {marker}!")
        {

        }
    }
}
