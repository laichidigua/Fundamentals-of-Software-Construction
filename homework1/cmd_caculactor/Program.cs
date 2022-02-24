using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_caculactor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            double num1=0.0, num2=0.0, num3=0.0;
            char x;
            Console.WriteLine("请输入第一个数");
            num1 =double.Parse( Console.ReadLine());
            Console.WriteLine("请输入第二个数");
            num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入操作符：+；-；*；/");
            x = char.Parse(Console.ReadLine());
            switch (x) {
                case '+':num3 = num1 + num2;break;
                case '-': num3 = num1 - num2; break;
                case '*': num3 = num1 * num2; break;
                case '/': if (num2 != 0.0) { num3 = num1 / num2; } else { Console.WriteLine("除数不能为0");goto LABLE1; }; break;
                default: Console.WriteLine("请输入正确的操作符");break;
            }
            Console.WriteLine("结果是："+num3);
        LABLE1:
            Console.ReadLine();
        }
    }
}
