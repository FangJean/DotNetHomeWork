using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework9
{
    public partial class Form1 : Form
    {
        BindingSource rbs = new BindingSource();
        Crawler myCrawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            dgvResult.DataSource = rbs;
            myCrawler.PageDownloaded += CrawlerPageDownloaded;
            myCrawler.CrawlerStopped += CrawlerStopped;
        }
        private void CrawlerPageDownloaded(Crawler crawler, string url, string info)
        {
            var pageInfo = new { Index = rbs.Count + 1, URL = url, Status = info };
            Action action = () => { rbs.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void CrawlerStopped(Crawler obj)
        {
            Action action = () => lblInfo.Text = "爬虫已停止";
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            rbs.Clear();
            myCrawler.StartUrl = textBoxURL.Text;
            Match match = Regex.Match(myCrawler.StartUrl, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            myCrawler.HostFilter = "^" + host + "$";
            myCrawler.FileFilter = "((.html?|.aspx|.jsp|.php)$|^[^.]+$)";
            new Thread(myCrawler.Crawl).Start();
            lblInfo.Text = "爬虫已启动";
        }
    }
}
