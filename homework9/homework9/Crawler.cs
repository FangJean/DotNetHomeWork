using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace homework9
{
    public class Crawler
    {
        public Hashtable urls = new Hashtable();
        public int count = 0;
        public event Action<Crawler, string, string> PageDownloaded;
        public event Action<Crawler> CrawlerStopped;
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
            urls.Add(StartUrl, false);
            //Console.WriteLine("开始爬行了");
            while (count<MaxPage)
            {
                string current = null;
                try
                {
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url]) continue;
                        current = url;
                    }
                    if (current == null) break;
                    PageDownloaded(this, current, "success");
                    //Console.WriteLine("爬行" + current + "页面！");
                    string html = DownLoad(current);
                    urls[current] = true;
                    count++;
                    Parse(html, current);
                }catch(Exception ex)
                {
                    PageDownloaded(this, current, "Error");
                }
            }
            CrawlerStopped(this);
            //Console.WriteLine("爬行结束");
        }

        private string DownLoad(string url)
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
        }
        public void Parse(string html,string url)
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
        static private string FixUrl(string url,string purl)
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
            return purl.Substring(0,purl.LastIndexOf("/")) + "/" + url;
        }
    }
}
