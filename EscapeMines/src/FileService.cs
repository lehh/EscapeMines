using System;
using System.Collections.Generic;
using System.IO;

namespace EscapeMines
{
    public class FileService
    {
        private readonly Stream _stream;

        private Board _board;
        private Turtle _turtle;

        public FileService(Stream stream)
        {
            _stream = stream;
            _board = new Board();
            _turtle = new Turtle();
        }

        public void Read()
        {
            int lineCounter = 1;
            string line;

            using StreamReader reader = new StreamReader(_stream);

            while ((line = reader.ReadLine()) != null)
            {
                ProcessLine(lineCounter, line);
                lineCounter++;
            }

            reader.Close();
        }

        private void ProcessLine(int lineNumber, string lineContent)
        {
            var lineArray = lineContent.Split(" ");

            switch (lineNumber)
            {
                case 1:
                    SetBoardSize(lineArray);
                    break;
                case 2:
                    SetMinesLocations(lineArray);
                    break;
                case 3:
                    SetExitPoint(lineArray);
                    break;
                case 4:
                    SetTurtlePosition(lineArray);
                    break;
                default:
                    StartNewGame(lineArray);
                    break;
            }
        }

        private void StartNewGame(string[] movesData)
        {
            var turtle = new Turtle() 
            {
               Direction = _turtle.Direction,
               Position = _turtle.Position
            };

            var game = new Game(_board, turtle);
            string gameResult = game.Run(movesData);

            Console.WriteLine(gameResult);
        }

        private void SetTurtlePosition(string[] turtleData)
        {
            int row = Convert.ToInt32(turtleData[0]);
            int column = Convert.ToInt32(turtleData[1]);
            string direction = turtleData[2];

            _turtle.Position = new int[] { row, column };
            _turtle.Direction = direction;
        }

        private void SetExitPoint(string[] exitData)
        {
            int row = Convert.ToInt32(exitData[0]);
            int column = Convert.ToInt32(exitData[1]);

            _board.ExitPoint = new int[] { row, column };
        }

        private void SetMinesLocations(string[] minesData)
        {
            var minesLocations = new HashSet<int[]>();

            foreach (var minePosition in minesData)
            {
                var positionArray = minePosition.Split(",");
                int row = Convert.ToInt32(positionArray[0]);
                int column = Convert.ToInt32(positionArray[1]);

                minesLocations.Add(new int[] { row, column });
            }

            _board.MinesLocations = minesLocations;
        }

        private void SetBoardSize(string[] sizeData)
        {
            int row = Convert.ToInt32(sizeData[0]);
            int column = Convert.ToInt32(sizeData[1]);

            _board.Size = new int[] { row, column };
        }
    }
}
