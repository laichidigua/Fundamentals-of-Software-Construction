using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simplecrawler
{
    class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //myCrawler crawler = new myCrawler();
            //string starUrl = @"http://www.cnblogs.com/dstang2000/";
            //crawler.getURLs().Add(starUrl, false);
            //crawler.Crawl(starUrl);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
