using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppClasses
{
    //存入表里的：id,客户id,客户姓名，创建时间，订单总价
    public class Order
    {
        public static int IdSeed = 0;

        public int Id { get; set; }//主键

        public int CustomerId { get; set; }//所属客户外键

        public Customer Customer { get; set; }//客户引用

        public string CustomerName { get => (Customer != null) ? Customer.Name : ""; }//客户姓名快捷

        public DateTime CreateTime { get; set; }//创建时间

        public List<OrderDetail> Details { get; set; }//包含的货物明细引用

        public Order()
        {
            Id = IdSeed++;
            Details = new List<OrderDetail>();
            CreateTime = DateTime.Now;
        }

        public Order(int orderId, Customer customer, List<OrderDetail> items) : this()
        {
            this.Id = orderId;
            this.Customer = customer;
            this.Details = items;
        }

        //订单总价
        public double TotalPrice
        {
            get => Details.Sum(item => item.TotalPrice);
        }

        //添加明细
        public void AddItem(OrderDetail orderItem)
        {
            if (Details.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
            Details.Add(orderItem);
        }

        //移除明细
        public void RemoveDetail(OrderDetail orderItem)
        {
            Details.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{Id}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            Details.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = -531220479;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
    }
}
