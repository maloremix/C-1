using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleArr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static void Solution(double[,] mass)
        {
            int size = mass.GetLength(0);
            double b;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (mass[i, 0] > mass[j, 0])
                    {
                        for (int k = 0; k < size; k++)
                        {
                            b = mass[i, k];
                            mass[i, k] = mass[j, k];
                            mass[j, k] = b;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            int.TryParse(textBox1.Text, out n);
            Random rand = new Random();
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rand.NextDouble() * 100;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount;
            double[,] mass = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mass[i, j] = (double)dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            Solution(mass);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mass[i, j];
                }
            }
        }
    }
}
