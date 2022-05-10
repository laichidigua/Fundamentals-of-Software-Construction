using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderUI
{
    //客户，编号，姓名，电话
    [Serializable]
    public class Client
    {
        public static int No = 0;
        //主键
        public int ClientId { get => no; }
        public string name { set; get; }
        public int phone { set; get; }
        public int no { set; get; }
        public Client()
        {
            no = ++No;
            name = "匿名买家";
        }
        public Client(string name, int phone)
        {
            no = ++No;
            this.name = name;
            this.phone = phone;
        }
        //客户以名称区分
        public override bool Equals(object obj)
        {
            Client other = obj as Client;
            if (other != null)
            {
                return this.name == other.name;
            }
            else {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
        public override string ToString()
        {
            return $"客户编号：{no}，姓名：{name}，电话：{phone}";
        }
    }
}
