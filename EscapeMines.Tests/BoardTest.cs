using System.Collections.Generic;
using Xunit;

namespace EscapeMines.Tests
{
    public class BoardTest
    {
        private Board CreateBoard()
        {
            return new Board();
        }

        [Fact]
        public void TestSizeShouldSetAndGetSize()
        {
            var board = CreateBoard();
            int[] expectedSize = { 3, 4 };

            board.Size = expectedSize;

            Assert.Equal(expectedSize, board.Size);
        }

        [Fact]
        public void TestMinesLocationsShouldSetAndGetMinesLocations()
        {
            var board = CreateBoard();
            var expectedLocations = new HashSet<int[]>{ new int[]{ 1,2 }, new int[]{ 3,4 } };

            board.MinesLocations = expectedLocations;

            Assert.Equal(expectedLocations, board.MinesLocations);
        }

        [Fact]
        public void TestExitPointShouldSetAndGetExitPoint()
        {
            var board = CreateBoard();
            int[] expectedExitPoint = { 3, 1 };

            board.ExitPoint = expectedExitPoint;

            Assert.Equal(expectedExitPoint, board.ExitPoint);
        }
    }
}
