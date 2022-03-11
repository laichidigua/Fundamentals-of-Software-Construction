using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T> {
    public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t) {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T> {
        private Node<T> head;
        private Node<T> tail;
        public GenericList() {
            head = tail = null;
        }
        public Node<T> Head { get => head; }
        public void Add(T t) {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> a) {
            Node<T> b=head;
            while (b != null) {
                a(b.Data);
                b = b.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            //控制台输出每个值
            list.ForEach(s => Console.WriteLine(s));
            int max = 0,min=0,sum=0;
            if (list.Head != null)
            {
                max = min = list.Head.Data;
            }
            //求出最大值
            list.ForEach(s=> { if (s > max) { max = s; } });
            //最小值
            list.ForEach(s => { if (s < min) { min = s; } });
            //求和
            list.ForEach(s => { sum += s;  });
            Console.WriteLine($"最大值：{max} 最小值：{min} 总值：{sum}");
        }
    }
}
