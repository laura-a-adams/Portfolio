using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public interface Tile
    {
        int X { get; set; }
        int Y { get; set; }

        bool CanMoveInto();
    }
}
