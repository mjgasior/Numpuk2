using System;

namespace Numpuk2.ExaminationReader.Exceptions
{
    public class ResultsException : Exception
    {
        public ResultsException(int element, Exception innerException) 
            : base($"Exception occured at element {element} during results processing!", innerException)
        {

        }
    }
}
