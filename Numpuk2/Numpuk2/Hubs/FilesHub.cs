using Microsoft.AspNetCore.SignalR;
using Numpuk2.Utils;
using System.Threading.Tasks;

namespace Numpuk2.Hubs
{
    public class FilesHub : Hub
    {
        public async Task SendDirectory(UploadModel model)
        {
            await Clients.All.SendAsync("FilesAccepted", "Pliki w trakcie procesowania...");
            string[] filePaths = Directory.GetAllFileNames(model.Directory);

            var parser = new Parser(filePaths, model.Password, "5432", new Logger());
            await parser.Run(Clients.All);
            await Clients.All.SendAsync("AllFilesDone");
        }
    }

    public class UploadModel
    {
        public string Directory { get; set; }
        public string Password { get; set; }
    }
}
