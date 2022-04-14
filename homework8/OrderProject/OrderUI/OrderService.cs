using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace OrderUI
{

    //订单服务，增加订单（不重），删除订单（有对应的就删），
    //改变订单（更新客户），用订单号查找、客户名查找、商品查找、总价查找

    public class OrderService
    {
        public static OrderService orderService = new OrderService();
        public List<Order> orders = new List<Order>();


        //该方法传入自定义排序器，按照既定排序规则对orders排序,若没有输入，则按总金额排序
        public void sort(IComparer<Order> com = null)
        {
            if (com == null) { orders.Sort(); }
            else { orders.Sort(com); }
        }


        //输出订单列表
        public string output()
        {
            if (orders.Count() == 0)
            {
                return "暂无订单";

            }
            else
            {
                var str = new StringBuilder();
                str.Append("订单列表");
                foreach (Order a in orders)
                {
                    str.Append(a + "\n");
                }
                return str.ToString();
            }
        }


        //加入订单，提供订单，加入到管理列表，重复的不加
        //加入后重新排序
        public List<Order> add_order(Order order)
        {
            if (orders.Contains(order))
            {
                Console.WriteLine("该客户已存在订单,存入管理列表失败");
                return this.orders;
            }
            orders.Add(order);
            Console.WriteLine("订单存入管理列表");
            return this.orders;

        }


        //删除订单，提供客户名，从管理列表删除，调用overide Equals，没有则抛出异常
        public bool delete_order(string name)
        {
            if (name != null)
            {
                Order order = new Order(new Client(name, 1));
                if (orders.Contains(order))
                {
                    orders.Remove(order);
                    Console.WriteLine("删除成功");
                    return true;
                }
                else
                {
                    Console.WriteLine("删除失败");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool delete_order(Order ord)
        {

            if (orders.Contains(ord))
            {
                orders.Remove(ord);
                Console.WriteLine("删除成功");
                return true;
            }
            else
            {
                Console.WriteLine("删除失败");
                return false;
            }
        }


        //改变订单列表的订单信息，提供订单，后调用该订单的updare方法，该方法只能修改客户信息如（电话号）
        public bool change_order(Order order)
        {
            if (orders.Contains(order))
            {
                orders.Remove(order);
                orders.Add(order);
                return true;
            }
            else
            {
                return false;
            }
        }


        //按订单号查询，传入订单号，输出确切的一个order
        public Order search_by_number(int number)
        {

            var result1 = orders.Where((m) => { return m.Number == number; }).OrderBy(m => m.sum_money);
            List<Order> result = result1.ToList();

            return result.First();
        }


        //按订客户查询，客户名称，输出确切的一个order
        public Order search_by_client(string name)
        {
            if (name != null)
            {
                var result1 = orders.Where((m) => { return m.client.name == name; }).OrderBy(m => m.sum_money);
                List<Order> result = result1.ToList();
                return result.First();
            }
            else
            {
                return null;
            }
        }


        //按货物查询，提供货物列表，只有包含全部货物的订单才会输出，按总金额排序
        public List<Order> search_by_goods(List<Goods> goods)
        {
            var result1 = orders.Where((m) => {
                bool find = true;
                foreach (Goods a in goods)
                {
                    if (!m.contain(a))
                    {
                        find = false;
                        break;
                    }
                }
                return find;
            }).OrderBy(m => m.sum_money);
            List<Order> result = result1.ToList();
            return result;
        }


        //按总价查询，提供总金额，大于该总金额的订单输出，按总金额排序
        public List<Order> search_by_sumPrice(double sum)
        {
            var result1 = orders.Where((m) => { return m.sum_money >= sum; }).OrderBy(m => m.sum_money);
            List<Order> result = result1.ToList();
            return result;
        }


        //将所有订单序列化为xml文件
        public bool export(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists) { directory.Create(); }
            FileInfo file = new FileInfo(directory.ToString() + Path.DirectorySeparatorChar.ToString() + "orders.xml");
            if (!file.Exists) { file.Create(); }

            using (FileStream fs = new FileStream(file.ToString(), FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
                xml.Serialize(fs, orders);
            }
            return true;

        }


        //从xml文件导入订单
        public bool import(string filepath)
        {
            FileInfo file = new FileInfo(filepath);
            if (!file.Exists)
            {
                return false;
            }
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
                List<Order> od = (List<Order>)xml.Deserialize(fs);
                Console.WriteLine("正在导入：");
                foreach (Order m in od)
                {
                    add_order(m);

                }
            }
            return true;
        }
    }
}
