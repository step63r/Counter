using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counter
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public int counter;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            CalcCount(counter, label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            counter = 0;
            CalcCount(counter, label1);
        }

        public void CalcCount(int i, Label l)
        {
            l.Text = counter.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GetAsyncKeyState(Keys.Enter) < 0)
            {
                counter += 1;
                CalcCount(counter, label1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter += 1;
            CalcCount(counter, label1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
