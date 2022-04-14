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
    public partial class Form4 : Form
    {
        public List<OrderDetails> OrderDetails;
        public Form4()
        {
            InitializeComponent();
            OrderDetails = new List<OrderDetails>();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails.Add(new OrderDetails(Goods.goods1, Int32.Parse(textBox3.Text), 1));
            OrderDetails.Add(new OrderDetails(Goods.goods2, Int32.Parse(textBox4.Text), 1));
            OrderDetails.Add(new OrderDetails(Goods.goods3, Int32.Parse(textBox5.Text), 1));
            OrderDetails.Add(new OrderDetails(Goods.goods4, Int32.Parse(textBox6.Text), 1));
            OrderDetails.Add(new OrderDetails(Goods.goods5, Int32.Parse(textBox7.Text), 1));
            OrderDetails.Add(new OrderDetails(Goods.goods6, Int32.Parse(textBox8.Text), 1));
            this.Close();
        }
    }
}
