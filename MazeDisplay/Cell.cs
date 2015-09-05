using System.Collections.Generic;
using System.Drawing;

namespace MazeDisplay
{
    public class Cell
    {
        public bool Visited = false;
        public bool NorthWall = true;
        public bool SouthWall = true;
        public bool EastWall = true;
        public bool WestWall = true;
        public int position_in_iteration;
        public bool isdeadend = false;
        public Point Point;
        public int visited_count = 0;
    }
}
