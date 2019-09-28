using Numpuk2.Domain.Parameters;
using System.Collections.Generic;

namespace Numpuk2.Domain
{
    public class Examination
    {
        public ExaminationType Type { get; set; }
        public string Id { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public List<Result> Results { get; set; }
        public double? PhValue { get; set; }
        public Consistency Consistency { get; set; }
        public bool? HasAkkermansiaMuciniphila { get; set; }
        public bool? HasFaecalibactriumPrausnitzii { get; set; }
        public double? GeneralNumberOfBacteria { get; set; }
    }
}
