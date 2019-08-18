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

            CreatePrimsMaze();
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
                    tiles[i, j] = new ClosedTile(i, j);
                }
            }
        }

        /* Creates a maze using a randomized version of Prim's algorithm. Here are the steps:
         * 1. Start with a grid full of walls.
         * 2. Pick a cell, mark it as part of the maze. Add the walls of the cell to the wall list.
         * 3. While there are walls in the list:
         *      1. Pick a random wall from the list. If only one of the two cells that the wall divides is visited, then:
         *          1. Make the wall a passage and mark the unvisited cell as part of the maze.
         *          2. Add the neighboring walls of the cell to the wall list.
         *      2. Remove the wall from the list.
        */
        private void CreatePrimsMaze() {
            // 1. Start with a grid full of walls.
            InitalizeMaze();
            var random = new Random();

            // 2. Pick a cell, mark it as part of the maze.
            // Note we're always going to start the user at 0, 0
            tiles[0, 0] = new OpenTile(0, 0);

            // Add the walls of the cell to the wall list.
            var walls = AddWallsToList(0, 0, new List<Tile>());

            // 3. While there are walls in the list:
            while (walls.Count > 0)
            {
                // Pick a random wall from the list.
                var randomWall = walls[random.Next(walls.Count)];
                // If only one of the two cells that the wall divides is visited
                if (randomWall.Y + 1 < size && !tiles[randomWall.X, randomWall.Y + 1].CanMoveInto())
                {
                    // 1. Make the wall a passage and mark the unvisited cell as part of the maze.
                    tiles[randomWall.X, randomWall.Y] = new OpenTile(randomWall.X, randomWall.Y);
                    // 2. Add the neighboring walls of the cell to the wall list.
                    AddWallsToList(randomWall.X, randomWall.Y, walls);
                }

                // Remove the wall from the list.
                walls.Remove(randomWall);
            }
        }

        private List<Tile> AddWallsToList(int i, int j, List<Tile> list)
        {
            // i and j are the index of the current tile. We don't want to add that tile to the list, only its neighbors
            // A tile can potentially have a north, south, east, and west neighbor

            // Add north (i - 1, j)
            if (i - 1 >= 0 && !tiles[i - 1, j].CanMoveInto())
            {
                list.Add(tiles[i - 1, j]);
            }

            // Add south (i + 1, j)
            if (i + 1 < size && !tiles[i + 1, j].CanMoveInto())
            {
                list.Add(tiles[i + 1, j]);
            }

            // Add east (i, j + 1)
            if (j + 1 < size && !tiles[i, j + 1].CanMoveInto())
            {
                list.Add(tiles[i, j + 1]);
            }

            // Add west (i, j - 1)
            if (j - 1 >= 0 && !tiles[i, j - 1].CanMoveInto())
            {
                list.Add(tiles[i, j - 1]);
            }
            return list;
        }
    }
}
