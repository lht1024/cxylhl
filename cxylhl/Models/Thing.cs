using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxylhl.Models
{
    public class Thing
    {
        public string ID { get; set; }
        public string Incident { get; set; }
        public string Good { get; set; }
        public string Bad { get; set; }
        public string IsWeekend { get; set; }

        
        public static List<Thing> AllThings()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing
            {
                Incident = "写单元测试",
                Good = "写单元测试将减少出错",
                Bad = "写单元测试会降低你的开发效率",
                IsWeekend = "0",
                ID = "1"
            });

            things.Add(new Thing
            {
                Incident = "洗澡",
                Good = "你几天没洗澡了？",
                Bad = "会把设计方面的灵感洗掉",
                IsWeekend = "1",
                ID = "2"
            });

            things.Add(new Thing
            {
                Incident = "锻炼一下身体",
                Good = "感觉身体被掏空",
                Bad = "能量没消耗多少，吃得却更多",
                IsWeekend = "1",
                ID = "3"
            });

            things.Add(new Thing
            { Incident = "抽烟",
                Good = "抽烟有利于提神，增加思维敏捷",
                Bad = "除非你活够了，死得早点没关系",
                IsWeekend = "1",
                ID = "4"
            });

            things.Add(new Thing
            {
                Incident = "白天上线",
                Good = "今天白天上线是安全的",
                Bad = "可能导致灾难性后果",
                IsWeekend = "0",
                ID = "5"
            });

            things.Add(new Thing
            {
                Incident = "重构",
                Good = "代码质量得到提高",
                Bad = "你很有可能会陷入泥潭",
                IsWeekend = "0",
                ID = "6"
            });

            things.Add(new Thing
            {
                Incident = "使用{0}",
                Good = "你看起来更有品位",
                Bad = "别人会觉得你在装逼",
                IsWeekend = "0",
                ID = "7"
            });

            things.Add(new Thing
            {
                Incident = "跳槽",
                Good = "该放手时就放手",
                Bad = "鉴于当前的经济形势，你的下一份工作未必比现在强",
                IsWeekend = "0",
                ID = "8"
            });

            things.Add(new Thing
            {
                Incident = "招人",
                Good = "你面前这位有成为牛人的潜质",
                Bad = "这人会写程序吗？",
                IsWeekend = "0",
                ID = "9"
            });

            things.Add(new Thing
            {
                Incident = "面试",
                Good = "面试官今天心情很好",
                Bad = "面试官不爽，会拿你出气",
                IsWeekend = "0",
                ID = "10"
            });

            things.Add(new Thing
            {
                Incident = "提交辞职申请",
                Good = "公司找到了一个比你更能干更便宜的家伙，巴不得你赶快滚蛋",
                Bad = "鉴于当前的经济形势，你的下一份工作未必比现在强",
                IsWeekend = "0",
                ID = "11"
            });

            things.Add(new Thing
            {
                Incident = "申请加薪",
                Good = "老板今天心情很好",
                Bad = "公司正在考虑裁员",
                IsWeekend = "0",
                ID = "12"
            });

            things.Add(new Thing
            {
                Incident = "晚上加班",
                Good = "晚上是程序员精神最好的时候",
                Bad = "",
                IsWeekend = "1",
                ID = "13"
            });

            things.Add(new Thing
            {
                Incident = "在妹子面前吹牛",
                Good = "改善你矮穷挫的形象",
                Bad = "会被识破",
                IsWeekend = "1",
                ID = "14"
            });

            things.Add(new Thing
            {
                Incident = "撸管",
                Good = "避免缓冲区溢出",
                Bad = "强撸灰飞烟灭",
                IsWeekend = "1",
                ID = "15"
            });

            things.Add(new Thing
            {
                Incident = "浏览成人网站",
                Good = "重拾对生活的信心",
                Bad = "你会心神不宁",
                IsWeekend = "1",
                ID = "16"
            });

            things.Add(new Thing
            {
                Incident = "写超过{0}行的方法",
                Good = "你的代码组织的很好，长一点没关系",
                Bad = "你的代码将混乱不堪，你自己都看不懂",
                IsWeekend = "0",
                ID = "17"
            });

            things.Add(new Thing
            {
                Incident = "提交代码",
                Good = "遇到冲突的几率是最低的",
                Bad = "你遇到的一大堆冲突会让你觉得自己是不是时间穿越了",
                IsWeekend = "0",
                ID = "18"
            });

            things.Add(new Thing
            {
                Incident = "代码复审",
                Good = "发现重要问题的几率大大增加",
                Bad = "你什么问题都发现不了，白白浪费时间",
                IsWeekend = "0",
                ID = "19"
            });

            things.Add(new Thing
            {
                Incident = "开会",
                Good = "写代码之余放松一下打个盹，有益健康",
                Bad = "小心被扣屎盆子背黑锅",
                IsWeekend = "0",
                ID = "20"
            });

            things.Add(new Thing
            {
                Incident = "打DOTA", 
                Good = "你将有如神助",
                Bad = "你会被虐的很惨",
                IsWeekend = "1",
                ID = "21"
            });

            things.Add(new Thing
            {
                Incident = "晚上上线",
                Good = "晚上是程序员精神最好的时候",
                Bad = "你白天已经筋疲力尽了",
                IsWeekend = "0",
                ID = "22"
            });

            things.Add(new Thing
            {
                Incident = "修复BUG",
                Good = "你今天对BUG的嗅觉大大提高",
                Bad = "新产生的BUG将比修复的更多",
                IsWeekend = "0",
                ID = "23"
            });

            things.Add(new Thing
            {
                Incident = "设计评审",
                Good = "设计评审会议将变成头脑风暴",
                Bad = "人人筋疲力尽，评审就这么过了",
                IsWeekend = "0",
                ID = "24"
            });

            things.Add(new Thing
            {
                Incident = "需求评审",
                Good = "",
                Bad = "",
                IsWeekend = "0",
                ID = "25"
            });

            things.Add(new Thing
            {
                Incident = "上微博",
                Good = "今天发生的事不能错过",
                Bad = "今天的微博充满负能量",
                IsWeekend = "1",
                ID = "26"
            });

            things.Add(new Thing
            {
                Incident = "上AB站",
                Good = "还需要理由吗？",
                Bad = "满屏兄贵亮瞎你的眼",
                IsWeekend = "1",
                ID = "27"
            });

            things.Add(new Thing
            {
                Incident = "玩FlappyBird",
                Good = "今天破纪录的几率很高",
                Bad = "除非你想玩到把手机砸了",
                IsWeekend = "1",
                ID = "28"
            });

            return things;
        }

        public static List<Thing> Filter(List<Thing> AllThings,bool IsWeekend)
        {
            if (IsWeekend == true)
            {
                foreach (var Item in AllThings)
                {
                    if (Item.IsWeekend == "1")
                    {
                        AllThings.Remove(Item);
                    }
                }
             }
                return AllThings;
        }
    }
}
