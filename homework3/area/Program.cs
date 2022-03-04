using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace area
{
    class Program
    {
        static void Main(string[] args)
        {
            double Area = 0;
            //随机创建十个形状，每个输出其属性，合法才算入总面积
            for (int i = 0; i < 10; i++) {
                shape a = factory.GetShape();
                Console.WriteLine(a.detail());
                if (a.legal()) {
                    Area += a.area();
                }
            }
            Console.WriteLine($"总面积为:{Area}");
        }
    }
    //形状接口
    public interface shape {
        //接口，必须有，面积，合法，描述
        double area();
        bool legal();
        String detail();

    }
    //正方形
    public class square :shape{
        //属性
        public double Length { get; set; }
        //面积
        public double area() {
            return Length * Length;
        }
        //构造函数
        square() { Length = 0; }
        public square(double a) {
            Length = a;
        }
        //合法检验
        public bool legal() {
            return (Length != 0);
        }
        //细节描述
        public String detail() {
            return ($"正方形:边长为：{Length}");
        }

    }
    //长方形
    public class rectangle : shape {
        //属性
        public double Length { set; get; }
        public double width { set; get; }
        //面积
        public double area() {
            return Length * width;
        }
        //构造函数
        public rectangle() { Length = 0;width = 0; }
        public rectangle(double a, double b) {
            Length = a;
            width = b;
        }
        //细节描述
        public String detail()
        {
            return ($"长方形:长为：{Length}，宽为：{width}");
        }
        //合法性
        public bool legal()
        {
            return (Length != 0)&&(width!=0);
        }
    }
    //三角形
    public class triangle : shape {
        //属性
        public double Side1 { set; get; }
        public double Side2 { set; get; }
        public double Side3 { set; get; }
        //面积，海伦公式
        public double area()
        {
            if (legal())
            {
                return 1 / 4 * Math.Sqrt((Side1 + Side2 + Side3) * (Side1 + Side2 + -Side3) * (Side1 + Side3 - Side2) * (Side2 + Side3 - Side1));
            }
            else { return 0.0; }
        }
        //构造函数
        public triangle() {
            Side1 = Side2 = Side3 = 0;
        }
        public triangle(double a,double b,double c) {
            Side1 = a;
            Side2 = b;
            Side3 = c;
        }
        //细节描述
        public String detail()
        {
            if (legal())
            {
                return ($"三角形:三边为：{Side1},{Side2},{Side3}");
            }
            else { return "三角形，不合法"; }
        }
        //合法检验
        public bool legal()
        {
            return (Side1 != 0) && (Side2 != 0)&&(Side3!=0)&&(Side1+Side2>Side3) && (Side1 + Side3 > Side2) && (Side3 + Side2 > Side1);
        }
    }
    //工厂类
    public class factory {
        //对每一种输入都有对应返回
        public static shape GetShape(String a=null,double b=0,double c=0,double d=0) {
            if (a == null)
            {
                Random ran = new Random();
                double num1 = ran.NextDouble();
                double num2 = 10 * ran.NextDouble();
                double num3 = 10 * ran.NextDouble();
                double num4 = 10 * ran.NextDouble();
                //停顿一下，确保产生真随机数
                Thread.Sleep(1);
                if (num1 <= 0.33) { return new square(num2); } else if (num1 <= 0.66) { return new rectangle(num2, num3); } else { return new triangle(num2, num3, num4); }
            }
            else {
                if (a.Equals("square")) { return new square(b); }
                if (a.Equals("rectangle")) { return new rectangle(b, c); }
                if (a.Equals("triangle")) { return new triangle(b, c, d); }
            }
            return new square(0);
            
        }
    }
}
