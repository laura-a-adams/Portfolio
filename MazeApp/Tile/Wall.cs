using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class Wall
    {
        public bool IsOpen { get; set; }
        public ITile FirstNeighbor { get; set; }
        public ITile SecondNeighbor { get; set; }

        public Wall(ITile first, ITile Second)
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
