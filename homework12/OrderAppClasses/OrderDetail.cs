using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppClasses
{
    //存在表里的：id,所在订单id，包含货物id，货物名称，货物单价，数量，条目总价。另包含对货物的引用
    public class OrderDetail
    {
        public static int IdSeed = 0;
        
        public int Id { get; set; }//主键

        public int Index { get; set; } //序号

        public int GoodsId { get; set; }//包含的货物外键

        public Goods GoodsItem { get; set; }//货物的引用

        public String GoodsName { get => GoodsItem != null ? this.GoodsItem.Name : ""; }//货物名称的快捷

        public double UnitPrice { get => GoodsItem != null ? this.GoodsItem.Price : 0.0; }//货物单价

        public int OrderId;//所在的订单外键

        public int Quantity { get; set; }//数量

        public OrderDetail()
        {
            Id = IdSeed++;
        }

        public OrderDetail(int index, Goods goods, int quantity)
        {
            this.Index = index;
            this.GoodsItem = goods;
            this.Quantity = quantity;
        }

        //货物总价
        public double TotalPrice
        {
            get => GoodsItem == null ? 0.0 : GoodsItem.Price * Quantity;
        }

        public override string ToString()
        {
            return $"[No.:{Index},goods:{GoodsName},quantity:{Quantity},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null &&
                   GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
