using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    //商品类，名称、价格
    class Goods
    {
        public String Name { set; get; }
        public double Price { set; get; }
        public Goods()
        {
            Name = "";
            Price = 0.0;
        }
        public Goods(String name, double price)
        {
            if (name != null)
            {
                this.Name = name;
            }
            else
            {
                this.Name = "";
            }
            if (price <= 0)
            {
                this.Price = 0.0;
            }
            else
            {
                this.Price = price;
            }
        }
        //商品以名字区分
        public override bool Equals(object obj)
        {
            Goods other = obj as Goods;
            return this.Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"商品名：{Name}，单价：{Price}";
        }
    }
}
