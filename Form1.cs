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

            var newField = new bool[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighborCount = CountNeighbor(x, y);
                    var neighborAlive = field[x, y];

                    if (!neighborAlive && neighborCount == 3)
                    {
                        newField[x, y] = true;  //new live
                    }
                    else if (neighborAlive && (neighborCount < 2 || neighborCount > 3))
                    {
                        newField[x, y] = false;  //death
                    }
                    else
                    {
                        newField[x, y] = field[x, y];  //life continues
                    }

                    if (neighborAlive)    //replaced (field[x, y]) with neighborAlive
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            field = newField;

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
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    //modified to (x + i + columns) % columns to get outside screen boundaries

                    int lcolumn = (x + i + columns) % columns;    //local columns and rows + global columns and rows
                    int lrow = (y + j + rows) % rows;
                    bool isSelfCheck = lcolumn == x && lrow == y;   //remove center from count

                    //all int and bool can be changed to var

                    bool neighborAlive = field[lcolumn, lrow];

                    if (neighborAlive && !isSelfCheck)
                    {
                        count++;
                    }
                }

            }

            return count;
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
