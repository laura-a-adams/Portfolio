using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace MazeApp
{
    public class OpenTileTests
    {
        private OpenTile tile;
        public OpenTileTests()
        {
            // Set up
            var x = 0;
            var y = 0;

            // Execute
            tile = new OpenTile(x, y);
        }

        [Fact]
        public void ConstructorTest()
        {
            // Assert
            Assert.False(tile.Visited);
        }

        [Fact]
        public void AttachEastNeighbor()
        {
            // Set up
            var x2 = 0;
            var y2 = 1;
            var tile2 = new OpenTile(x2, y2);

            // Execute
            var wall = tile.AttachEastNeighbor(tile2);

            // Assert
            Assert.Equal(tile, wall.FirstNeighbor);
            Assert.Equal(tile2, wall.SecondNeighbor);
            Assert.Equal(tile.East, wall);
            Assert.Equal(tile2.West, wall);
        }
    }
}