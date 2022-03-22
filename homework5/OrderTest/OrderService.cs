using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    
    //订单服务，增加订单（不重），删除订单（有对应的就删），
    //改变订单（更新客户），用订单号查找、客户名查找、商品查找、总价查找
    
    class OrderService
    {
        public static List<Order> orders = new List<Order>();
        //该方法传入自定义排序器，按照既定排序规则对orders排序,若没有输入，则按总金额排序
        public static void sort(IComparer<Order> com = null)
        {
            if (com == null) { orders.Sort(); }
            else { orders.Sort(com); }
        }
        //输出订单列表
        public static void output() {
            if (orders.Count() == 0)
            {
                Console.WriteLine("暂无订单");

            }
            else {
                Console.WriteLine("订单列表");
                foreach (Order a in orders) {
                    Console.WriteLine(a);
                }
            }
        }
        //加入订单，提供订单，加入到管理列表，重复的不加
        //加入后重新排序

        public static void add_order(Order order)
        {
            bool already_have = false;
            foreach (Order ord in orders)
            {
                if (ord.Equals(order))
                {
                    already_have = true;
                    Console.WriteLine("该客户已存在订单,存入管理列表失败");
                    break;
                }
            }
            if (!already_have)
            {
                orders.Add(order);
                Console.WriteLine("订单存入管理列表");
            }
            orders.Sort();
        }
        //删除订单，提供订单，从管理列表删除，调用overide Equals，没有则抛出异常
        public static void delete_order(string name)
        {
            Order order = new Order(new Client(name,1));
            try
            {
                Order result=null;
                bool is_already_have = false;
                foreach (Order ord in orders)
                {
                    if (!ord.Equals(order))
                    {
                        continue;
                    }
                    is_already_have = true;
                    result = ord;
                    //orders.Remove(ord);
                }
                if (!is_already_have)
                {
                    throw new Exception("订单列表中无此订单");
                }
                else {
                    orders.Remove(result);
                    Console.WriteLine("删除成功");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            orders.Sort();
        }
        //改变订单列表的订单信息，提供订单，后调用该订单的updare方法，该方法只能修改客户信息如（电话号）
        public static void change_order(Order order)
        {
            try
            {
                bool is_already_have = false;
                foreach (Order ord in orders)
            {
                if (!ord.Equals(order))
                {
                    continue;
                }
                    is_already_have = true;
                    //ord.update(order);
            }
                if (!is_already_have)
                {
                    throw new Exception("订单列表中无此订单,故无法更改");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //按订单号查询，传入订单号，输出确切的一个order
        public static Order search_by_number(int number)
        {

            var result1 = orders.Where((m) => { return m.Number == number; }).OrderBy(m=>m.sum_money);
            List<Order> result = result1.ToList();
            
            return result.First(); 
        }
        //按订客户查询，客户名称，输出确切的一个order
        public static Order search_by_client(string name)
        {
            var result1 = orders.Where((m) => { return m.client.name == name; }).OrderBy(m => m.sum_money);
            List<Order> result = result1.ToList();
            return result.First();
        }
        //按货物查询，提供货物列表，只有包含全部货物的订单才会输出，按总金额排序
        public static List<Order> search_by_goods(List<Goods> goods)
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
        public static List<Order> search_by_sumPrice(double sum)
        {
            var result1 = orders.Where((m) => { return m.sum_money >= sum; }).OrderBy(m => m.sum_money);
            List<Order> result = result1.ToList();
            return result;
        }

    }
}
