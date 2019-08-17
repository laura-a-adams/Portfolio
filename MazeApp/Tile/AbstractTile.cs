using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    class AbstractTile : Tile
    {
        protected bool open;
        protected string print;
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
