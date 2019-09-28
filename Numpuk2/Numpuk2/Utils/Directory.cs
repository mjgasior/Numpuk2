using System;
using System.Linq;

namespace Numpuk2.Utils
{
    public static class Directory
    {
        public static string[] GetAllFileNames(string directory)
        {
            string[] xlsxFiles = System.IO.Directory.GetFiles(directory, "*.xlsx");

            WriteSuccessMessage(xlsxFiles.Count());

            string[] nonXlsxFiles = System.IO.Directory.GetFiles(directory).Where(x => !x.EndsWith(".xlsx")).ToArray();
            if (nonXlsxFiles.Count() > 0)
            {
                ShowFailedFiles(nonXlsxFiles);
            }
            return xlsxFiles;
        }

        private static void WriteSuccessMessage(int count)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Found {count} .xlsx format files.");
            Console.ResetColor();
        }

        private static void ShowFailedFiles(string[] nonXlsxFiles)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Found {nonXlsxFiles.Count()} not-xlsx format files:");
            foreach (var item in nonXlsxFiles)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }
    } 
}
