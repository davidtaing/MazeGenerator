using System;

namespace MazeDisplay
{
    [Flags]
    public enum Direction
    {
        Invalid = 0,
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }
}
