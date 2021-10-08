using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Net.Http;
using System.Net;
using System.IO;

namespace WPFProxyGrabber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool UseAPIs = true;
        bool UseSources1 = true;

        string ProxyScrapeS4 = "https://api.proxyscrape.com/?request=getproxies&proxytype=socks4&timeout=1000&country=All";
        string ProxyScrapeS5 = "https://api.proxyscrape.com/?request=getproxies&proxytype=socks5&timeout=1000&country=All";
        string ProxyScrapeHttp = "https://api.proxyscrape.com/?request=getproxies&proxytype=http&timeout=1000&country=All";
        string ProxyScrapeHttps = "https://api.proxyscrape.com/?request=getproxies&proxytype=https&timeout=1000&country=All";
        string ProxyListDownloadhttp = "https://www.proxy-list.download/api/v1/get?type=http&anon=elite";
        string ProxyListDownloadhttps = "https://www.proxy-list.download/api/v1/get?type=https&anon=elite";
        string ProxyListDownloadsocks4 = "https://www.proxy-list.download/api/v1/get?type=socks4&anon=elite";
        string ProxyListDownloadsocks5 = "https://www.proxy-list.download/api/v1/get?type=socks5&anon=elite";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        String APIcall(string url)
        {

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            return (Convert.ToString(data));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UseAPIs == true)
            {

                proxybox.Text = APIcall(ProxyScrapeS4);
                proxybox.Text = proxybox.Text + APIcall(ProxyScrapeHttp);
                proxybox.Text = proxybox.Text + APIcall(ProxyScrapeHttps);
                proxybox.Text = proxybox.Text + APIcall(ProxyScrapeS5);
                proxybox.Text = proxybox.Text + APIcall(ProxyListDownloadhttp);
                proxybox.Text = proxybox.Text + APIcall(ProxyListDownloadhttps);
                proxybox.Text = proxybox.Text + APIcall(ProxyListDownloadsocks4);
                proxybox.Text = proxybox.Text + APIcall(ProxyListDownloadsocks5);

            }
        }

        private void UseAPI_unchecked(object sender, RoutedEventArgs e)
        {
            UseAPIs = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UseAPIs = true;
        }

        private void UseSources_Unchecked(object sender, RoutedEventArgs e)
        {
            UseSources1 = false;
        }

        private void UseSources_Checked(object sender, RoutedEventArgs e)
        {
            UseSources1 = true;
        }

        private void LoadSources_Click(object sender, RoutedEventArgs e)
        {
            if (UseSources1 == true)
            {
                SourceTextBox.Text = "On";
            } else
            {
                SourceTextBox.Text = "OFF";
            }
        }

    }
}
