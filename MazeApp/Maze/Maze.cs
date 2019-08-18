using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class Maze
    {
        private readonly int size;
        private readonly ITile[,] tiles;
        public bool IsSolved { get; }
        public Maze(int size)
        {
            this.size = size;
            tiles = new AbstractTile[size, size];

            //CreatePrimsMaze();
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
                    tiles[i, j] = new OpenTile(i, j);
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
            tiles[0, 0].Visited = true;

            // Add the walls of the cell to the wall list.
            var walls = AddWallsToList(0, 0, new List<Wall>());

            // 3. While there are walls in the list:
            while (walls.Count > 0)
            {
                // Pick a random wall from the list.
                var randomWall = walls[random.Next(walls.Count)];
                // If only one of the two cells that the wall divides is visited
                if (randomWall.FirstNeighbor.Visited ^ randomWall.SecondNeighbor.Visited)
                {
                    // 1. Make the wall a passage and mark the unvisited cell as part of the maze.
                    randomWall.IsOpen = true;
                    tiles[randomWall.SecondNeighbor.X, randomWall.SecondNeighbor.Y].Visited = true; ;
                    // 2. Add the neighboring walls of the cell to the wall list.
                    AddWallsToList(randomWall.SecondNeighbor.X, randomWall.SecondNeighbor.Y, walls);
                }

                // Remove the wall from the list.
                walls.Remove(randomWall);
            }
        }

        private List<Wall> AddWallsToList(int i, int j, List<Wall> list)
        {
            // i and j are the index of the current tile. We don't want to add that tile to the list, only its neighbors
            // A tile can potentially have a north, south, east, and west neighbor

            // Add north (i - 1, j)
            if (i - 1 >= 0 && !tiles[i - 1, j].CanMoveInto())
            {
                var north = new Wall(tiles[i, j], tiles[i - 1, j]);
                tiles[i, j].North = north;
                tiles[i - 1, j].South = north;
                list.Add(north);
            }

            // Add south (i + 1, j)
            if (i + 1 < size && !tiles[i + 1, j].CanMoveInto())
            {
                var south = new Wall(tiles[i, j], tiles[i + 1, j]);
                tiles[i, j].South = south;
                tiles[i + 1, j].North = south;
                list.Add(south);
            }

            // Add east (i, j + 1)
            if (j + 1 < size && !tiles[i, j + 1].CanMoveInto())
            {
                var east = new Wall(tiles[i, j], tiles[i, j + 1]);
                tiles[i, j].East = east;
                tiles[i, j + 1].West = east;
                list.Add(east);
            }

            // Add west (i, j - 1)
            if (j - 1 >= 0 && !tiles[i, j - 1].CanMoveInto())
            {
                var west = new Wall(tiles[i, j], tiles[i, j - 1]);
                tiles[i, j].West = west;
                tiles[i, j - 1].East = west;
                list.Add(west);
            }
            return list;
        }
    }
}
