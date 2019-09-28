using System;
using System.Collections.Generic;

namespace Numpuk2.Domain
{
    public class Result
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string ExaminationId { get; set; }

        public Result()
        {

        }

        public Result(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Result(KeyValuePair<string, double> element)
        {
            this.Name = element.Key;
            this.Value = element.Value;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
