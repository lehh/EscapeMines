using Xunit;

namespace EscapeMines.IntegrationTests
{
    public class ProgramTest
    {
        [Fact]
        public void TestRunShouldNotThrowExceptionWhenFileExistsAndItsInTheCorrectFormat()
        {
            var program = new Program();

            var exception = Record.Exception(() => program.Run());

            Assert.Null(exception);
        }
    }
}
