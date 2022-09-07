using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Read
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string BookUrl { get; set; } = "https://m.xbiquge.so/book/9109/";
        public List<string> html = new List<string>();
        public string NextPageUrl
        {
            get
            {
                return NextPageUrl;
            }
            set
            {
                string data = ReadHelper.getDataFromUrl(value);
                string content = ReadHelper.GetMainContent(data);
                Application.Current.Dispatcher.Invoke(delegate () { TBContent.Text = content; Data = data; });
            }
        }
        public string stringContainhtml { get; set; }
        public bool isNextPage { get; set; } = false;
        public string Data
        {
            get
            {
                return Data;
            }
            set
            {
                List<string> tags = new List<string>();
                string tagName = "a";
                tags = ReadHelper.GetTags(value, tagName);
                IEnumerable<string> next = tags.Where((tag) => { return tag.Contains("pb_next"); }); 
                IEnumerable<string> pre = tags.Where((tag) => { return tag.Contains("pb_next"); });
                foreach (var VARIABLE in next)
                {
                    html.Add(VARIABLE);
                }
                foreach (var VARIABLE in pre)
                {
                    html.Add(VARIABLE);
                }
            }
        }

        private void Windows_loaded(object sender, RoutedEventArgs e)
        {
            //Thread th = new Thread(GetWebContent);
            //th.IsBackground = true;
            //th.Start();
            if (isNextPage)
            {
                string data = ReadHelper.getDataFromUrl(NextPageUrl);
                string content = ReadHelper.GetMainContent(data);
                Application.Current.Dispatcher.Invoke(delegate () { TBContent.Text = content; Data = data; });
            }
            else
            {
                //string url = "https://m.xbiquge.so/book/9109/6516857.html";
                string url = "https://m.xbiquge.so/book/9109/10856777.html";
                string data = ReadHelper.getDataFromUrl(url);
                string content = ReadHelper.GetMainContent(data);
                Application.Current.Dispatcher.Invoke(delegate () { TBContent.Text = content; Data = data; });
            }
        }

        private void GetWebContent()
        {
            while (true)
            {
                if (isNextPage)
                {
                    string data = ReadHelper.getDataFromUrl(NextPageUrl);
                    string content = ReadHelper.GetMainContent(data);
                    Application.Current.Dispatcher.Invoke(delegate () { TBContent.Text = content; Data = data; });
                }
                else
                {
                    string url = "https://m.xbiquge.so/book/9109/6516857.html";
                    string data = ReadHelper.getDataFromUrl(url);
                    string content = ReadHelper.GetMainContent(data);
                    Application.Current.Dispatcher.Invoke(delegate () { TBContent.Text = content; Data = data; });
                }
                
                
                Thread.Sleep(5000);
            }
        }

        private void TBContent_Changed(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnNextPage_Clickes(object sender, RoutedEventArgs e)
        {
            foreach (var str in html)
            {
                string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                MatchCollection matches = Regex.Matches(str, reg, RegexOptions.IgnoreCase);
                foreach (Match item in matches)
                {
                    stringContainhtml = item.Groups[2].Value;
                }
            }
            NextPageUrl = BookUrl + stringContainhtml;
            isNextPage = true;
        }

        private void TBContent_MouseRightDown(object sender, MouseButtonEventArgs e)
        {
            scrollview.ScrollToTop();
        }

        private void TBContent_PreviewMouseRightDown(object sender, MouseButtonEventArgs e)
        {
            scrollview.ScrollToTop();
        }
    }
}
