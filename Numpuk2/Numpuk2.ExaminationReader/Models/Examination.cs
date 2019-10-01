using Numpuk2.ExaminationReader.ReadModels;
using System;
using System.Collections.Generic;

namespace Numpuk2.ExaminationReader.Models
{
    public class Examination
    {
        public ExaminationType Type { get; internal set; }
        public bool? HasFaecalibactriumPrausnitzii { get; internal set; } = null;
        public bool? HasAkkermansiaMuciniphila { get; internal set; } = null;

        public double? GeneralNumberOfBacteria { get; internal set; } = null;
        public Dictionary<string, double> Results { get; internal set; }

        public string Hash { get; internal set; }
        public Patient Owner { get; internal set; }
        public double? Ph { get; internal set; }
        public Consistency StoolConsistency { get; internal set; }
        public DateTime MaterialRegistrationDate { get; internal set; }
    }
}
