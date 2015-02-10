using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeDisplay
{
    public partial class ChangeSizeForm : Form
    {
        public ChangeSizeForm()
        {
            InitializeComponent();
            numericUpDown_Height.Value = Form1.Height;
            numericUpDown_Width.Value = Form1.Width;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Form1.Height = (int)numericUpDown_Height.Value;
            Form1.Width = (int)numericUpDown_Width.Value;
            MessageBox.Show("Dimensions Saved.");
        }
    }
}
