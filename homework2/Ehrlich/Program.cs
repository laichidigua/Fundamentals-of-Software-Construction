using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehrlich
{
    class Program
    {
        static void isPrime(ref bool[] a)
        {
            for (int i = 2; i <= 100; i++)
            {
                if (a[i-1] == false)
                {
                    for (int k = 2; k * i <= 100; k++)
                    {
                        if (a[k * i - 1] == false)
                        {
                            a[k * i - 1] = true;
                        }
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            bool[] array = new bool[100];
            isPrime(ref array);
            for (int j = 1; j < 100; j++)
            {
                if (array[j] == false)
                {
                    Console.Write(j+1+ " ");
                }
            }
        }
    }
}
