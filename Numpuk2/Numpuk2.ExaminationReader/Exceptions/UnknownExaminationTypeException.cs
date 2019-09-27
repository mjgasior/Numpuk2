using System;

namespace Numpuk2.ExaminationReader.Exceptions
{
    public class UnknownExaminationTypeException : Exception
    {
        public UnknownExaminationTypeException(string fileName) 
            : base($"File {fileName} is of unknown type")
        {

        }
    }
}
