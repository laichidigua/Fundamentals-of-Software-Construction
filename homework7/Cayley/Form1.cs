using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public double th1 { set; get; }
        public double th2 { set; get; }
        
        Pen pen;
        public int n { set; get; }
        public double per1 { set; get; }
        public double per2 { set; get; }
        public double length { set; get; }

        void drawCayleyTree(int n ,double x0, double y0, double leng, double th) {
            if (n == 0) { return; }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n-1,x1,y1,per1*leng,th+th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1) {
            if (x1 > this.Size.Width || y1 > this.Size.Height) {
                graphics.DrawLine(pen, (int)x0, (int)y0, this.Size.Width, this.Size.Height);
            }
            graphics.DrawLine(pen,(int)x0,(int)y0,(int)x1,(int)y1);
        }
        void setColor(Color color) {
            pen.Color = color;
        }
        public Form1()
        {
            InitializeComponent();
            th1 = 30 * Math.PI / 180;
            th2 = 20 * Math.PI / 180;
            n = 10;
            per1 = 0.6;
            per2 = 0.7;
            length = 100;
            graphics =panel2.CreateGraphics();
            pen = new Pen(Color.Black);
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Int32.Parse(textBox1.Text);
                length = Double.Parse(textBox2.Text);
                per1 = Double.Parse(textBox3.Text);
                per2 = Double.Parse(textBox4.Text);
                th1 = Double.Parse(textBox5.Text) * Math.PI / 180;
                th2 = Double.Parse(textBox6.Text) * Math.PI / 180;
            }
            catch (Exception E) {
                Console.WriteLine("请输入指定类型" );
            }
            switch (comboBox1.Text) {
                case "黑色": {
                        pen.Color = Color.Black;
                        break;
                    }
                case "橘色":
                    {
                        pen.Color = Color.Orange;
                        break;
                    }
                case "粉色":
                    {
                        pen.Color = Color.Pink;
                        break;
                    }
                case "蓝色":
                    {
                        pen.Color = Color.Blue;
                        break;
                    }
                case "黄色":
                    {
                        pen.Color = Color.Yellow;
                        break;
                    }
                case "红色":
                    {
                        pen.Color = Color.Red;
                        break;
                    }
                case "绿色":
                    {
                        pen.Color = Color.Green;
                        break;
                    }
                case "青色":
                    {
                        pen.Color = Color.Cyan;
                        break;
                    }
                case "灰色":
                    {
                        pen.Color = Color.Gray;
                        break;
                    }

                default:
                    {
                        pen.Color = Color.Black;
                        break;
                    }
            }
            graphics.Clear(Color.White);
            drawCayleyTree(n,260,410,length,-Math.PI/2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
