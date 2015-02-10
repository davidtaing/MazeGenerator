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
        private int Height;
        private int Width;

        public Cell[,] Board;
        private Random r = new Random();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Maze(int height, int width)
        {
            Height = height;
            Width = width;

            Board = new Cell[height, width];
            InitBoard();
        }

        /// <summary>
        /// Initialises instances of all cells on the board
        /// </summary>
        private void InitBoard()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Board[row, col] = new Cell();
                }
            }
        }

        /// <summary>
        /// Overloaded
        /// </summary>
        public void Generate()
        {
            Generate(r.Next(Height), r.Next(Width));
        }

        /// <summary>
        /// Generates a maze using the recursive backtracker algorithim.
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void Generate(int startX, int startY)
        {
            CarvePassage(startX, startY);
        }

        /// <summary>
        /// 
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


                CellPosition newPos = GetAdjTilePos(currentPos, rndDirection);

                //Remove selected direction for validDirections List
                validDirections.Remove(rndDirection);



                //Remove corresponding wall
                RemoveWall(currentPos, rndDirection);
                Board[currentPos.X, currentPos.Y].Visited = true;

                //Recursively call CarvePassage if rndDirection is valid
                if (rndDirection != Direction.INVALID)
                    CarvePassage(newPos);

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

        /// <summary>
        /// Populates all direction in the provided list
        /// </summary>
        /// <param name="validDirections"></param>
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
        /// Returns all valid directions for the provided cell
        /// </summary>
        /// <param name="cellPos"></param>
        /// <returns></returns>
        private List<Direction> GetValidDirections(CellPosition cellPos, List<Direction> validDirections)
        {
            List<Direction> invalidMoves = new List<Direction>();

            //Checking for invalid moves
            for (int i = 0; i < validDirections.Count; i++)
            {
                switch (validDirections[i])
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
                validDirections.Remove(item);

            return validDirections;
        }

        /// <summary>
        /// Changes bool flag of the provided wall to false for both the current cell and adjacent cell.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        private void RemoveWall(CellPosition position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    Board[position.X, position.Y].NorthWall = false;
                    Board[position.X, position.Y - 1].SouthWall = false;
                    break;
                case Direction.East:
                    Board[position.X, position.Y].EastWall = false;
                    Board[position.X + 1, position.Y].WestWall = false;
                    break;
                case Direction.South:
                    Board[position.X, position.Y].SouthWall = false;
                    Board[position.X, position.Y + 1].NorthWall = false;
                    break;
                case Direction.West:
                    Board[position.X, position.Y].WestWall = false;
                    Board[position.X - 1, position.Y].EastWall = false;
                    break;
            }
        }

        /// <summary>
        /// Returns if the provided cell has been visited or not.
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        private bool CellVisited(int cellX, int cellY)
        {
            return Board[cellX, cellY].Visited;
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
    }
}
