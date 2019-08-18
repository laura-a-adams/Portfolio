using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class AbstractTile : ITile
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

        public Wall AttachEastNeighbor(ITile neighbor)
        {
            Wall wall = new Wall(this, neighbor);
            this.East = wall;
            neighbor.West = wall;
            return wall;
        }

        public Wall AttachWestNeighbor(ITile neighbor)
        {
            Wall wall = new Wall(this, neighbor);
            this.West = wall;
            neighbor.East = wall;
            return wall;
        }

        public Wall AttachSouthNeighbor(ITile neighbor)
        {
            Wall wall = new Wall(this, neighbor);
            this.South = wall;
            neighbor.North = wall;
            return wall;
        }

        public Wall AttachNorthNeighbor(ITile neighbor)
        {
            Wall wall = new Wall(this, neighbor);
            this.North = wall;
            neighbor.South = wall;
            return wall;
        }
    }
}
