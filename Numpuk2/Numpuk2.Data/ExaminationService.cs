using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Numpuk2.Domain;

namespace Numpuk2.Data
{
    public class ExaminationService
    {
        private readonly NumpukContext _context;

        public ExaminationService(string password, string port)
        {
            _context = new NumpukContext(password, port);
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Migrating data base...");
                _context.Database.Migrate();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Migration successful!");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddExamination(Examination examination)
        {
            Examination dbExamination = _context.Examinations.Find(examination.Id);
            Client dbClient = _context.Clients.Find(examination.ClientId);

            if (dbExamination == null)
            {
                if (dbClient != null)
                {
                    examination.Client = null;
                }

                _context.Examinations.Add(examination);
                _context.SaveChanges();
            }
        }
    }
}
