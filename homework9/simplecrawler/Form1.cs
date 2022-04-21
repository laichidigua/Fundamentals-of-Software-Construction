using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simplecrawler
{
    public partial class Form1 : Form
    {
        myCrawler crawler;
        public Form1()
        {
            InitializeComponent();
            crawler = new myCrawler(this);
            textBox1.Text = @"http://www.cnblogs.com/dstang2000/";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null) {
                string starUrl =@textBox1.Text;
                crawler.getURLs().Add(starUrl, false);
                crawler.Crawl(starUrl);
            }
        }
    }
}
