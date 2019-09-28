using Microsoft.Extensions.Configuration;

namespace Numpuk2.Utils
{
    public class NumpukConfiguration
    {
        private readonly IConfigurationRoot _config;

        public string DatabasePassword { get { return _config["password"]; } }
        public string DatabasePort { get { return _config["port"]; } }


        public NumpukConfiguration()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        }
    }
}
