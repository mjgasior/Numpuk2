namespace Numpuk2.Queries.Models
{
    public class ResultResponse
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public ResultResponse(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
