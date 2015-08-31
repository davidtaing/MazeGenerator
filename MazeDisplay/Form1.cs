using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeDisplay
{
    public partial class Form1 : Form
    {
        public static int MazeHeight = 20;
        public static int MazeWidth = 20;
        private Maze maze;


        public Form1()
        {
            InitializeComponent();
            maze = new Maze(MazeHeight, MazeWidth);
            maze.Generate();
        }

        /// <summary>
        /// Draws the grid and walls of the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grid = new Pen(Color.LightCyan, 3);
            Pen wall = new Pen(Color.Black, 5);
            int cellHeight = panel1.Height / MazeHeight;
            int cellWidth = panel1.Width / MazeWidth;


            DrawGrid(g, grid, cellHeight, cellWidth);
            DrawWalls(g, wall, cellHeight, cellWidth);
        }

        private void DrawGrid(Graphics g, Pen grid, int cellHeight, int cellWidth)
        {
            for (int row = 1; row < MazeHeight; row++)
            {
                g.DrawLine(grid, 0, cellHeight*row, panel1.Width, cellHeight*row);
            }

            for (int col = 1; col < MazeWidth; col++)
            {
                g.DrawLine(grid, cellWidth*col, 0, cellWidth*col, panel1.Height);
            }
        }

        private void DrawWalls(Graphics g, Pen wall, int cellHeight, int cellWidth)
        {
            for (int row = 0; row < MazeHeight; row++)
            {
                for (int col = 0; col < MazeWidth; col++)
                {
                    //Calculate current positions
                    int xCurrent = cellWidth*col;
                    int yCurrent = cellHeight*row;

                    PointF p1;
                    PointF p2;

                    if (maze.Board[row, col].NorthWall)
                    {
                        p1 = new PointF(xCurrent, yCurrent);
                        p2 = new PointF(xCurrent + cellWidth, yCurrent);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].EastWall)
                    {
                        p1 = new PointF(xCurrent + cellWidth, yCurrent);
                        p2 = new PointF(xCurrent + cellWidth, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].SouthWall)
                    {
                        p1 = new PointF(xCurrent, yCurrent + cellHeight);
                        p2 = new PointF(xCurrent + cellWidth, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].WestWall)
                    {
                        p1 = new PointF(xCurrent, yCurrent);
                        p2 = new PointF(xCurrent, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                }
            }
        }

        /// <summary>
        /// Opens a prompt, where the user can change the field dimensions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeDimensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSizeForm f2 = new ChangeSizeForm();
            f2.Show();
        }

        /// <summary>
        /// Generates a new maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            maze = new Maze(MazeHeight, MazeWidth);
            maze.Generate();
            panel1.Invalidate();
        }
    }
}
