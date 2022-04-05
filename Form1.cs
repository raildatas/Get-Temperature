using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wdj
{
    public partial class Form1 : Form
    {
        string english = "";
        WebClient wc = new WebClient();

        public Form1()
        {
            InitializeComponent();
        }
        ~Form1()
        {
            wc.Dispose();
            GC.Collect();
        }

        private string GetIP()
        {
            string pageHtml = string.Empty;
            try
            {
                using (WebClient MyWebClient = new WebClient())
                {
                    Encoding encode = Encoding.GetEncoding("gbk");
                    MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36");
                    MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                    Byte[] pageData = MyWebClient.DownloadData("http://www.net.cn/static/customercare/yourip.asp"); //从指定网站下载数据
                    pageHtml = encode.GetString(pageData);
                }
            }
            catch { }
            string reg = @"(?:(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))\.){3}(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))";
            string ip = "";
            Match m = Regex.Match(pageHtml, reg);
            if (m.Success)
            {
                ip = m.Value;
            }
            return ip;
        }
        private Color GetColor(double tmp)
        {
            Color color = new Color();
            if(tmp < 15&&tmp > -51)
            {
                color = Color.FromArgb(0, 0, (int)((65 - (tmp + 50)) * 3));
            }
            else if(tmp < 26&&tmp >14)
            {
                color = Color.FromArgb(0, (int)((11 - (tmp - 14)) * 11)+127, 0);
            }
            else
            {
                color = Color.FromArgb((int)(255-((25 - (tmp - 14)) * 5)), 0, 0);
            }
            GC.Collect();
            return color;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string html = wc.DownloadString("https://www.tianqi.com/" + english + "/");
            string[] lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // <p class="now"><b>25</b><i>℃</i></p>
            string regex = "<p class=\"now\"><b>\\d</b><i>℃</i></p>";
            Regex r = new Regex("\\t\\t\\t\\t<p class=\"now\"><b>\\d</b><i>℃</i></p>");
            int index = 152;
            int s = regex.IndexOf("\\d");
            int l = regex.LastIndexOf("</b>") - regex.IndexOf("\\d");
            string strC = lines[index].Substring(s, l);
            double c = double.Parse(strC);
            lbltmp.ForeColor = GetColor(c);
            lblnum.ForeColor = GetColor(c);
            lblnum.Text = c.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string http = "https://www.ip138.com/iplookup.asp?ip=" + GetIP() + "&action=2";
            byte[] buffer = wc.DownloadData(http);
            string show = Encoding.Default.GetString(buffer);
            string[] temp = show.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string city = temp[25].Substring(33, temp[25].IndexOf("市") - 33);
            lblcity.Text = city;
            english = PinYin.Trim(PinYin.ToLower(PinYin.RemoveAttributeChars(PinYin.ToPinYin(city))));
            string html = wc.DownloadString("https://www.tianqi.com/" + english + "/");
            string[] lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // <p class="now"><b>25</b><i>℃</i></p>
            string regex = "<p class=\"now\"><b>\\d</b><i>℃</i></p>";
            Regex r = new Regex("\\t\\t\\t\\t<p class=\"now\"><b>\\d</b><i>℃</i></p>");
            int index = 152;
            int s = regex.IndexOf("\\d");
            int l = regex.LastIndexOf("</b>") - regex.IndexOf("\\d");
            string strC = lines[index].Substring(s, l);
            double c = double.Parse(strC);
            lbltmp.ForeColor = GetColor(c);
            lblnum.ForeColor = GetColor(c);
            lblnum.Text = c.ToString();
        }
    }
}