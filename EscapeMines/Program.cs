using System;
using System.IO;

namespace EscapeMines
{
    public class Program
    {
        const string fileName = "game.txt";
        const string filePath = "./";

        static void Main()
        {
            new Program().Run();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        public void Run()
        {
            var fileStream = new FileStream(filePath + fileName, FileMode.Open);
            var fileService = new FileService(fileStream);
            fileService.Read();
        }
    }
}
