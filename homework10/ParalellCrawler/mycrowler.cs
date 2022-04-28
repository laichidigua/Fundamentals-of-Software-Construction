using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace simplecrawler
    {
        class myCrawler
        {
            private Hashtable urls = new Hashtable();
            public Hashtable getURLs() { return urls; }
            public int count = 0;
            public myCrawler() { }
            public int getCount() { return count; }
            //下载一个网页，返回网页内容字符串
            public string DownLoad(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    string fileName = count.ToString();
                    File.WriteAllText("D://test//" + count + ".txt", html, Encoding.UTF8);
                    return html;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
            //解析网页，把解析到的网址加入键值表.传入要解析的网页URL，把相对地址转化为绝对地址再丢到表里
            public void Parse(string html, string URL)
            {
                string strRef = @"(href|HREF)=[""'].*[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                int count = 0;
                foreach (Match match in matches)
                {
                    //拿出网页中的链接引用
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ' ', '>');
                    if (strRef.Length == 0) continue;
                    //只有当爬取的是html/html/aspx/jsp等网页时，才解析并爬取下一级URL
                    if (!(strRef.EndsWith("html") || strRef.EndsWith("aspx") || strRef.EndsWith("jsp"))) continue;

                    //处理得到当前目录
                    string[] strs = URL.Split('/');
                    int length = strs.Length;
                    string currentdic = "";
                    for (int i = 0; i < length - 1; i++)
                    {
                        currentdic += strs[i];
                        currentdic += @"/";
                    }
                    //处理以./开始地相对地址
                    if (strRef.StartsWith(@"./"))
                    {
                        string newurl = "";
                        newurl = currentdic + strRef.Substring(strRef.IndexOf('.') + 2);
                        if (urls[newurl] == null) { urls[newurl] = false; count++; }
                    }
                    //处理以../开始地相对地址
                    else if (strRef.StartsWith(@"../"))
                    {
                        currentdic = "";
                        string newurl = "";
                        for (int i = 0; i < length - 2; i++)
                        {
                            currentdic += strs[i];
                            currentdic += @"/";
                        }
                        newurl = currentdic + strRef.Substring(strRef.IndexOf('.') + 3);
                        if (urls[newurl] == null) { urls[newurl] = false; count++; }
                    }
                    //处理以/开始地相对地址
                    else if (strRef.StartsWith(@"/"))
                    {
                        currentdic = "";
                        for (int i = 0; i < 3; i++)
                        {
                            currentdic += strs[i];
                            currentdic += @"/";
                        }
                        string newurl = "";
                        newurl = currentdic + strRef.Substring(strRef.IndexOf('/') + 1);
                        if (urls[newurl] == null) { urls[newurl] = false; count++; }
                    }
                    //处理类似test/page.html的相对地址
                    else if (!strRef.StartsWith("http"))
                    {
                        string newurl = "";
                        newurl = currentdic + strRef;
                        if (urls[newurl] == null) { urls[newurl] = false; count++; }
                    }
                    //是绝对地址
                    else
                    {
                        if (urls[strRef] == null) { urls[strRef] = false; count++; }
                    }
                }
            }
            //爬第一个页面，并解析，爬完从键值表取一个再爬
            public void Crawl(string url1)
            {
                //从url1获取home目录
                string home = url1.Substring(url1.IndexOf('/') + 2);
                while (true)
                {
                    string current = null;
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url]) continue;
                        current = url;
                    }
                    if (current == null || count > 10) break;
                    //不包含home则检查下一个网址
                    if (!current.Contains(home)) continue;
                    //"爬取" + current + "页面!";


                    //使用Task优化速度，task1进行网页下载，task2紧接着task1进行，解析网页，往map里添加新的url
                    Task task1 = new Task(() => { DownLoad(current); });
               
                    Task task2 = task1.ContinueWith(
                                (PrevTask) => { Parse(PrevTask.Result, current); });
                    task1.Start();


                    //string html = DownLoad(current);
                    urls[current] = true;
                    count++;
                   // Parse(html, current);
                }
            }
        }
    }
