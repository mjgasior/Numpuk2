using Numpuk2.Domain.Parameters;
using System;
using System.Collections.Generic;

namespace Numpuk2.Domain
{
    public class Client
    {
        public string Id { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public List<Examination> Examinations { get; set; }

        public Client()
        {

        }
    }
}
