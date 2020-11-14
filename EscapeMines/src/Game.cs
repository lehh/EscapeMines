using System.Collections.Generic;
using System.Linq;

namespace EscapeMines
{
    public class Game
    {
        private readonly Turtle _turtle;
        private readonly Board _board;

        public Game(Board board, Turtle turtle)
        {
            _board = board;
            _turtle = turtle;
        }

        public string Run(string[] moves)
        {
            if (!TurtleDirectionIsValid()) return "Invalid Direction";

            foreach (var move in moves)
            {
                if (!MovementIsValid(move)) return "Invalid Movement " + move;

                DoAction(move);

                if (!TurtlePositionIsValid()) return "Invalid Turtle Position";
                if (MineHit()) return "Mine Hit";
            }

            return CheckActionsResult();
        }

        private string CheckActionsResult() 
        {
            if (Enumerable.SequenceEqual(_turtle.Position, _board.ExitPoint))
            {
                return "Success";
            }

            return "Still in Danger";
        }

        private bool MineHit()
        {
            foreach (var mineLocation in _board.MinesLocations)
            {
                if (Enumerable.SequenceEqual(_turtle.Position, mineLocation)) return true;
            }

            return false;
        }

        private void DoAction(string move) 
        { 
            if (string.Equals(move, "M"))
            {
                _turtle.Move();
                return;
            }

            _turtle.Rotate(move);
        }
        
        private bool MovementIsValid(string move) 
        {
            List<string> validMoves = new List<string>() { "M", "R", "L" };

            return validMoves.Contains(move);
        }

        private bool TurtlePositionIsValid()
        {
            int row = _turtle.Position[0];
            int column = _turtle.Position[1];

            bool rowIsValid = _board.Size[0] - 1 >= row && row >= 0;
            bool columnIsValid = _board.Size[1] - 1 >= column && column >= 0;

            return rowIsValid && columnIsValid;
        }

        private bool TurtleDirectionIsValid()
        {
            List<string> validDirections = new List<string>() { "N", "S", "E", "W" };

            return validDirections.Contains(_turtle.Direction);
        }
    }
}
