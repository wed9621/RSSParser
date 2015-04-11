using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;

namespace RSSParcer2._0
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();
            WebClient RSS_World = new WebClient();
            RSS_World.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_World);
            RSS_World.DownloadStringAsync(new Uri("http://fakty.ua/rss_feed/world"));

            WebClient RSS_Policy = new WebClient();
            RSS_Policy.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_Policy);
            RSS_Policy.DownloadStringAsync(new Uri("http://fakty.ua/rss_feed/politics"));

            WebClient RSS_Ocations = new WebClient();
            RSS_Ocations.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_Ocations);
            RSS_Ocations.DownloadStringAsync(new Uri("http://fakty.ua/rss_feed/crime"));

            WebClient RSS_Health = new WebClient();
            RSS_Health.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_Health);
            RSS_Health.DownloadStringAsync(new Uri("http://fakty.ua/rss_feed/health"));

            WebClient RSS_Sport = new WebClient();
            RSS_Sport.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_Sport);
            RSS_Sport.DownloadStringAsync(new Uri("http://fakty.ua/rss_feed/sport"));

            InitializeComponent();
            WebClient RSS_Anekdot = new WebClient();
            RSS_Anekdot.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RSSClient_DownloadStringCompleted_Anekdot);
            RSS_Anekdot.DownloadStringAsync(new Uri("http://www.anekdot.ru/rss/export20.xml"));
        }
        void RSSClient_DownloadStringCompleted_World(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new World
                          {
                              Title_World = rss.Element("title").Value,
                              pubDate_World = rss.Element("pubDate").Value,
                              Description_World = rss.Element("description").Value
                          };
            List_World.ItemsSource = RSSData;
        }

        void RSSClient_DownloadStringCompleted_Policy(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new policy
                          {
                              Title_Policy = rss.Element("title").Value,
                              pubDate_Policy = rss.Element("pubDate").Value,
                              Description_Policy = rss.Element("description").Value
                          };
            List_Policy.ItemsSource = RSSData;
        }

        void RSSClient_DownloadStringCompleted_Ocations(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new ocations
                          {
                              Title_Ocations = rss.Element("title").Value,
                              pubDate_Ocations = rss.Element("pubDate").Value,
                              Description_Ocations = rss.Element("description").Value
                          };
            List_Ocations.ItemsSource = RSSData;
        }
        void RSSClient_DownloadStringCompleted_Health(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new health
                          {
                              Title_Health = rss.Element("title").Value,
                              pubDate_Health = rss.Element("pubDate").Value,
                              Description_Health = rss.Element("description").Value
                          };
            List_Health.ItemsSource = RSSData;
        }
        void RSSClient_DownloadStringCompleted_Sport(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new sport
                          {
                              Title_Sport = rss.Element("title").Value,
                              pubDate_Sport = rss.Element("pubDate").Value,
                              Description_Sport = rss.Element("description").Value
                          };
            List_Sport.ItemsSource = RSSData;
        }
        void RSSClient_DownloadStringCompleted_Anekdot(object sender, DownloadStringCompletedEventArgs e)
        {
            var RSSData = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new anekdot
                          {
                              Title_anekdot = rss.Element("title").Value,
                              pubDate_anekdot = rss.Element("pubDate").Value,
                              Description_anekdot = rss.Element("description").Value
                          };
            List_Anekdot.ItemsSource = RSSData;
        }
    }
}