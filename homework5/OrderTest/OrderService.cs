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
        //加入订单，提供订单，加入到管理列表，重复的不加
        public static void add_order(Order order)
        {
            bool already_have = false;
            foreach (Order ord in orders)
            {
                if (ord.Equals(order))
                {
                    already_have = true;
                    break;
                }
            }
            if (!already_have)
            {
                orders.Add(order);
            }
        }
        //删除订单，提供订单，从管理列表删除，调用overide Equals，没有则什么也不干
        public static void delete_order(Order order)
        {
            foreach (Order ord in orders)
            {
                if (!ord.Equals(order))
                {
                    continue;
                }
                orders.Remove(ord);
            }
        }
        //改变订单列表的订单信息，提供订单，后调用该订单的updare方法，该方法只能修改客户信息如（电话号）
        public static void change_order(Order order)
        {
            foreach (Order ord in orders)
            {
                if (!ord.Equals(order))
                {
                    continue;
                }
                ord.update(order);
            }
        }
        //按订单号查询，传入订单号，输出包含该订单号订单的List<Order>
        public static List<Order> search_by_number(int number)
        {

            var result1 = orders.Where((m) => { return m.Number == number; });
            List<Order> result = result1.ToList();
            return result;
        }
        //按订客户查询，客户名称，输出该客户的List<Order>
        public static List<Order> search_by_client(string name)
        {
            var result1 = orders.Where((m) => { return m.client.name == name; });
            List<Order> result = result1.ToList();
            return result;
        }
        //按货物查询，提供货物列表，只有包含全部货物的订单才会输出
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
            });
            List<Order> result = result1.ToList();
            return result;
        }
        //按总价查询，提供总金额，大于该总金额的订单输出
        public static List<Order> search_by_sumPrice(double sum)
        {
            var result1 = orders.Where((m) => { return m.sum_money >= sum; });
            List<Order> result = result1.ToList();
            return result;
        }

    }
}
