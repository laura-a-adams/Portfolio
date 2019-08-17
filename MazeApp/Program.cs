using System;

namespace MazeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a maze size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Creating {size}x{size} Maze...");
            Console.WriteLine("Solve the maze by moving N, S, E, W!");

            var maze = new Maze(size);
            while (!maze.IsSolved)
            {
                Console.WriteLine(maze);
                Console.Write("Move: ");
                var direction = Convert.ToChar(Console.ReadLine());
                if (!IsValidDirection(Char.ToUpper(direction)))
                {
                    Console.WriteLine($"Entered value \"{direction}\" is not valid.");
                    continue;
                }
            }
        }

        private static bool IsValidDirection(char direction)
        {
            return direction == 'N' || direction == 'S' || direction == 'E' || direction == 'W';
        }
    }
}
