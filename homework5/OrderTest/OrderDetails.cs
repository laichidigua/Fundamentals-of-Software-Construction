using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    //商品，折扣，数量，总价
    class OrderDetails
    {
        public Goods goods { get; set; }
        public double discount { get; set; }
        public int number { get; set; }
        public double price { get; set; }
        public OrderDetails()
        {
            goods = null;
            discount = 1.0;
            number = 0;
            price = 0.0;
        }
        public OrderDetails(Goods goods, int number, double discount)
        {
            this.goods = goods;
            this.number = number;
            this.discount = discount;
            this.price = this.goods.Price * this.discount * this.number;
        }
        //订单明细以所说明的商品区分
        public override bool Equals(object obj)
        {
            OrderDetails orderDetails = obj as OrderDetails;
            return goods.Equals(orderDetails.goods);
        }
        public override int GetHashCode()
        {
            return this.goods.GetHashCode() + number * 100;
        }
        public void refresh()
        {
            price = this.goods.Price * this.discount * this.number;
        }
        public override string ToString()
        {
            return $"商品名：{goods.Name}，单价：{goods.Price}，折扣：{discount}，数量：{number}，总价：{price}";
        }
    }
}
