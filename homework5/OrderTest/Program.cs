using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("aaa", 111111);
            Client client2 = new Client("bbb", 222222);
            Client client3 = new Client("ccc", 333333);
            Goods goods1 = new Goods("农夫三拳",2);
            Goods goods2 = new Goods("雪碧", 3);
            Goods goods3 = new Goods("脉动", 5);
            Goods goods4 = new Goods("雀巢咖啡", 7);
            Goods goods5 = new Goods("光明牛奶", 8);
            Goods goods6 = new Goods("蛋炒饭", 9);
            Order order1 = new Order(client1);
            Order order2 = new Order(client2);
            Order order3 = new Order(client3);

            order1.add(goods2);
            order1.add(goods1,2);
            order1.add(goods3);
            order1.add(goods4);
            order1.add(goods5);
            order2.add(goods4);
            order2.add(goods5);
            order3.add(goods3,2);
            order3.add(goods4,3);
            OrderService.add_order(order1);
            OrderService.add_order(order2);
            OrderService.add_order(order3);
            List<Order> result_by_sumPrice = OrderService.search_by_sumPrice(31);
            List<Goods> find_by_goods = new List<Goods>();
            find_by_goods.Add(goods3);
            List<Order> result_by_goods = OrderService.search_by_goods(find_by_goods);
            List<Order> result_by_client = OrderService.search_by_client("aaa");
            List<Order> result_by_number = OrderService.search_by_number(2);
            Console.WriteLine("总价大于等于31的订单有");
            foreach (Order a in result_by_sumPrice) {
                Console.WriteLine(a);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("包含货物三的订单有");
            foreach (Order a in result_by_goods)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("aaa客户的订单为");
            foreach (Order a in result_by_client)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("2号订单为");
            foreach (Order a in result_by_number)
            {
                Console.WriteLine(a);
            }
        }
    }
}
