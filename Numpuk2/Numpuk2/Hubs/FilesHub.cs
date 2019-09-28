using Microsoft.AspNetCore.SignalR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Numpuk2.Hubs
{
    public class FilesHub : Hub
    {
        public async Task SendFiles(File[] filePaths)
        {
            await Clients.All.SendAsync("FilesAccepted", "Pliki w trakcie procesowania...");
            var reader = new ExaminationReader.ExaminationReader();

            int TOTAL_COUNT = filePaths.Length;
            int count = 0;
            foreach (File file in filePaths)
            {
                var result = new Progress
                {
                    FileName = Path.GetFileName(file.Path),
                    FileNumber = ++count,
                    TotalCount = TOTAL_COUNT,
                    Error = null
                };

                try
                {
                    var examination = reader.Read(file.Path);
                }
                catch (System.Exception)
                {
                    result.FileName += " UWAGA BŁĄD";
                    result.Error = "Napotkano problem!";   
                }
                await Clients.All.SendAsync("FileProcessed", result);
                Thread.Sleep(1000);
            }
            await Clients.All.SendAsync("AllFilesDone");
        }
    }

    public class File
    {
        public string Path { get; set; }
    }

    public class Progress
    {
        public int FileNumber { get; set; }
        public int TotalCount { get; set; }
        public string FileName { get; set; }
        public string Error { get; set; }
    }
}
