using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    public class Board
    {
        public int[] Size { get; set; }

        public HashSet<int[]> MinesLocations { get; set; }

        public int[] ExitPoint { get; set; }
    }
}
