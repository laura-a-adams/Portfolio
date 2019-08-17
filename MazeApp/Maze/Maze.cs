using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class Maze
    {
        private int size;
        private Tile[,] tiles;
        public bool IsSolved { get; }
        public Maze(int size)
        {
            this.size = size;
            tiles = new Tile[size, size];

            InitalizeMaze();
        }

        public override string ToString()
        {
            StringBuilder mazeBuilder = new StringBuilder(size * size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mazeBuilder.Append(tiles[i, j]);
                }
                mazeBuilder.Append('\n');
            }
            return mazeBuilder.ToString();
        }

        private void InitalizeMaze()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = new ClosedTile();
                }
            }
        }
    }
}
