using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Core;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace cxylhl
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Page1 : Page
    {
        ObservableCollection<MyEvent> GoodThings;
        ObservableCollection<MyEvent> BadThings;
        
        string[] tools = new string[]{"Eclipse写程序", "MSOffice写文档", "记事本写程序","VSCode写程序",
            "Windows10", "Linux", "MacOS", "Edge", "Android设备", "iOS设备","Wp设备","黑莓设备" };
        string[] drinks = new string[] { "水","茶","红茶","绿茶","咖啡","奶茶","可乐","鲜奶","豆奶","果汁",
            "果味汽水","苏打水","运动饮料","酸奶","酒" };
        string[] directions = new string[] { "北方", "东北方", "东方", "东南方", "南方", "西南方", "西方", "西北方" };
        public static int iday;
        public Page1()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            iday = (MainPage.year) * 10000 + (MainPage.month)
            * 100 + (MainPage.day);

            GetDesk();
            GetDrink();

            MyCalendar.Text = MainPage.year.ToString() + "年" + MainPage.month.ToString() + "月" + MainPage.day.ToString() + "日" + "      " + GetDayOfWeek();
            MyLunisolarCalendar.Text = Lunisolar.GetChineseDateTime(new DateTime(MainPage.year,MainPage.month,MainPage.day));
            GoodThings = new ObservableCollection<MyEvent>();
            BadThings = new ObservableCollection<MyEvent>();

            List<Thing> Mythings = Thing.Filter(Thing.AllThings(), IsWeekend());
            int numGood;
            int numBad;
            List<Thing> eventArr;
            if ((MainPage.day == 14 && MainPage.month == 2) || (MainPage.day == 11 && MainPage.month == 11))
            {
                numGood = 1;
                MainPage.Num = numGood;
                numBad = 1;
                eventArr = Specialize(MainPage.month, MainPage.day);

            }
            else
            {
                
                numGood = random(iday, 98) % 3 + 2;
                //var numGood = 4;
                MainPage.Num = numGood;

                numBad = random(iday, 87) % 3 + 2;
                //var numBad = 4;
                eventArr = pickRandomActivity(Mythings, numGood + numBad);
            }

            MainPage.eventArr = eventArr;

            for (int i = 0; i < numGood; i++)
            {
                AddToGood(eventArr[i]);
            }

            for (int i = 0; i < numBad; i++)
            {
                AddToBad(eventArr[numGood + i]);
            }
        }

        public List<Thing> Specialize(int month, int day)
        {
            List<Thing> Result = new List<Thing>();
            if (month == 2 && day == 14)
            {
                Result.Add(new Thing
                {
                    Incident = "加入FFF团",
                    Good = "烧死那对异性恋"
                });
                Result.Add(new Thing
                {
                    Incident = "陪在男(女)友身边",
                    Bad = "分手的几率几何性增长"
                });
            }
            else
            {
                Result.Add(new Thing
                {
                    Incident = "去表白",
                    Good = "你是一个好人"
                });
                Result.Add(new Thing
                {
                    Incident = "疯狂购物",
                    Bad = "快递公司失联"
                });
            }

            return Result;
        }

        public string GetDayOfWeek()
        {
            switch (MainPage.dayofweek.ToString())
            {
                case "Friday":
                    return "星期五";
                    break;
                case "Saturday":
                    return "星期六";
                    break;
                case "Sunday":
                    return "星期日";
                    break;
                case "Monday":
                    return "星期一";
                    break;
                case "Tuesday":
                    return "星期二";
                    break;
                case "Wednesday":
                    return "星期三";
                    break;
                case "Thursday":
                    return "星期四";
                    break;
                default:
                    return "无法识别";
            }


        }

        public void AddToGood(Thing MyEvents)
        {
            GoodThings.Add(new MyEvent
            {
                Affair = MyEvents.Incident,
                Suggestion = MyEvents.Good
            });
        }

        public void AddToBad(Thing MyEvents)
        {
            BadThings.Add(new MyEvent
            {
                Affair = MyEvents.Incident,
                Suggestion = MyEvents.Bad
            });
        }

        public List<Thing> pickRandomActivity(List<Thing> activities, int size)
        {
            var picked_events = pickRandom(activities, size);
            picked_events = Parse(picked_events);
            return picked_events;
        }

        public List<Thing> Parse(List<Thing> activities)
        {
            foreach (var item in activities)
            {
                if (item.ID == "7")
                {
                    item.Incident = item.Incident.Replace("{0}", tools[random(iday, 11) % tools.Length]);
                }
                else if (item.ID == "17")
                {
                    item.Incident = item.Incident.Replace("{0}", (random(iday, 12) % 247 + 30).ToString());
                }
            }
            return activities;
        }

        public List<Thing> pickRandom(List<Thing> activities, int size)
        {
            List<Thing> Result = new List<Thing>();
            for (int i = 0; i < activities.Count; i++)
            {
                Result.Add(activities[i]);
            }
            for (int j = 0; j < activities.Count - size; j++)
            {
                var index = random(iday, j) % Result.Count;
                Result.Remove(Result[index]);
            }
            return Result;
        }

        public int random(int dayseed, int indexseed)
        {
            var n = dayseed % 11117;
            for (var i = 0; i < 100 + indexseed; i++)
            {
                n = n * n;
                n = n % 11117;   // 11117 是个质数
            }
            return n;
        }

        public bool IsWeekend()
        {
            var t = DateTime.Now.DayOfWeek;
            if (DateTime.Now.DayOfWeek.ToString() == "0" || DateTime.Now.DayOfWeek.ToString() == "6")
            {
                return true;
            }
            return false;
        }

        public void GetDesk()
        {
            Desk.Text = "面向" + directions[random(iday, 2) % directions.Length] + "写程序，BUG最少";
        }

        public void GetDrink()
        {
            Drink.Text = drinks[random(iday, 2) % drinks.Length];
        }
    }
}
