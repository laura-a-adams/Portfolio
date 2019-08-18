using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class Wall
    {
        public bool IsOpen { get; set; }
        public Tile FirstNeighbor { get; set; }
        public Tile SecondNeighbor { get; set; }

        public Wall(Tile first, Tile Second)
        {
            FirstNeighbor = first;
            SecondNeighbor = Second;
        }

        public override string ToString()
        {
            if (IsOpen) return "";
            return "-";
        }
    }
}
