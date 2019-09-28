using Numpuk2.Data;
using Numpuk2.ExaminationReader.Models;
using Numpuk2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Numpuk2.Utils
{
    public class Parser
    {
        private readonly string[] _filePaths;
        private readonly string _password;
        private readonly string _port;
        private readonly Logger _logger;

        public Parser(string[] filePaths, string password, string port, Logger logger)
        {
            _filePaths = filePaths;
            _password = password;
            _port = port;
            _logger = logger;
        }

        internal async Task Run(IClientProxy websocketToAll)
        {
            var reader = new ExaminationReader.ExaminationReader();
            var examinationService = new ExaminationService(_password, _port);

            int TOTAL_COUNT = _filePaths.Length;
            int count = 0;
            foreach (string path in _filePaths)
            {
                var result = new Progress
                {
                    FileName = Path.GetFileName(path),
                    FileNumber = ++count,
                    TotalCount = TOTAL_COUNT,
                    Error = null
                };

                string fileName = Path.GetFileName(path);
                await websocketToAll.SendAsync("ReadingFile", fileName);

                try
                {
                    Examination examination = reader.Read(path);
                    ValidateAndFixResults(examination.Results, fileName);
                    Domain.Examination dbExamination = Converter.PrepareEntity(examination);
                    examinationService.AddExamination(dbExamination);
                }
                catch (Exception e)
                {
                    _logger.FileError(fileName, e);
                    result.FileName += " UWAGA BŁĄD";
                    result.Error = "Napotkano problem!";
                }
                await websocketToAll.SendAsync("FileProcessed", result);
            }
        }

        private void ValidateAndFixResults(Dictionary<string, double> results, string fileName)
        {
            var elementsToFix = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> result in results)
            {
                if (!TestTypes.IsValidName(result.Key))
                {
                    elementsToFix.Add(result.Key, result.Value);
                }
            }

            foreach (KeyValuePair<string, double> brokenResult in elementsToFix)
            {
                string fixedName = TestTypes.TryFix(brokenResult.Key);
                results.Remove(brokenResult.Key);

                if (TestTypes.IsValidName(fixedName))
                {
                    results.Add(fixedName, brokenResult.Value);
                }
                else
                {
                    _logger.InvalidTest(fileName, brokenResult.Key);
                }
            }
        }
    }
}
