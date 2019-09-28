using Microsoft.EntityFrameworkCore;
using Numpuk2.Domain;

namespace Numpuk2.Data
{
    public class NumpukContext : DbContext
    {
        private readonly string _password;
        private readonly string _port;

        public DbSet<Client> Clients { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Result> Results { get; set; }

        public NumpukContext(string password, string port)
        {
            _password = password;
            _port = port;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseNpgsql($"Server=localhost;Port={_port};Database=numpuk;Username=postgres;Password={_password}");
    }
}
