using Numpuk2.Domain.Parameters;
using System;

namespace Numpuk2.Queries.Models
{
    public class ClientResponse
    {
        public string Id { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
    }
}
