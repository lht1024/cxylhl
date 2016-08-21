using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using cxylhl.Models;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Notifications;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace cxylhl
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static int year;
        public static int month;
        public static int day;
        public static DayOfWeek dayofweek;

        public static int Num;
        public static List<Thing> eventArr;
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Page_GoBack;
            year = DateTime.Today.Year;
            month = DateTime.Today.Month;
            day = DateTime.Today.Day;
            //month = 2;
            //day = 14;
            dayofweek = DateTime.Today.DayOfWeek;
            MyFrame.Navigate(typeof(Page1));
            TileUpdate();
        }

        private void Page_GoBack(object sender, BackRequestedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                MyBar.Visibility = Visibility.Visible;
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page2));
        }

        private void DaySelect_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page3));
        }

        private void TileUpdate()
        {
            string[] Mynote = new string[] { "单身恒久远", "光棍永流传", "说好的妹子呢", "每逢佳节倍思春" };
            string[] Mysug = new string[] { "但愿人长久", "光棍不再有", "天上掉下个林妹妹", "神啊，赐我个妹子吧" };

            string[] Mynote1 = new string[] { "烧死那对异性恋", "入团保平安", "脱团火葬场", "烧！烧！烧！" };
            string[] Mysug1 = new string[] { "我捐4升汽油", "壮哉我大FFF团", "壮哉我大FFF团", "异端审判" };
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueueForWide310x150(true);
            updater.EnableNotificationQueueForSquare150x150(true);
            updater.EnableNotificationQueueForSquare310x310(true);
            updater.EnableNotificationQueue(true);
            updater.Clear();

            if ((day != 14 && month != 2) && (day != 11 && month != 11))
            {
                for (int i = 0; i < 2; i++)
                {
                    var TileXML = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150BlockAndText01);
                    var TileXML1 = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
                    var TileAttribute = TileXML.GetElementsByTagName("text");
                    var TileAttribute1 = TileXML1.GetElementsByTagName("text");


                    if (i == 0)
                    {
                        TileAttribute[4].AppendChild(TileXML.CreateTextNode("宜"));
                        TileAttribute1[0].AppendChild(TileXML1.CreateTextNode("宜"));
                        for (int j = 0; j < MainPage.Num; j++)
                        {
                            if (j < 4)
                            {
                                TileAttribute[j].AppendChild(TileXML.CreateTextNode(MainPage.eventArr[j].Incident));
                            }
                            if (j < 3)
                            {
                                TileAttribute1[j + 1].AppendChild(TileXML1.CreateTextNode(MainPage.eventArr[j].Incident));
                            }
                        }
                    }
                    else
                    {
                        TileAttribute[4].AppendChild(TileXML.CreateTextNode("忌"));
                        TileAttribute1[0].AppendChild(TileXML1.CreateTextNode("忌"));
                        for (int j = 0; j < MainPage.eventArr.Count - MainPage.Num; j++)
                        {
                            if (j < 4)
                            {
                                TileAttribute[j].AppendChild(TileXML.CreateTextNode(MainPage.eventArr[j + MainPage.Num].Incident));
                            }
                            if (j < 3)
                            {
                                TileAttribute1[j + 1].AppendChild(TileXML1.CreateTextNode(MainPage.eventArr[j + MainPage.Num].Incident));
                            }
                        }
                    }

                    var TileNotification = new TileNotification(TileXML);
                    updater.Update(TileNotification);
                    var TileNotification1 = new TileNotification(TileXML1);
                    updater.Update(TileNotification1);
                }
            }

            else
            {
                for (int i = 0; i < 4; i++)
                {
                    var TileXML = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text01);
                    var TileXML1 = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);
                    var TileAttribute = TileXML.GetElementsByTagName("text");
                    var TileAttribute1 = TileXML1.GetElementsByTagName("text");


                    if (MainPage.month == 2)
                    {
                        TileAttribute[0].AppendChild(TileXML.CreateTextNode(Mynote1[i]));
                        TileAttribute[1].AppendChild(TileXML.CreateTextNode(Mysug1[i]));
                        TileAttribute1[0].AppendChild(TileXML1.CreateTextNode(Mynote1[i]));
                        TileAttribute1[1].AppendChild(TileXML1.CreateTextNode(Mysug1[i]));
                    }
                    else
                    {
                        TileAttribute[0].AppendChild(TileXML.CreateTextNode(Mynote[i]));
                        TileAttribute[1].AppendChild(TileXML.CreateTextNode(Mysug[i]));
                        TileAttribute1[0].AppendChild(TileXML1.CreateTextNode(Mynote[i]));
                        TileAttribute1[1].AppendChild(TileXML1.CreateTextNode(Mysug[i]));
                    }


                    var TileNotification = new TileNotification(TileXML);
                    updater.Update(TileNotification);
                    var TileNotification1 = new TileNotification(TileXML1);
                    updater.Update(TileNotification1);
                }
            }
             
        }
    }
}
