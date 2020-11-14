using System;
using System.IO;
using Xunit;

namespace EscapeMines.Tests
{
    public class FileServiceTest
    {
        private byte[] CreateStreamBytes() 
        {
            string firstLine = "5 4";
            string secondLine = "1,1 1,3 3,3";
            string thirdLine = "4 2";
            string fourthLine = "1 0 N";
            string fifthLine = "R M L M M";
            string sixthLine = "R R M";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);
            writer.WriteLine(firstLine);
            writer.WriteLine(secondLine);
            writer.WriteLine(thirdLine);
            writer.WriteLine(fourthLine);
            writer.WriteLine(fifthLine);
            writer.WriteLine(sixthLine);
            writer.Flush();

            return memoryStream.ToArray();
        }

        [Fact]
        public void TestReadShouldWriteToConsoleEachMoveSequenceResult()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var memoryStream = new MemoryStream(CreateStreamBytes());
            var fileService = new FileService(memoryStream);

            fileService.Read();

            Assert.Contains("Mine Hit", output.ToString());
            Assert.Contains("Still in Danger", output.ToString());
        }
    }
}
