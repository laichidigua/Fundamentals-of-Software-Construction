using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Data.Entity;
namespace OrderUI
{

    //订单服务，增加订单（不重），删除订单（有对应的就删），
    //改变订单（更新客户），用订单号查找、客户名查找、商品查找、总价查找

    public class OrderService
    {
        public static OrderService orderService = new OrderService();
        public List<Order> orders { get {
             using (var sql = new OrderContext()) {
                    return sql.DbOrders.Include((Order o) => o.goods.Select((OrderDetails a) => a.goods)).Include("client").ToList<Order>();
             }
            }
        }

        public OrderService() {
            using (var sql = new OrderContext()) {
                if (sql.DbClients.Count() == 0) {
                    sql.DbClients.Add(new Client("kps", 132110));
                    sql.SaveChanges();
                }
                if (sql.DbGoods.Count() == 0) {
                    sql.DbGoods.Add(Goods.goods1);
                    sql.DbGoods.Add(Goods.goods2);
                    sql.DbGoods.Add(Goods.goods3);
                    sql.DbGoods.Add(Goods.goods4);
                    sql.DbGoods.Add(Goods.goods5);
                    sql.DbGoods.Add(Goods.goods6);
                    sql.SaveChanges();
                }
            }
        }

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

        //避免级联添加或修改Customer和Goods
        private static void FixOrder(Order newOrder)
        {
            newOrder.ClientId = newOrder.client.ClientId;
            newOrder.client = null;
            newOrder.goods.ForEach(d => {
                d.GoodsId = d.goods.GoodsId;
                d.goods = null;
            });
        }

        //加入订单，提供订单，加入到管理列表，重复的不加
        //加入后重新排序
        public bool add_order(Order order)
        {
            using (var sql = new OrderContext()) {
                if (!orders.Contains(order)) {
                    FixOrder(order);
                    sql.DbOrders.Add(order);
                    sql.SaveChanges();
                    return true;
                }
                return false;
            }
        }


        //删除订单
        public bool delete_order(Order ord)
        {
            using (var sql = new OrderContext()) {
                var order = sql.DbOrders.Include("goods").SingleOrDefault(o => o.OrderId == ord.OrderId);
                if (order == null) { return false; }
                sql.DbOrderDetails.RemoveRange(order.goods);
                sql.DbOrders.Remove(order);
                sql.SaveChanges();
                return true;
            }
        }


        //改变订单
        public bool change_order(Order order)
        {
            delete_order(order);
            add_order(order);
            return true;
        }


        //按订单号查询，传入订单号，输出确切的一个order
        public Order search_by_number(int number)
        {
            using (var sql = new OrderContext()) {
                return sql.DbOrders.Include(o => o.goods.Select(a => a.goods)).Include("client").SingleOrDefault(a => a.OrderId == number);
            }
        }


        //按订客户查询，客户名称，输出确切的一个order
        public Order search_by_client(string name)
        {
            using (var sql = new OrderContext())
            {
                return sql.DbOrders.Include(o => o.goods.Select(a => a.goods)).Include("client").SingleOrDefault(a => a.client.name == name);
            }
        }


        //按货物查询，提供货物列表，只有包含全部货物的订单才会输出，按总金额排序
        public List<Order> search_by_goods(List<Goods> goods)
        {
            using (var sql = new OrderContext())
            {
                return sql.DbOrders.Include(o => o.goods.Select(a => a.goods)).Include("client").Where(a =>a.contain(goods)).ToList<Order>();
            }
        }


        //按总价查询，提供总金额，大于该总金额的订单输出，按总金额排序
        public List<Order> search_by_sumPrice(double sum)
        {
            using (var sql = new OrderContext())
            {
                return sql.DbOrders.Include(o => o.goods.Select(a => a.goods)).Include("client").Where(a => a.sum_money>=sum).ToList<Order>();
            }
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
