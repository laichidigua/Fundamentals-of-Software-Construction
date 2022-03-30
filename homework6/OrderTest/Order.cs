using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    //订单类，编号，客户，总金额
    [Serializable]
    public class Order:IComparable<Order>
    {
        public static int No = 0;
        public int Number { set; get; }
        public List<OrderDetails> goods;
        public Client client { set; get; }
        public double sum_money { set; get; }
        public Order()
        {
            Number = ++No;
            sum_money = 0.0;
            goods = new List<OrderDetails>();
            client = null;
        }
        public Order(Client client)
        {
            this.client = client;
            Number = ++No;
            sum_money = 0.0;
            goods = new List<OrderDetails>();
        }
        //定义排序准则,暂时没用到
        public int CompareTo(Order other) {

            if (this.sum_money < other.sum_money)
            {
                return -1;
            }
            else if (this.sum_money == other.sum_money)
            {
                return 0;
            }
            else {
                return 1;
            }
        }

        //更新总金额
        public void refresh()
        {
            this.sum_money = 0.0;
            foreach (OrderDetails orderDetails in this.goods)
            {

                this.sum_money += orderDetails.price;
            }
        }

        //更新客户信息，更改电话
        public void update(int newphone)
        {
            this.client.phone = newphone;
        }

        //添加商品，如果已有则改变数量即可，没有则新加，并更新总金额和条目金额
        public void add(Goods goods, int number = 1,double discount=1.0)
        {
           
            OrderDetails a = new OrderDetails(goods, number, discount);
            OrderDetails b = this.goods.Find(m=>m.Equals(a));
            if (b == null) {
                this.goods.Add(a);
            }
            else
            {
                b.number += number;
                b.refresh();
            }
            this.refresh();
        }

        //减少商品，有的话对应减少数量，更新金额，没的话啥也不做
        public void reduce(Goods goods, int number = 1)
        {
            OrderDetails a = new OrderDetails(goods, number, 1.0);
            OrderDetails b = this.goods.Find(m => m.Equals(a));
            if (b == null)
            {
            }
            else
            {
                b.number -= number;
                if (b.number > 0) {
                    b.refresh();
                }
                else
                {
                    this.goods.Remove(b);
                }
            }
            this.refresh();
        }

        //删除商品，找到相关商品，直接删除，更新金额
        public void delete(Goods goods)
        {
            OrderDetails a = new OrderDetails(goods, 1, 1.0);
            OrderDetails b = this.goods.Find(m => m.Equals(a));
            if (b == null)
            {
            }
            else
            {
                this.goods.Remove(b);
            }
            
            this.refresh();
        }

        //订单号相同的为同一个订单
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Order other = obj as Order;
                return this.client.name == other.client.name;
            }
            return false;
        }

        //对应的订单号为哈希吗来源
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        //包含一个商品
        public bool contain(Goods good)
        {
            return goods.Contains(new OrderDetails( good,1,1));
        }

        public override string ToString()
        {
            string c = "——————————————————————————————————————————";
            StringBuilder a = new StringBuilder();
            a.Append(c + "\n");
            a.Append($"订单编号：{Number}，" + client + "\n");
            foreach (OrderDetails b in goods)
            {
                a.Append(b + "\n");
            }
            a.Append($"总价为：{sum_money}" + "\n");
            return a.ToString();
        }
    }
}
