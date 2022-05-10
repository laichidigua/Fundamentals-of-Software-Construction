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
    public partial class Form3 : Form
    {
        public Order curOrder;
        public BindingList<OrderDetails> bin;
        public Form4 form4;
        public Form3()
        {
            InitializeComponent();
            curOrder = null;
            //form4 = new Form4();
            //this.components.Add(form4);
        }
        public Form3(Order ord)
        {
            InitializeComponent();
            curOrder = ord;
            if (curOrder != null) {
                bin = new BindingList<OrderDetails>(curOrder.goods);
                bindingSource1.DataSource = bin;
            }
        }
        //添加商品
        private void button1_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            this.components.Add(form4);
            form4.ShowDialog();
            if (form4.Visible == false) {
                foreach (OrderDetails orderDetails in form4.OrderDetails) {
                    if (!bin.Contains(orderDetails))
                    {
                        bin.Add(orderDetails);
                    }
                    foreach (OrderDetails a in bin) {
                        if (a.Equals(orderDetails)) {
                            a.number += orderDetails.number;

                        }
                    }
                }
            }

        }
        //删除明细
        private void button2_Click(object sender, EventArgs e)
        {
            bin.Remove((OrderDetails)bindingSource1.Current);

        }
    }
}
