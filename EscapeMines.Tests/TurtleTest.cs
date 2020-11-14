using Xunit;

namespace EscapeMines.Tests
{
    public class TurtleTest
    {
        private Turtle CreateTurtle()
        {
            return new Turtle()
            {
                Position = new int[] { 0, 0 },
                Direction = "S"
            };
        }

        [Fact]
        public void TestPositionShouldSetAndGetPosition()
        {
            var turtle = CreateTurtle();
            int[] expectedPosition = new int[] { 1, 2 };

            turtle.Position = expectedPosition;

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestDirectionShouldSetAndGetDirection()
        {
            var turtle = CreateTurtle();
            string expectedDirection = "N";

            turtle.Direction = expectedDirection;

            Assert.Equal(expectedDirection, turtle.Direction);
        }

        [Fact]
        public void TestMoveShouldDecreasePositionRowNumberWhenDirectionIsNorth()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "N";
            var expectedPosition = new int[] { turtle.Position[0] - 1, turtle.Position[1] };

            turtle.Move();

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestMoveShouldIncreasePositionColumnNumberWhenDirectionIsEast()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "E";
            var expectedPosition = new int[] { turtle.Position[0], turtle.Position[1] + 1 };

            turtle.Move();

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestMoveShouldIncreasePositionRowNumberWhenDirectionIsSouth()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "S";
            var expectedPosition = new int[] { turtle.Position[0] + 1, turtle.Position[1] };

            turtle.Move();

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestMoveShouldDecreasePositionColumnNumberWhenDirectionIsWest()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "W";
            var expectedPosition = new int[] { turtle.Position[0], turtle.Position[1] - 1 };

            turtle.Move();

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestRotateShouldNotChangePosition()
        {
            var turtle = CreateTurtle();
            turtle.Direction = "W";
            var expectedPosition = turtle.Position;

            turtle.Rotate("R");

            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Fact]
        public void TestRotateShouldIncreaseDirectionIfSideIsR()
        {
            var turtle = CreateTurtle();
            var direction = Turtle.DirectionEnum.S;
            var rightDirection = (int)direction + 1;
            turtle.Direction = direction.ToString();
            var expectedDirection = (Turtle.DirectionEnum)rightDirection;

            turtle.Rotate("R");

            Assert.Equal(expectedDirection.ToString(), turtle.Direction);
        }

        [Fact]
        public void TestRotateShouldDecreaseDirectionIfSideIsL()
        {
            var turtle = CreateTurtle();
            var direction = Turtle.DirectionEnum.S;
            var leftDirection = (int)direction - 1;
            turtle.Direction = direction.ToString();
            var expectedDirection = (Turtle.DirectionEnum)leftDirection;

            turtle.Rotate("L");

            Assert.Equal(expectedDirection.ToString(), turtle.Direction);
        }

        [Fact]
        public void TestRotateShouldGoToDirectionNumberZeroIfNextDirectionIsGreaterThanThree()
        {
            var turtle = CreateTurtle();
            var direction = Turtle.DirectionEnum.W;
            var nextDirection = 0;
            turtle.Direction = direction.ToString();
            var expectedDirection = (Turtle.DirectionEnum)nextDirection;

            turtle.Rotate("R");

            Assert.Equal(expectedDirection.ToString(), turtle.Direction);
        }

        [Fact]
        public void TestRotateShouldGoToDirectionNumberThreeIfNextDirectionIsLesserThanZero()
        {
            var turtle = CreateTurtle();
            var direction = Turtle.DirectionEnum.N;
            var nextDirection = 3;
            turtle.Direction = direction.ToString();
            var expectedDirection = (Turtle.DirectionEnum)nextDirection;

            turtle.Rotate("L");

            Assert.Equal(expectedDirection.ToString(), turtle.Direction);
        }
    }
}
