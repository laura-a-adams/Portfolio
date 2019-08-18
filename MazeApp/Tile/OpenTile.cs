using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    class OpenTile : AbstractTile
    {
        private readonly bool _OPEN = true;
        private readonly string _PRINT = "[ ]";
        public OpenTile(int x, int y) : base(x, y)
        {
            open = _OPEN;
            print = _PRINT;
        }
    }
}
