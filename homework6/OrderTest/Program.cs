using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderTest
{
    //class myComparator : IComparer<Order> {
    //    public int Compare(Order a, Order b) {
    //        return a.goods.Count().CompareTo(b.goods.Count());
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            //Goods goods1 = new Goods("农夫三拳", 2);
            //Goods goods2 = new Goods("雪碧", 3);
            //Goods goods3 = new Goods("脉动", 5);
            //Goods goods4 = new Goods("雀巢咖啡", 7);
            //Goods goods5 = new Goods("光明牛奶", 8);
            //Goods goods6 = new Goods("蛋炒饭", 9);
            //Client client1 = new Client("aaa", 111111);
            //Client client2 = new Client("bbb", 222222);
            //Client client3 = new Client("ccc", 333333);

            //Order order1 = new Order(client1);
            //Order order2 = new Order(client2);
            //Order order3 = new Order(client3);

            //order1.add(goods2);
            //order1.add(goods1, 2);
            //order1.add(goods3);
            //order1.add(goods4);
            //order1.add(goods5);
            //order2.add(goods4);
            //order2.add(goods5);
            //order3.add(goods3, 2);
            //order3.add(goods4, 3);
            //order3.add(goods5);
            //OrderService.add_order(order1);
            //OrderService.add_order(order2);
            //OrderService.add_order(order3);
            //OrderService.export("D:\\test");
            //Console.WriteLine("存储成功");
            //OrderService.import("D:\\test\\orders.xml");
            //Console.WriteLine("导入成功");
            Console.WriteLine("1：添加订单");
            Console.WriteLine("2：删除订单");
            Console.WriteLine("3：更改订单");
            Console.WriteLine("4：查询订单");
            Console.WriteLine("5：输出订单列表");
            Console.WriteLine("6：导入订单");
            Console.WriteLine("7：存储订单");
            Console.WriteLine("8：退出系统");

            int a1 = 0;
            while ((a1 = int.Parse(Console.ReadLine())) != 8) {
                switch (a1) {
                    case 1: {
                            Console.WriteLine("请输入客户姓名");
                            string name = Console.ReadLine();
                            Console.WriteLine("请输入客户电话");
                            int phone = int.Parse(Console.ReadLine());
                            Client client = new Client(name, phone);
                            Order order = new Order(client);
                            Console.WriteLine("创建成功");
                            Console.WriteLine("1.添加商品");
                            //Console.WriteLine("2.删除商品");
                            int a2 = int.Parse(Console.ReadLine());
                            switch (a2) {
                                case 1: {
                                        Console.WriteLine("1:农夫山泉，2元");
                                        Console.WriteLine("2:雪碧，3元");
                                        Console.WriteLine("3:脉动，5元");
                                        Console.WriteLine("4:雀巢咖啡，7元");
                                        Console.WriteLine("5:光明牛奶，8元");
                                        Console.WriteLine("6:蛋炒饭，9元");
                                        Console.WriteLine("7:取消添加");
                                        int a3 = 0;
                                        int number = 1;
                                        Console.WriteLine("请输入商品号");
                                        while ((a3 = int.Parse(Console.ReadLine())) != 7) {
                                            switch (a3) {
                                                case 1:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods1, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                case 2:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods2, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                case 3:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods3, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                case 4:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods4, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                case 5:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods5, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                case 6:
                                                    Console.WriteLine("请输入数量");
                                                    number = int.Parse(Console.ReadLine());
                                                    order.add(Goods.goods6, number);
                                                    Console.WriteLine("添加成功");
                                                    break;
                                                default: Console.WriteLine("请输入商品号"); break;
                                            }
                                            Console.WriteLine("1:农夫山泉，2元");
                                            Console.WriteLine("2:雪碧，3元");
                                            Console.WriteLine("3:脉动，5元");
                                            Console.WriteLine("4:雀巢咖啡，7元");
                                            Console.WriteLine("5:光明牛奶，8元");
                                            Console.WriteLine("6:蛋炒饭，9元");
                                            Console.WriteLine("7:取消添加");
                                        }
                                        Console.WriteLine("订单初始化完成");
                                        OrderService.add_order(order);

                                        break;
                                }

                                default: break;
                            }
                            break; }
                    case 2:
                        {
                            Console.WriteLine("请输入客户姓名");
                            string client_name = Console.ReadLine();
                            OrderService.delete_order(client_name);
                            break;
                        }
                    case 3: {
                            Console.WriteLine("请输入客户姓名");
                            string client_name = Console.ReadLine();
                            Order order = OrderService.search_by_client(client_name);
                            if (order == null)
                            {
                                Console.WriteLine("无该客户订单");
                                break;
                            }
                            else {
                                
                                Console.WriteLine("1.添加商品");
                                Console.WriteLine("2.删除商品");
                                Console.WriteLine("3.更改客户电话");
                                Console.WriteLine("4.退出");
                                int a2 = 0;
                                while ((a2 = int.Parse(Console.ReadLine())) != 4) {
                                    switch (a2)
                                    {
                                       case 1:
                                            {
                                                Console.WriteLine("1:农夫山泉，2元");
                                                Console.WriteLine("2:雪碧，3元");
                                                Console.WriteLine("3:脉动，5元");
                                                Console.WriteLine("4:雀巢咖啡，7元");
                                                Console.WriteLine("5:光明牛奶，8元");
                                                Console.WriteLine("6:蛋炒饭，9元");
                                                Console.WriteLine("7:取消添加");
                                                int a3 = 0;
                                                int number = 1;
                                                Console.WriteLine("请输入商品号");
                                                while ((a3 = int.Parse(Console.ReadLine())) != 7)
                                                {
                                                    switch (a3)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods1, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods2, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods3, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods4, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        case 5:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods5, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        case 6:
                                                            Console.WriteLine("请输入数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.add(Goods.goods6, number);
                                                            Console.WriteLine("添加成功");
                                                            break;
                                                        default: Console.WriteLine("请输入商品号"); break;
                                                    }
                                                    Console.WriteLine("1:农夫山泉，2元");
                                                    Console.WriteLine("2:雪碧，3元");
                                                    Console.WriteLine("3:脉动，5元");
                                                    Console.WriteLine("4:雀巢咖啡，7元");
                                                    Console.WriteLine("5:光明牛奶，8元");
                                                    Console.WriteLine("6:蛋炒饭，9元");
                                                    Console.WriteLine("7:取消添加");
                                                }
                                                Console.WriteLine("订单初始化完成");
                                                OrderService.add_order(order);

                                                break;
                                            }
                                        case 2: {
                                                Console.WriteLine("当前客户订单状态");
                                                Console.WriteLine(order);
                                                Console.WriteLine("1:农夫山泉，2元");
                                                Console.WriteLine("2:雪碧，3元");
                                                Console.WriteLine("3:脉动，5元");
                                                Console.WriteLine("4:雀巢咖啡，7元");
                                                Console.WriteLine("5:光明牛奶，8元");
                                                Console.WriteLine("6:蛋炒饭，9元");
                                                Console.WriteLine("7:取消删除");
                                                int a3 = 0;
                                                int number = 1;
                                                Console.WriteLine("请输入要删除的商品号");
                                                while ((a3 = int.Parse(Console.ReadLine())) != 7)
                                                {
                                                    switch (a3)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods1, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods2, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods3, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods4, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        case 5:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods5, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        case 6:
                                                            Console.WriteLine("请输入要删除的数量");
                                                            number = int.Parse(Console.ReadLine());
                                                            order.reduce(Goods.goods6, number);
                                                            Console.WriteLine("删除成功");
                                                            break;
                                                        default: Console.WriteLine("请输入要删除的商品号"); break;
                                                    }
                                                    Console.WriteLine("1:农夫山泉，2元");
                                                    Console.WriteLine("2:雪碧，3元");
                                                    Console.WriteLine("3:脉动，5元");
                                                    Console.WriteLine("4:雀巢咖啡，7元");
                                                    Console.WriteLine("5:光明牛奶，8元");
                                                    Console.WriteLine("6:蛋炒饭，9元");
                                                    Console.WriteLine("7:取消删除");
                                                }
                                                break;

                                            }
                                        case 3: {
                                                Console.WriteLine("请输入新电话号");
                                                int new_phone = int.Parse(Console.ReadLine());
                                                order.update(new_phone);
                                                Console.WriteLine("修改成功");
                                                break;
                                            }
                                        default: break;
                                    }
                                    Console.WriteLine("1.添加商品");
                                    Console.WriteLine("2.删除商品");
                                    Console.WriteLine("3.更改客户电话");
                                    Console.WriteLine("4.退出");
                                }
                            }
                            break; }
                    case 4: {
                            Console.WriteLine("1：查询指定订单号订单");
                            Console.WriteLine("2：查询指定客户订单");
                            Console.WriteLine("3：查询含有特定商品的订单");
                            Console.WriteLine("4：查询总金额大于某个值的订单");
                            Console.WriteLine("5：退出");
                            int a4 = 0;
                            while ((a4 = int.Parse(Console.ReadLine())) != 5) {
                                switch (a4) {
                                    case 1: {
                                            Console.WriteLine("请输入订单号");
                                            int No = int.Parse(Console.ReadLine());
                                            Console.WriteLine(OrderService.search_by_number(No));
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("请输入客户姓名");
                                            Console.WriteLine(OrderService.search_by_client(Console.ReadLine()));
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("请选择所包含的商品");
                                            Console.WriteLine("1:农夫山泉");
                                            Console.WriteLine("2:雪碧");
                                            Console.WriteLine("3:脉动");
                                            Console.WriteLine("4:雀巢咖啡");
                                            Console.WriteLine("5:光明牛奶");
                                            Console.WriteLine("6:蛋炒饭");
                                            Console.WriteLine("7:完成选择");
                                            List<Goods> listgoods = new List<Goods>();
                                            int a3 = 0;
                                            while ((a3 = int.Parse(Console.ReadLine())) != 7)
                                            {
                                                switch (a3)
                                                {
                                                    case 1:
                                                        listgoods.Add(Goods.goods1);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    case 2:
                                                        listgoods.Add(Goods.goods2);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    case 3:
                                                        listgoods.Add(Goods.goods3);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    case 4:
                                                        listgoods.Add(Goods.goods4);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    case 5:
                                                        listgoods.Add(Goods.goods5);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    case 6:
                                                        listgoods.Add(Goods.goods6);
                                                        Console.WriteLine("选择成功");
                                                        break;
                                                    default: Console.WriteLine("请输入商品号"); break;
                                                }
                                                Console.WriteLine("1:农夫山泉");
                                                Console.WriteLine("2:雪碧");
                                                Console.WriteLine("3:脉动");
                                                Console.WriteLine("4:雀巢咖啡");
                                                Console.WriteLine("5:光明牛奶");
                                                Console.WriteLine("6:蛋炒饭");
                                                Console.WriteLine("7:完成选择");
                                            }
                                            List<Order> result_by_listgoods = OrderService.search_by_goods(listgoods);
                                            Console.WriteLine("包含指定商品的订单如下");
                                            foreach (Order a in result_by_listgoods)
                                            {
                                                Console.WriteLine(a);
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("请输入金额值");
                                            int sum = int.Parse(Console.ReadLine());
                                            List<Order> result_by_sum = OrderService.search_by_sumPrice(sum);
                                            foreach (Order a in result_by_sum)
                                            {
                                                Console.WriteLine(a);
                                            }
                                            break;
                                        }
                                }
                                Console.WriteLine("1：查询指定订单号订单");
                                Console.WriteLine("2：查询指定客户订单");
                                Console.WriteLine("3：查询含有特定商品的订单");
                                Console.WriteLine("4：查询总金额大于某个值的订单");
                                Console.WriteLine("5：退出");
                            }
                            break; }
                    case 5: {
                            Console.WriteLine(OrderService.output());
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("请输入存储订单的xml文件完整路径，用//代表/");
                            String outside_orders = Console.ReadLine();
                            OrderService.import(outside_orders);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("请输入要存储的文件夹路径，注意是文件夹，用//代表/");
                            String outside_orders = Console.ReadLine();
                            OrderService.export(outside_orders);
                            break;
                        }
                    default:
                        Console.WriteLine("请输入【1，7】中的数字");
                        break;
                }
                Console.WriteLine("1：添加订单");
                Console.WriteLine("2：删除订单");
                Console.WriteLine("3：更改订单");
                Console.WriteLine("4：查询订单");
                Console.WriteLine("5：输出订单列表");
                Console.WriteLine("6：导入订单");
                Console.WriteLine("7：存储订单");
                Console.WriteLine("8：退出系统");
            }

            // //按商品数量排序
            // OrderService.sort(new myComparator());
            ////默认排序
            //OrderService.sort(( p1, p2)=> { return Math.Sign(p1.Number-p2.Number); });

            // OrderService.output();
        }
    }
}
