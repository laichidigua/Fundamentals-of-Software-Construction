using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderUI
{
    //商品类，名称、价格
    [Serializable]
    public class Goods
    {
        public static int No = 0;
        public int no;
        public static Goods goods1 = new Goods("农夫三拳", 2);
        public static Goods goods2 = new Goods("雪碧", 3);
        public static Goods goods3 = new Goods("脉动", 5);
        public static Goods goods4 = new Goods("雀巢咖啡", 7);
        public static Goods goods5 = new Goods("光明牛奶", 8);
        public static Goods goods6 = new Goods("蛋炒饭", 9);
        
        public int GoodsId { get => no; }
        public String Name { set; get; }
        public double Price { set; get; }
        public Goods()
        {
            no = No++;
            Name = "";
            Price = 0.0;
        }
        public Goods(String name, double price)
        {
            no = No++;
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
            if (other == null) { return false; }
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
