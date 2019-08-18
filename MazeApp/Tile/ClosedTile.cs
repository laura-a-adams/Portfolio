using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    class ClosedTile : AbstractTile
    {
        private readonly bool _OPEN = false;
        private readonly string _PRINT = "[X]";
        public ClosedTile(int x, int y) : base (x, y)
        {
            open = _OPEN;
            print = _PRINT;
        }
    }
}
