using MazeApp;
using System;
using Xunit;

namespace MazeAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void AttachEastNeighbor()
        {
            // Set up
            var x1 = 0;
            var y1 = 0;
            var x2 = 0;
            var y2 = 1;
            var t1 = new OpenTile(x1, y1);
            var t2 = new OpenTile(x2, y2);

            // Execute
            var w = t1.AttachEastNeighbor(t2);

            // Assert
            Assert.Equal(w, t1.East);
            Assert.Equal(w, t2.West);
            Assert.Equal(t1, w.FirstNeighbor);
            Assert.Equal(t2, w.SecondNeighbor);
        }

        [Fact]
        public void AttachWestNeighbor()
        {
            // Set up
            var x1 = 0;
            var y1 = 1;
            var x2 = 0;
            var y2 = 0;
            var t1 = new OpenTile(x1, y1);
            var t2 = new OpenTile(x2, y2);

            // Execute
            var w = t1.AttachWestNeighbor(t2);

            // Assert
            Assert.Equal(w, t1.West);
            Assert.Equal(w, t2.East);
            Assert.Equal(t1, w.FirstNeighbor);
            Assert.Equal(t2, w.SecondNeighbor);
        }

        [Fact]
        public void AttachSouthNeighbor()
        {
            // Set up
            var x1 = 0;
            var y1 = 0;
            var x2 = 1;
            var y2 = 0;
            var t1 = new OpenTile(x1, y1);
            var t2 = new OpenTile(x2, y2);

            // Execute
            var w = t1.AttachSouthNeighbor(t2);

            // Assert
            Assert.Equal(w, t1.South);
            Assert.Equal(w, t2.North);
            Assert.Equal(t1, w.FirstNeighbor);
            Assert.Equal(t2, w.SecondNeighbor);
        }

        [Fact]
        public void AttachNorthNeighbor()
        {
            // Set up
            var x1 = 1;
            var y1 = 0;
            var x2 = 0;
            var y2 = 0;
            var t1 = new OpenTile(x1, y1);
            var t2 = new OpenTile(x2, y2);

            // Execute
            var w = t1.AttachNorthNeighbor(t2);

            // Assert
            Assert.Equal(w, t1.North);
            Assert.Equal(w, t2.South);
            Assert.Equal(t1, w.FirstNeighbor);
            Assert.Equal(t2, w.SecondNeighbor);
        }
    }
}
