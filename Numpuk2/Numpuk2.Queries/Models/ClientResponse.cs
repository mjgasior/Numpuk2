using Numpuk2.Domain.Parameters;
using System;

namespace Numpuk2.Queries.Models
{
    public class ClientResponse
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
