using System;

namespace Numpuk2.ExaminationReader.Models
{
    public class Patient
    {
        public string Address { get; internal set; }
        public string Id { get; internal set; }
        public Gender Gender { get; internal set; }
        public DateTime Birthday { get; internal set; }
        public DateTime MaterialRegistrationDate { get; internal set; }
    }
}
