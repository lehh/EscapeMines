using System;

namespace EscapeMines
{
    public class Turtle
    {
        public enum DirectionEnum
        {
            N,
            E,
            S,
            W
        }

        public int[] Position { get; set; }

        public string Direction { get; set; }

        public void Rotate(string side)
        {
            DirectionEnum currentDirection = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), Direction);
            int nextDirection = (int)currentDirection;

            switch (side)
            {
                case "R":
                    nextDirection++;
                    break;
                case "L":
                    nextDirection--;
                    break;
            }

            if (nextDirection > 3) nextDirection = 0;
            if (nextDirection < 0) nextDirection = 3;

            Direction = ((DirectionEnum)nextDirection).ToString();
        }

        public void Move()
        {
            DirectionEnum currentDirection = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), Direction);
            int row = Position[0];
            int column = Position[1];

            switch (currentDirection)
            {
                case DirectionEnum.N:
                    Position = new int[] { row - 1, column };
                    break;
                case DirectionEnum.E:
                    Position = new int[] { row, column + 1 };
                    break;
                case DirectionEnum.S:
                    Position = new int[] { row + 1, column };
                    break;
                case DirectionEnum.W:
                    Position = new int[] { row, column - 1 };
                    break;
            }
        }
    }
}
