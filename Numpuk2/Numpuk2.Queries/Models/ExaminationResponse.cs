using Numpuk2.Domain.Parameters;
using System.Collections.Generic;

namespace Numpuk2.Queries.Models
{
    public class ExaminationResponse
    {
        public ExaminationType Type { get; set; }
        public string Id { get; set; }
        public ClientResponse Client { get; set; }
        public List<ResultResponse> Results { get; set; }
        public double? PhValue { get; set; }
        public Consistency Consistency { get; set; }
        public bool? HasAkkermansiaMuciniphila { get; set; }
        public bool? HasFaecalibactriumPrausnitzii { get; set; }
        public double? GeneralNumberOfBacteria { get; set; }
        public double AgeOfClient { get; internal set; }
    }
}
