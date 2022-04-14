using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderUI
{
    public partial class Form2 : Form
    {
        public Order Order;
        public Form2()
        {
            InitializeComponent();
            Order = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Order = new Order(new Client(textBox1.Text, Int32.Parse(textBox2.Text)));
            Order.add(Goods.goods1, Int32.Parse(textBox3.Text));
            Order.add(Goods.goods2, Int32.Parse(textBox4.Text));
            Order.add(Goods.goods3, Int32.Parse(textBox5.Text));
            Order.add(Goods.goods4, Int32.Parse(textBox6.Text));
            Order.add(Goods.goods5, Int32.Parse(textBox7.Text));
            Order.add(Goods.goods6, Int32.Parse(textBox8.Text));
            this.Close();
        }
    }
}
