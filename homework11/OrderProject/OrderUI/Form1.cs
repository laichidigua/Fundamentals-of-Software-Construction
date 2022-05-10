using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OrderUI
{
    public partial class Form1 : Form
    {
        public BindingList<Order> bin;
        public Form2 form2;
        public Form3 form3;
        public Form1()
        {
            InitializeComponent();
            //将订单列表绑定到表单
            bin = new BindingList<Order>(OrderService.orderService.orders);
            bindingSource1.DataSource = bin;

            //新建添加订单页面
            form2 = new Form2();
            this.components.Add(form2);

            openFileDialog1.InitialDirectory = @"D:\__easyHelper__\orders.xml";
        }
        //查看订单明细按钮
        private void button4_Click(object sender, EventArgs e)
        {
            form3 = new Form3((Order)bindingSource1.Current);
            this.components.Add(form3);
            form3.ShowDialog();
        }


        //新建订单按钮,若发现该客户有订单存在则累计相应商品数量
        private void button2_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
            if (form2.Visible == false && form2.Order != null)
            {
                if (!bin.Contains(form2.Order))
                { bin.Add(form2.Order); }
                else {
                    foreach (Order ord in bin) {
                        if (ord.Equals(form2.Order)) {
                            foreach (OrderDetails orderDetails in form2.Order.goods) {
                                ord.add(orderDetails.goods,orderDetails.number);
                            }
                        }
                    }
                }
            }
        }


        //查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
          
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        { //按订单号查询
                            bindingSource1.DataSource = bin.Where(s => s.Number == (Int32.Parse(textBox1.Text))).ToList<Order>();
                            break;
                        }
                    case 1:
                        {//按姓名查询
                            bindingSource1.DataSource = bin.Where(s => s.client.name == textBox1.Text).ToList<Order>();
                            break;
                        }
                    case 2:
                        {//按总金额查询
                            bindingSource1.DataSource = bin.Where(s => s.sum_money >= (Double.Parse(textBox1.Text))).ToList<Order>();
                            break;
                        }
                    case 3:
                        {//按包含商品查询
                            string[] gs = textBox1.Text.Split(' ');
                            List<Goods> ls = new List<Goods>();
                            for (int i = 0; i < gs.Length; i++)
                            {
                                if (gs[i] == "农夫三拳")
                                {
                                    ls.Add(Goods.goods1);
                                    continue;
                                }
                                if (gs[i] == "雪碧")
                                {
                                    ls.Add(Goods.goods2);
                                    continue;
                                }
                                if (gs[i] == "脉动")
                                {
                                    ls.Add(Goods.goods3);
                                    continue;
                                }
                                if (gs[i] == "雀巢咖啡")
                                {
                                    ls.Add(Goods.goods4);
                                    continue;
                                }
                                if (gs[i] == "光明牛奶")
                                {
                                    ls.Add(Goods.goods5);
                                    continue;
                                }
                                if (gs[i] == "蛋炒饭")
                                {
                                    ls.Add(Goods.goods6);
                                    continue;
                                }

                            }
                            bindingSource1.DataSource = bin.Where(
                                (m) =>
                                {
                                    bool find = true;
                                    foreach (Goods a in ls)
                                    {
                                        if (!m.contain(a))
                                        {
                                            find = false;
                                            break;
                                        }
                                    }
                                    return find;
                                }
                                ).ToList<Order>();
                            break;
                        }
                    default:
                        {
                            bindingSource1.DataSource = bin;
                            break; }
                }
            
        }


        //删除按钮
        private void button3_Click(object sender, EventArgs e)
        {
            bin.Remove((Order)bindingSource1.Current);
        }


        //导出按钮
        private void button6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists) { directory.Create(); }
            FileInfo file = new FileInfo(directory.ToString() + Path.DirectorySeparatorChar.ToString() + "orders.xml");
            if (!file.Exists) { file.Create(); }

            using (FileStream fs = new FileStream(file.ToString(), FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
                xml.Serialize(fs, OrderService.orderService.orders);
            }

        }
        //导入按钮,订单重复则加对应项
        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            FileInfo file = new FileInfo(path);
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
                List<Order> od = (List<Order>)xml.Deserialize(fs);
                
                foreach (Order m in od)
                {
                    if (!bin.Contains(m))
                    { bin.Add(m); }
                    else
                    {
                        foreach (Order ord in bin)
                        {
                            if (ord.Equals(m))
                            {
                                foreach (OrderDetails orderDetails in m.goods)
                                {
                                    ord.add(orderDetails.goods, orderDetails.number);
                                }
                            }
                        }
                    }

                }
            }
            foreach (Order ord in bin) {
            }
        }
    }
}
