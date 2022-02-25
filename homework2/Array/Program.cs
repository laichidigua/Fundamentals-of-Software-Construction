using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void array_analyze(double[] a, out double max, out double min, out double over, out double sum)
        {
            double max1=0, min1=0, over1=0, sum1=0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max1) max1 = a[i];
                if (a[i] < min1) min1 = a[i];
                sum1 += a[i];
            }
            max = max1;
            min = min1;
            sum = sum1;
            over = sum / a.Length;
        }
        static void Main(string[] args)
        {
            double max = 0, min = 0, over = 0, sum = 0;
            double[] array = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            array_analyze(array,out max, out min, out over, out sum);
            Console.WriteLine($"最大值为：{max}  ;最小值为：{min}  ;平均值为：{over}  ;总和：{sum}");
        }
    }
}
