using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppClasses
{
    public class Goods
    {
        public static int IdSeed = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods()
        {
            Id=IdSeed++;
        }

        public Goods(string name, double price) : this()
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   Id == goods.Id &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id.ToString());
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
