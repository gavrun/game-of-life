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

        public Form1()
        {
            InitializeComponent();
        }

        public void StartGame()
        { 
            if (timer1.Enabled)
                return;

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            //button1.Enabled = false;
            //button2.Enabled = true;

            resolution = (int)numericUpDown1.Value;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            field = new bool[columns, rows];
            
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

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (field[x, y])
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            /*Random random = new Random();
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)numericUpDown2.Value) == 0;
                }
            }*/

            pictureBox1.Refresh();
        }

        private int CountNeighbor(int x, int y) 
        {
            return 0;
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;
            timer1.Stop();

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            //button1.Enabled = true;
            //button2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //resolution = (int)numericUpDown1.Value;
            //pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //graphics = Graphics.FromImage(pictureBox1.Image);
            //graphics.FillRectangle(Brushes.Crimson, 0, 0, resolution, resolution);
            StartGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopGame();
        }
    }
}
