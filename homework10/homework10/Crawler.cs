using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace homework10
{
    public class Crawler
    {
        public Hashtable urls = new Hashtable();
        public int count = 0;
        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler, string, string> PageDownloaded;
        private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();
        public int MaxPage { get; set; }
        public string FileFilter { get; set; }
        public string HostFilter { get; set; }
        public string StartUrl { get; set; }
        public static readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        public void Crawl()
        {
            MaxPage = 20;
            urls.Clear();
            pending = new ConcurrentQueue<string>();
            pending.Enqueue(StartUrl);
            List<Task> tasks = new List<Task>();
            int completedCount = 0;//已完成的任务数
            PageDownloaded += (crawler, url, info) => { completedCount++; };
            //Console.WriteLine("开始爬行了");
            while (count < MaxPage)
            {
                if (!pending.TryDequeue(out string url))
                {
                    if (completedCount < tasks.Count)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                int index = tasks.Count;
                Task task = Task.Run(() => DownloadAndParse(url, index));
                tasks.Add(task);
            }
            CrawlerStopped(this);
            //Console.WriteLine("爬行结束");
        }
        private void DownloadAndParse(string url, int index)
        {
        //string current = null;
            try
            {
                string html = DownLoad(url, index);
                urls[url] = true;
                Parse(html, url);
                PageDownloaded(this, url, "success");
                //Console.WriteLine("爬行" + current + "页面！");
            }
            catch (Exception ex)
            {
                PageDownloaded(this, url, "Error");
            }
        }
        private string DownLoad(string url, int index)
        {
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            File.WriteAllText(index + ".html", html, Encoding.UTF8);
            return html;
        }
        /*private string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }*/
        public void Parse(string html, string url)//?
        {
            //string strRef = @"(href|HREF)[]*=[][""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                //strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');

                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                linkUrl = FixUrl(linkUrl, url);
                if (urls[linkUrl] == null) urls[linkUrl] = false;
            }
        }
        static private string FixUrl(string url, string purl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("/"))
            {
                Match match = Regex.Match(purl, urlParseRegex);
                string site = match.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }
            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), purl);
            }
            return purl.Substring(0, purl.LastIndexOf("/")) + "/" + url;
        }
    }
}

