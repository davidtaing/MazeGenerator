using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Level;

namespace MazeDisplay
{
    public partial class Form1 : Form
    {
        public static int Height = 20;
        public static int Width = 20;
        private Maze maze = new Maze(Height, Width);


        public Form1()
        {
            InitializeComponent();
            maze.Generate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grid = new Pen(Color.LightCyan, 3);
            Pen wall = new Pen(Color.Black, 5);
            int cellHeight = panel1.Height / Height;
            int cellWidth = panel1.Height / Height;


            //Draw Grid Lines
            for (int row = 1; row < Height; row++)
            {
                g.DrawLine(grid, 0, cellHeight * row, panel1.Width, cellHeight * row);
            }

            for (int col = 1; col < Width; col++)
            {
                g.DrawLine(grid, cellWidth * col, 0, cellWidth * col , panel1.Height);
            }

            //Draw Maze Walls
            
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    //Calculate current positions
                    int xCurrent = cellWidth * row;
                    int yCurrent = cellHeight * col;


                    if (maze.Board[row, col].NorthWall)
                    {
                        PointF p1 = new PointF(xCurrent, yCurrent);
                        PointF p2 = new PointF(xCurrent + cellWidth, yCurrent);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].EastWall)
                    {
                        PointF p1 = new PointF(xCurrent + cellWidth, yCurrent);
                        PointF p2 = new PointF(xCurrent + cellWidth, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].SouthWall)
                    {
                        PointF p1 = new PointF(xCurrent, yCurrent + cellHeight);
                        PointF p2 = new PointF(xCurrent + cellWidth, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                    if (maze.Board[row, col].WestWall)
                    {
                        PointF p1 = new PointF(xCurrent, yCurrent);
                        PointF p2 = new PointF(xCurrent, yCurrent + cellHeight);
                        g.DrawLine(wall, p1, p2);
                    }
                }
            }

        }

        private void changeDimensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSizeForm f2 = new ChangeSizeForm();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maze = new Maze(Height, Width);
            maze.Generate();
            panel1.Invalidate();
        }
    }
}
