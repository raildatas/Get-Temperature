using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace wdj
{
    public partial class Form1 : Form
    {
        bool change = false;
        string english = "";
        WebClient wc = new WebClient();
        Thread th;

        ~Form1()
        {
            wc.Dispose();
            GC.Collect();
        }
        public Form1()
        {
            InitializeComponent();
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
            if (comboBox1.SelectedIndex == 1)
            {
                tmp = (tmp - 32) * 5 / 9;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                tmp -= 273.15;
            }
            else
            {
                tmp = tmp;
            }
        r: try
            {
                if (tmp < 15 && tmp > -51)
                {
                    color = Color.FromArgb(0, 0, (int)((65 - (tmp + 50)) * 3));
                }
                else if (tmp < 26 && tmp > 14)
                {
                    color = Color.FromArgb(0, (int)((11 - (tmp - 14)) * 11) + 127, 0);
                }
                else
                {
                    color = Color.FromArgb((int)(255 - ((25 - (tmp - 14)) * 5)), 0, 0);
                }
            }
            catch
            {
                if (tmp < 123)
                    tmp = (tmp - 32) * 5 / 9;
                else
                    tmp -= 273.15;
                goto r;
            }
            GC.Collect();
            return color;
        }
        private void GetTemp()
        {
            while (true)
            {
                if (!change)
                    goto e;
                try
                {
                    string http = "https://www.ip138.com/iplookup.asp?ip=" + GetIP() + "&action=2";
                    byte[] buffer = wc.DownloadData(http);
                    string show = Encoding.Default.GetString(buffer);
                    string[] temp = show.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string city = temp[25].Substring(33, temp[25].IndexOf("市") - 33);
                    lblcity.Text = city;
                    english = PinYin.Trim(PinYin.ToLower(PinYin.RemoveAttributeChars(PinYin.ToPinYin(city))));
                }
                catch { }
                string html = "";
                r:try
                {
                    html = Encoding.UTF8.GetString(wc.DownloadData("https://www.tianqi.com/" + english + "/"));
                }
                catch
                {
                    goto r;
                }
                string[] lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int index = 152;
                string strC = lines[index].Substring(18);
                double c = double.Parse(strC.Substring(0, strC.IndexOf('<')));
                if (comboBox1.SelectedIndex == 1)
                {
                    c = c * 9 / 5 + 32;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    c += 273.15;
                }
                else
                {
                    c = c;
                }
                lbltmp.ForeColor = GetColor(c);
                lblnum.ForeColor = GetColor(c);
                lblnum.Text = c.ToString();
                index++;
                strC = lines[index].Substring(9);
                strC = strC.Substring(0, strC.IndexOf('<'));
                switch (strC)
                {
                    case "晴":
                        lblwt.ForeColor = Color.Orange;
                        break;
                    case "多云":
                        lblwt.ForeColor = Color.LightSkyBlue;
                        break;
                    case "阴":
                        lblwt.ForeColor = Color.Gray;
                        break;
                    case "雨夹雪":
                        lblwt.ForeColor = Color.Blue;
                        break;
                    default:
                        lblwt.ForeColor = Color.Black;
                        break;
                }
                lblwt.Text = strC;
                string temp2;
                index += 2;
                strC = lines[index].Substring(24);
                strC = strC.Substring(13);
                temp2 = strC.Substring(0, strC.IndexOf('<'));
                lblWind.Text = temp2.Substring(0, temp2.IndexOf(' '));
                lblWindLv.Text = temp2.Substring(temp2.IndexOf(' ') + 1);
                strC = strC.Substring(strC.IndexOf('：') + 1);
                lblzyx.Text = strC.Substring(0, strC.IndexOf('<'));
                if (lblzyx.Text.Contains("强"))
                    lblzyx.ForeColor = Color.BlueViolet;
                else
                    lblzyx.ForeColor = Color.Blue;
                e: Thread.Sleep(100);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            weatherDate.Value = DateTime.Now;
            weatherDate.MinDate = DateTime.Now;
            weatherDate.MaxDate = DateTime.Now.AddDays(39);
            Control.CheckForIllegalCrossThreadCalls = false;
            th = new Thread(GetTemp) { IsBackground = true };
            th.Start();
            try
            {
                string http = "https://www.ip138.com/iplookup.asp?ip=" + GetIP() + "&action=2";
                byte[] buffer = wc.DownloadData(http);
                string show = Encoding.Default.GetString(buffer);
                string[] temp = show.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string city = temp[25].Substring(33, temp[25].IndexOf("市") - 33);
                lblcity.Text = city;
                english = PinYin.Trim(PinYin.ToLower(PinYin.RemoveAttributeChars(PinYin.ToPinYin(city))));
            }
            catch
            {
                if (new ErrorForm().ShowDialog() == DialogResult.OK)
                {
                    english = PinYin.Trim(PinYin.ToLower(PinYin.RemoveAttributeChars(PinYin.ToPinYin(Share.city))));
                    lblcity.Text = Share.city+"市";
                }
            }
            string html = Encoding.UTF8.GetString(wc.DownloadData("https://www.tianqi.com/" + english + "/"));
            string[] lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 152;
            string strC = lines[index].Substring(18);
            double c = double.Parse(strC.Substring(0, strC.IndexOf('<')));
            lbltmp.ForeColor = GetColor(c);
            lblnum.ForeColor = GetColor(c);
            lblnum.Text = c.ToString();
            index++;
            strC = lines[index].Substring(9);
            strC = strC.Substring(0, strC.IndexOf('<'));
            switch (strC)
            {
                case "晴":
                    lblwd.ForeColor = Color.Orange;
                    break;
                case "多云":
                    lblwd.ForeColor = Color.LightSkyBlue;
                    break;
                case "阴":
                    lblwd.ForeColor = Color.Gray;
                    break;
                case "雨夹雪":
                    lblwt.ForeColor = Color.Blue;
                    break;
                default:
                    lblwd.ForeColor = Color.Black;
                    break;
            }
            lblwt.Text = strC;
            string temp2;
            index += 2;
            strC = lines[index].Substring(24);
            strC = strC.Substring(13);
            temp2 = strC.Substring(0, strC.IndexOf('<'));
            lblWind.Text = temp2.Substring(0,temp2.IndexOf(' '));
            lblWindLv.Text = temp2.Substring(temp2.IndexOf(' ')+1);
            strC = strC.Substring(strC.IndexOf('：') + 1);
            lblzyx.Text = strC.Substring(0,strC.IndexOf('<'));
            if(lblzyx.Text.Contains("强"))
                lblzyx.ForeColor = Color.BlueViolet;
            else
                lblzyx.ForeColor = Color.Blue;
            switch(lblWindLv.Text[0])
            {
                case '0':
                    lblWindLv.ForeColor = Color.Gray;
                    break;
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                    lblWindLv.ForeColor = Color.DeepSkyBlue;
                    break;
                default:
                    lblWindLv.ForeColor = Color.Red;
                    break;
            }
            try
            {
                html = Encoding.UTF8.GetString(wc.DownloadData("https://www.tianqi.com/" + english + "/40"));
                lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                strC = lines[0 * 11 + 184].Substring(21);
                lblwd.Text = strC.Substring(0, strC.IndexOf('<'));
                switch (lblwd.Text)
                {
                    case "晴":
                        lblwt.ForeColor = Color.Orange;
                        break;
                    case "多云":
                        lblwt.ForeColor = Color.LightSkyBlue;
                        break;
                    case "阴":
                        lblwt.ForeColor = Color.Gray;
                        break;
                    case "雨夹雪":
                        lblwt.ForeColor = Color.Blue;
                        break;
                    default:
                        lblwt.ForeColor = Color.Black;
                        break;
                }
                strC = lines[0 * 11 + 185].Substring(27);
                lblfrom.Text = strC.Substring(0, strC.IndexOf('<'));
                lblfrom.ForeColor = GetColor(double.Parse(strC.Substring(0, strC.IndexOf('<'))));
                strC = strC.Substring(16);
                lblto.Text = strC.Substring(0, strC.IndexOf('<'));
                lblto.ForeColor = GetColor(double.Parse(strC.Substring(0, strC.IndexOf('<'))));
                lblcd.ForeColor = GetColor(double.Parse(strC.Substring(0, strC.IndexOf('<'))));
            }
            catch { }
            change = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void weatherDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!change)
                    return;
                string html = Encoding.UTF8.GetString(wc.DownloadData("https://www.tianqi.com/" + english + "/40"));
                string[] lines = html.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string strC = lines[(weatherDate.Value - DateTime.Now).Days * 11 + 184].Substring(21);
                lblwd.Text = strC.Substring(0, strC.IndexOf('<'));
                switch (strC.Substring(0, strC.IndexOf('<')))
                {
                    case "晴":
                        lblwd.ForeColor = Color.Orange;
                        break;
                    case "多云":
                        lblwd.ForeColor = Color.LightSkyBlue;
                        break;
                    case "阴":
                        lblwd.ForeColor = Color.Gray;
                        break;
                    case "雨夹雪":
                        lblwd.ForeColor = Color.Blue;
                        break;
                    default:
                        lblwd.ForeColor = Color.Black;
                        break;
                }
                strC = lines[(weatherDate.Value - DateTime.Now).Days * 11 + 185].Substring(27);
                strC = strC.Substring(0, strC.IndexOf('<'));
                if (comboBox1.SelectedIndex == 1)
                {
                    strC = (double.Parse(strC) * 9 / 5 + 32).ToString();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    strC = (double.Parse(strC) + 273.15).ToString();
                }
                else
                {
                    strC = strC;
                }
                lblfrom.Text = strC;
                lblfrom.ForeColor = GetColor(double.Parse(strC));
                strC = lines[(weatherDate.Value - DateTime.Now).Days * 11 + 185].Substring(27);
                strC = strC.Substring(16);
                strC = strC.Substring(0, strC.IndexOf('<'));
                if (comboBox1.SelectedIndex == 1)
                {
                    strC = (double.Parse(strC) * 9 / 5 + 32).ToString();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    strC = (double.Parse(strC) + 273.15).ToString();
                }
                else
                {
                    strC = strC;
                }
                lblto.Text = strC;
                lblto.ForeColor = GetColor(double.Parse(strC));
                lblcd.ForeColor = GetColor(double.Parse(strC));
            }
            catch { }
        }
        private void lblcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!change)
                return;
            english = PinYin.Trim(PinYin.ToLower(PinYin.RemoveAttributeChars(PinYin.ToPinYin(lblcity.Text))));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblcd.Text = comboBox1.Text;
            lbltmp.Text = comboBox1.Text;
            weatherDate_ValueChanged(sender, e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
        }
    }
}