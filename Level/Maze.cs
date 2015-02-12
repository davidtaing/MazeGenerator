using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Level
{
    public class Maze
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Cell[,] Board;
        private Random r = new Random();

        /// <summary>
        /// Constructor
        /// </summary>
        public Maze()
        {
            Initialise();
        }

        /// <summary>
        /// Creates board and populates all cells with default values.
        /// </summary>
        private void Initialise()
        {
            Board = new Cell[Width, Height];

            //Populate default values of the cells
            for (int col = 0; col < Width; col++)
            {
                for (int row = 0; row < Height; row++)
                {
                    Board[col, row] = new Cell();
                }
            }
        }

        /// <summary>
        /// Overloaded
        /// </summary>
        public void Generate()
        {
            Generate(r.Next(Width), r.Next(Height));
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
        private void CarvePassage(CellPosition currentPos)
        {
            List<Direction> validDirections = PopulateDirections();
            GetValidDirections(currentPos, validDirections);

            while (validDirections.Count > 0)
            {
                Direction rndDirection = Direction.INVALID;

                if (validDirections.Count > 1)
                    rndDirection = validDirections[r.Next(validDirections.Count)];
                else if (validDirections.Count == 1)
                    rndDirection = validDirections[0];

                //Remove corresponding wall
                RemoveWall(currentPos, rndDirection);
                Board[currentPos.X, currentPos.Y].Visited = true;

                //Remove selected direction for validDirections List
                validDirections.Remove(rndDirection);

                //Recursively call CarvePassage if rndDirection is valid
                if (rndDirection != Direction.INVALID)
                {
                    CellPosition newPos = GetAdjTilePos(currentPos, rndDirection);
                    CarvePassage(newPos);
                }

                //Update Valid Directions
                GetValidDirections(currentPos, validDirections);
            }
        }

        /// <summary>
        /// Overloaded
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        private void CarvePassage(int currentX, int currentY)
        {
            CarvePassage(new CellPosition(currentX, currentY));
        }

        #region CarvePassage Subroutines
        /// <summary>
        /// Populates the provided list with all directions
        /// </summary>
        private List<Direction> PopulateDirections()
        {
            List<Direction> validDirections = new List<Direction>() {
                Direction.North,
                Direction.East,
                Direction.South,
                Direction.West
            };

            return validDirections;
        }

        /// <summary>
        /// Validates directions for the provided cell
        /// </summary>
        /// <param name="cellPos"></param>
        /// <param name="directions"></param>
        private void GetValidDirections(CellPosition cellPos, List<Direction> directions)
        {
            List<Direction> invalidMoves = new List<Direction>();

            //Checking for invalid moves
            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case Direction.North:
                        if (cellPos.Y == 0 || CellVisited(cellPos.X, cellPos.Y - 1))
                            invalidMoves.Add(Direction.North);
                        break;
                    case Direction.East:
                        if (cellPos.X == Width - 1 || CellVisited(cellPos.X + 1, cellPos.Y))
                            invalidMoves.Add(Direction.East);
                        break;
                    case Direction.South:
                        if (cellPos.Y == Height - 1 || CellVisited(cellPos.X, cellPos.Y + 1))
                            invalidMoves.Add(Direction.South);
                        break;
                    case Direction.West:
                        if (cellPos.X == 0 || CellVisited(cellPos.X - 1, cellPos.Y))
                            invalidMoves.Add(Direction.West);
                        break;
                }

            }

            //Eliminating invalid moves
            foreach (var item in invalidMoves)
                directions.Remove(item);
        }

        /// <summary>
        /// Changes bool flag of the provided wall to false for both the current cell and adjacent cell.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="direction"></param>
        private void RemoveWall(CellPosition pos, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    Board[pos.X, pos.Y].NorthWall = false;
                    Board[pos.X, pos.Y - 1].SouthWall = false;
                    break;
                case Direction.East:
                    Board[pos.X, pos.Y].EastWall = false;
                    Board[pos.X + 1, pos.Y].WestWall = false;
                    break;
                case Direction.South:
                    Board[pos.X, pos.Y].SouthWall = false;
                    Board[pos.X, pos.Y + 1].NorthWall = false;
                    break;
                case Direction.West:
                    Board[pos.X, pos.Y].WestWall = false;
                    Board[pos.X - 1, pos.Y].EastWall = false;
                    break;
            }
        }

        /// <summary>
        /// Returns if the Cell has been visited or not
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CellVisited(int x, int y)
        {
            return Board[x, y].Visited;
        }

        /// <summary>
        /// Returns the position of the adjacent cell
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private CellPosition GetAdjTilePos(CellPosition position, Direction direction)
        {
            CellPosition adjPosition = new CellPosition(position.X, position.Y);

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
        #endregion
    }
}
