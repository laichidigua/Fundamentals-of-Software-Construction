using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockEvent
{
    public partial class Form1 : Form
    {
        clock clock1;
        public bool canRing { get; set; }
        public Form1()
        {
            //初始化元素并且让时钟可响，初始化时钟：即为所有时间配备处理函数，后启动
            InitializeComponent();
            canRing = true;
            clock1 = new clock();
            clock1.Clock_tick += deal_tick;
            clock1.Clock_ring += deal_ring;
            clock1.Clock_set += deal_set;
            clock1.start();
        }
        //处理滴答，每一次滴答都会将文本内容设为tick，0.3秒后恢复
        public void deal_tick(object obj, EventArgs eventArgs)
        {
            clock a = (clock)obj;
            this.Invoke(new EventHandler(delegate { textBox1.Text = "Tick"; }));
            Thread.Sleep(300);
            this.Invoke(new EventHandler(delegate { textBox1.Text = ""; }));
        }
        //处理响，设定一直闪烁ringing字符
        public void deal_ring(object obj, EventArgs eventArgs)
        {
            clock a = (clock)obj;
            if (canRing)
            {
                this.Invoke(new EventHandler(delegate { textBox2.Text = "ringing"; }));
                Thread.Sleep(300);
                this.Invoke(new EventHandler(delegate { textBox2.Text = ""; }));
                Thread.Sleep(300);
            }
        }
        //处理时间变化，将标签内容改为时间，调用十分频繁
        public void deal_set(object obj, EventArgs eventArgs)
        {
            clock a = (clock)obj;
            this.Invoke(new EventHandler(delegate { label2.Text = $"{a.min}:{a.s}:{a.ms}"; }));
        }

        //开始按钮按下后，将时钟性质，可运行设为真
        private void button1_Click(object sender, EventArgs e)
        {
            clock1.isRun = true;
        }
        //按下结束按钮，时钟可运行为假，时钟可响为假
        private void button2_Click(object sender, EventArgs e)
        {
            canRing = false;
            clock1.isRun = false;
            //clock1.end();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //按下提交，将输入存入时钟的闹钟性质中
        private void button3_Click(object sender, EventArgs e)
        {
            clock1.Time = int.Parse(textBox3.Text);
        }
    }
    //委托类
    public delegate void ClockEventHander(object obj, EventArgs eventArgs);
    public class clock
    {
        //闹钟，分，秒，毫秒，可运行
        public int Time { get; set; }
        public int min { get; set; }
        public int s { get; set; }
        public int ms { get; set; }
        public bool isRun { get; set; }
        //滴答信号，响铃信号，时间变化信号
        public event ClockEventHander Clock_tick;
        public event ClockEventHander Clock_ring;
        public event ClockEventHander Clock_set;
        //两个线程
        Thread thread1;
        Thread thread2;
        //构造函数，将闹钟设为-1，可运行为假，时间设为0:0:0
        public clock()
        {
            Time = -1;
            min = s = ms = 0;
            isRun = false;
            thread1 = new Thread(new ThreadStart(start1));
            thread2 = new Thread(new ThreadStart(start2));
        }
        //开始，将运行，和状态检测两个线程分别启动
        public void start()
        {
            thread1.Start();
            thread2.Start();
        }
        public void end() {
            thread1.Abort();
            thread2.Abort();
        }
        //此为运行线程，当可运行时，每0.01秒将ms+1，并发送时间变化信号
        public void start1()
        {
            while (true)
            {
                while (isRun)
                {
                    if (ms == 99)
                    {
                        if (s == 59) { min++; s = 0; } else { s++; }
                        ms = 0;
                    }
                    else { ms++; }
                    Clock_set(this, null);

                    Thread.Sleep(10);
                    if (!isRun) { Thread.CurrentThread.Abort();  }
                }
                
            }
        }
        //此为检测线程，当可运行时，如果ms达到0.8秒发送滴答信号
        public void start2()
        {
            while (true)
            {
                while (isRun)
                {
                    if (ms >= 80 && ms <= 90)
                    {
                        Clock_tick(this, null);
                    }
                    if (min * 60 + s >= Time&&ms<=40)
                    {
                        Clock_ring(this, null);
                    }
                    if (!isRun) { Thread.CurrentThread.Abort(); }
                }
               // if (!isRun) { break; }
            }
        }
    }
}
