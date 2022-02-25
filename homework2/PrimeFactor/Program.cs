using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactor
{
    class Program
    {
        static int[] AllPrimeFactor(int n)
        {
            int[] result = new int[20];
            int k = 0;
            
                while (n % 2 == 0)
                {
                    n = n / 2;
                    result[k++] = 2;
                }
            
            for (int i = 3; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    n = n / i;
                    result[k++] = i;
                }
               
            }
  
            return result;
        }
        static void Main(string[] args)
        {
            int number = 0;
            int[] result = new int[20];
            Console.WriteLine("请输入一个正整数");
            number = int.Parse(Console.ReadLine());
            result=AllPrimeFactor(number);
            for (int i = 0; i < 20; i++)
            {
                if (result[i] != 0)
                {
                    Console.Write("" + result[i] + " ");
                }
            }

        }
    }
}
