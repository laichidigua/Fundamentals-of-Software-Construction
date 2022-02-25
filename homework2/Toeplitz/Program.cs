using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeplitz
{
    class Program
    {
        static bool isToeplitz(int[,] a)
        {
            int lenth = a.GetLength(0);
            for (int i = 0; i < lenth; i++)
            {
                for (int j = 0; j < lenth; j++)
                {
                    if (i + 1 < lenth && j + 1 < lenth && a[i + 1, j + 1] != a[i, j]) return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3] { { 1, 2, 2 }, {3,1,2 }, {4,3,1 } };
            Console.WriteLine(isToeplitz(array));
        }
    }
}
