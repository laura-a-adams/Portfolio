using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public interface Tile
    {
        int X { get; set; }
        int Y { get; set; }
        Wall North { get; set; }
        Wall South { get; set; }
        Wall East { get; set; }
        Wall West { get; set; }
        bool Visited { get; set; }
        bool CanMoveInto();
    }
}
