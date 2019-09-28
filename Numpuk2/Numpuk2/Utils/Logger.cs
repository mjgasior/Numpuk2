using System;
using System.IO;

namespace Numpuk2.Utils
{
    public class Logger
    {
        private readonly StreamWriter _logs;

        public Logger()
        {
            _logs = File.CreateText($"logs_{DateTime.Now.Ticks}.txt");
        }

        public void InvalidTest(string fileName, string testName)
        {
            Stamp();
            _logs.WriteLine($"ERROR {fileName}: invalid test ({testName}) removed from results!");
        }

        public void FileError(string fileName, Exception e)
        {
            Stamp();
            _logs.WriteLine($"ERROR {fileName}");
            _logs.WriteLine(e.ToString());
        }

        public void Error(Exception e)
        {
            Stamp();
            _logs.WriteLine($"UNHANDLED APP ERROR");
            _logs.WriteLine(e.ToString());
        }

        private void Stamp()
        {
            _logs.WriteLine();
            _logs.WriteLine(DateTime.Now);
        }

        public void Close()
        {
            _logs.Close();
        }
    }
}
