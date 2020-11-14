using System.Collections.Generic;
using Xunit;

namespace EscapeMines.Tests
{
    public class GameTest
    {
        private Game CreateGame(Board board, Turtle turtle)
        {
            return new Game(board, turtle);
        }

        private Board CreateBoard()
        {
            return new Board()
            {
                Size = new int[] { 4, 2 },
                MinesLocations = new HashSet<int[]> { new int[] { 0, 1 }, new int[] { 0, 2 } },
                ExitPoint = new int[] { 3, 1 }
            };
        }

        private Turtle CreateTurtle() 
        {
            return new Turtle()
            {
                Position = new int[] { 0, 0 },
                Direction = "S"
            };
        }

        [Fact]
        public void TestStartShouldReturnInvalidMoveIfAtLeastOneOfTheMovementsIsInvalid()
        {
            var game = CreateGame(CreateBoard(), CreateTurtle());
            const string wrongMove = "J";
            string moves = "M M " + wrongMove;

            var result = game.Run(moves.Split(" "));

            Assert.Equal("Invalid Movement " + wrongMove, result);
        }

        [Fact]
        public void TestStartShouldReturnInvalidTurtlePositionIfTurtlePositionIsInvalid()
        {
            var turtle = CreateTurtle();
            turtle.Position = new int[] { 4, 2 };
            var board = CreateBoard();
            var game = CreateGame(board, turtle);
            string moves = "M M M R M M";

            var result = game.Run(moves.Split(" "));

            Assert.Equal("Invalid Turtle Position", result);
        }

        [Fact]
        public void TestStartShouldReturnInvalidDirectionIfDirectionIsInvalid()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "J";
            var board = CreateBoard();
            var game = CreateGame(board, turtle);
            string moves = "M M M R M M";

            var result = game.Run(moves.Split(" "));

            Assert.Equal("Invalid Direction", result);
        }

        [Fact]
        public void TestStartShouldReturnSuccessIfTheTurtleHitsTheExitPoint()
        {
            var game = CreateGame(CreateBoard(), CreateTurtle());
            string movesToTheExit = "M M M L M";

            var result = game.Run(movesToTheExit.Split(" "));

            Assert.Equal("Success", result);
        }

        [Fact]
        public void TestStartShouldReturnStillInDangerIfTheTurtleDoesntHitBothTheExitPointNorTheMines()
        {
            var game = CreateGame(CreateBoard(), CreateTurtle());
            string movesToAnywhere = "M M R";

            var result = game.Run(movesToAnywhere.Split(" "));

            Assert.Equal("Still in Danger", result);
        }

        [Fact]
        public void TestStartShouldReturnMineHitIfAnyMovementHitsAMine()
        {
            var game = CreateGame(CreateBoard(), CreateTurtle());
            string movesToTheMine = "L M M R";

            var result = game.Run(movesToTheMine.Split(" "));

            Assert.Equal("Mine Hit", result);
        }
    }
}
