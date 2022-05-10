using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderUI
{
    //商品，折扣，数量，总价
    [Serializable]
    public class OrderDetails
    {
        public static int No =0;
        public int no;
        //主键
        public int OrderDetailsId { get => no; }
        //所属订单外键
        public int OrderId { get; set; }
        //包含货物外键
        public int GoodsId { set; get; }
        //快捷货物名称
        public string GoodsName { get => goods == null ? "" : goods.Name; }
        public Goods goods { get; set; }
        public double discount { get; set; }
        public int number { get; set; }
        //货物价格*数量*折扣
        public double price { get=> goods.Price * this.discount * this.number;  }
        public OrderDetails()
        {
            no = No++;
            goods = null;
            discount = 1.0;
            number = 0;
          
        }
        public OrderDetails(Goods goods, int number, double discount)
        {
            no = No++;
            this.goods = goods;
            this.number = number;
            this.discount = discount;
           
        }
        //订单明细以所说明的商品区分
        public override bool Equals(object obj)
        {
            OrderDetails orderDetails = obj as OrderDetails;
            if (orderDetails == null) { return false; }
            return goods.Equals(orderDetails.goods);
        }
        public override int GetHashCode()
        {
            return this.goods.GetHashCode() + number * 100;
        }
      
        public override string ToString()
        {
            return $"商品名：{goods.Name}，单价：{goods.Price}，折扣：{discount}，数量：{number}，总价：{price}";
        }
    }
}
