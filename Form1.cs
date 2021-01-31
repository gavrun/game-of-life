using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int columns;

        public StartGame()
        { if (timer1.Enabled)
                return;

            button1.Enabled = false;
            button2.Enabled = false;
            resolution = (int)numericUpDown1.Value;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            field = new bool[rows, columns]; 

            Random random = new Random();
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)numericUpDown2.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //resolution = (int)numericUpDown1.Value;
            //pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //graphics = Graphics.FromImage(pictureBox1.Image);
            //graphics.FillRectangle(Brushes.Crimson, 0, 0, resolution, resolution);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
