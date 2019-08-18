using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    class AbstractTile : Tile
    {
        protected bool open;
        protected string print;

        public int X { get; set; }
        public int Y { get; set; }
        public Wall North { get; set; }
        public Wall South { get; set; }
        public Wall East { get; set; }
        public Wall West { get; set; }
        public bool Visited { get; set; }

        public AbstractTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool CanMoveInto()
        {
            return open;
        }

        public override string ToString()
        {
            return print;
        }
    }
}
