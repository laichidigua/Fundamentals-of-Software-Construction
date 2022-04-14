using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Client client = new Client("aaa",123);
            Client client1 = new Client("bbb", 456);
            Order order = new Order(client);
            Order order1 = new Order(client1);
            order.add(Goods.goods1);
            order.add(Goods.goods2,2);
            order1.add(Goods.goods5, 4);
            OrderService.orderService.add_order(order);
            OrderService.orderService.add_order(order1);

            Client client3 = new Client("ccc", 789);
            Order order3 = new Order(client3);
            order3.add(Goods.goods1);
            order3.add(Goods.goods2);
            order3.add(Goods.goods3);
            order3.add(Goods.goods4);
            order3.add(Goods.goods5);
            OrderService.orderService.add_order(order3);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
