using System;
using System.Collections.Generic;
using System.Text;

namespace MazeApp
{
    public class OpenTile : AbstractTile
    {
        private readonly bool _OPEN = true;
        private readonly string _PRINT = "[ ]";
        public OpenTile(int x, int y) : base(x, y)
        {
            open = _OPEN;
            print = _PRINT;
        }

        public override string ToString()
        {
            var print = "";
            var visited = Visited ? " " : "X";
            // No Walls: "  "
            if (North == null && South == null && East == null && West == null)
                print = $" {visited} ";
            // North Wall: "--"
            if (North != null && South == null && East == null && West == null)
                print = $"-{visited}-";
            // South Wall: "__"
            if (North == null && South != null && East == null && West == null)
                print = $"_{visited}_";
            // East Wall: "| "
            if (North == null && South == null && East != null && West == null)
                print = $"|{visited} ";
            // West Wall: " |"
            if (North == null && South == null && East == null && West != null)
                print = $" {visited}|";
            // North and South: "-_"
            if (North != null && South != null && East == null && West == null)
                print = $"-{visited}_";
            // North and East: "|-"
            if (North != null && South == null && East != null && West == null)
                print = $"|{visited}-";
            // North and West: "-|"
            if (North != null && South == null && East == null && West != null)
                print = $"-{visited}|";
            // South and East: "|_"
            if (North == null && South != null && East != null && West == null)
                print = $"|{visited}_";
            // South and West: "_|"
            if (North == null && South != null && East == null && West != null)
                print = $"_{visited}|";
            // East and West: "||"
            if (North == null && South == null && East != null && West != null)
                print = $"|{visited}|";

            return print;
        }
    }
}
