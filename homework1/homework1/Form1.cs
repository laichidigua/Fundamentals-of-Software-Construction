using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1
{
    public partial class Form1 : Form
    {
        double num1, num2, num3;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            num2 = double.Parse(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            num3 = num1 -num2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num3 = num1 * num2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (num2 != 0.0)
            {
                num3 = num1 / num2;
            }
            else { textBox3.Text = "除数不能为0"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num3 = num1 + num2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "" + num3;
        }
    }
}
