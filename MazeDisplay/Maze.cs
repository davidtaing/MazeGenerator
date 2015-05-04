using System;
using System.Collections.Generic;
using System.Drawing;

namespace MazeDisplay
{
    public class Maze
    {
        public Cell[,] Board;
        private readonly Random rng = new Random();

        public int Height { get; set; }
        public int Width { get; set; }

        public Maze()
        {
            Initialise();
        }

        /// <summary>
        /// Creates board and populates all cells with default values.
        /// </summary>
        private void Initialise()
        {
            Board = new Cell[Height, Width];

            //Populate default values of the cells
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Board[row, col] = new Cell();
                }
            }
        }

        /// <summary>
        /// </summary>
        public void Generate()
        {
            Generate(rng.Next(Width), rng.Next(Height));
        }
        
        /// <summary>
        /// Generates a maze using the recursive backtracker algorithim.
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void Generate(int startX, int startY)
        {
            Initialise();
            CarvePassage(startX, startY);
        }

        /// <summary>
        /// Sub-routine in the generate method.
        /// </summary>
        /// <param name="currentPos"></param>
        private void CarvePassage(Point currentPos)
        {
            Board[currentPos.Y, currentPos.X].Visited = true;
            List<Direction> validDirections = GetAllDirections();
            ValidateDirections(currentPos, validDirections);

            while (validDirections.Count > 0)
            {
                Direction rndDirection = Direction.Invalid;

                if (validDirections.Count > 1)
                    rndDirection = validDirections[rng.Next(validDirections.Count)];
                else if (validDirections.Count == 1)
                    rndDirection = validDirections[0];

                RemoveWall(currentPos, rndDirection);
                validDirections.Remove(rndDirection);
                Point newPos = GetAdjPos(currentPos, rndDirection);
                CarvePassage(newPos);

                ValidateDirections(currentPos, validDirections);
            }
        }

        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        private void CarvePassage(int currentX, int currentY)
        {
            CarvePassage(new Point(currentX, currentY));
        }

        /// <summary>
        /// Populates the provided list with all directions
        /// </summary>
        private List<Direction> GetAllDirections()
        {
            return new List<Direction>() {
                Direction.North,
                Direction.East,
                Direction.South,
                Direction.West
            };
        }

        /// <summary>
        /// Validates directions for the provided cell
        /// </summary>
        /// <param name="cellPos"></param>
        /// <param name="directions"></param>
        private void ValidateDirections(Point cellPos, List<Direction> directions)
        {
            List<Direction> invalidDirections = new List<Direction>();

            // Check for invalid moves
            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case Direction.North:
                        if (cellPos.Y == 0 || CellVisited(cellPos.X, cellPos.Y - 1))
                            invalidDirections.Add(Direction.North);
                        break;
                    case Direction.East:
                        if (cellPos.X == Width - 1 || CellVisited(cellPos.X + 1, cellPos.Y))
                            invalidDirections.Add(Direction.East);
                        break;
                    case Direction.South:
                        if (cellPos.Y == Height - 1 || CellVisited(cellPos.X, cellPos.Y + 1))
                            invalidDirections.Add(Direction.South);
                        break;
                    case Direction.West:
                        if (cellPos.X == 0 || CellVisited(cellPos.X - 1, cellPos.Y))
                            invalidDirections.Add(Direction.West);
                        break;
                }
            }
            
            // Eliminating invalid moves
            foreach (var item in invalidDirections)
                directions.Remove(item);
        }

        /// <summary>
        /// Changes bool flag of the provided wall to false for both the current cell and adjacent cell.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="direction"></param>
        private void RemoveWall(Point pos, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    Board[pos.Y, pos.X].NorthWall = false;
                    Board[pos.Y - 1, pos.X].SouthWall = false;
                    break;
                case Direction.East:
                    Board[pos.Y, pos.X].EastWall = false;
                    Board[pos.Y, pos.X + 1].WestWall = false;
                    break;
                case Direction.South:
                    Board[pos.Y, pos.X].SouthWall = false;
                    Board[pos.Y + 1, pos.X].NorthWall = false;
                    break;
                case Direction.West:
                    Board[pos.Y, pos.X].WestWall = false;
                    Board[pos.Y, pos.X - 1].EastWall = false;
                    break;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CellVisited(int x, int y)
        {
            return Board[y, x].Visited;
        }

        /// <summary>
        /// Returns the position of an adjacent cell.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Point GetAdjPos(Point position, Direction direction)
        {
            Point adjPosition = position;

            switch (direction)
            {
                case Direction.North:
                    adjPosition.Y = adjPosition.Y - 1;
                    break;
                case Direction.East:
                    adjPosition.X = adjPosition.X + 1;
                    break;
                case Direction.South:
                    adjPosition.Y = adjPosition.Y + 1;
                    break;
                case Direction.West:
                    adjPosition.X = adjPosition.X - 1;
                    break;
            }

            return adjPosition;
        }
    }
}
