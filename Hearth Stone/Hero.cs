using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Hero
    {
        public string[] hero;       //英雄的相关信息
        public int hero_blood;  //英雄的血
        //英雄职业名字数组
        public static string[] hero0 = new string[] { "法师", "吉安娜","火焰冲击" };
        public static string[] hero1 = new string[] { "牧师", "安度因", "次级治疗术" };
        public static string[] hero2 = new string[] { "术士", "古尔丹", "生命分流" };
        public static string[] hero3 = new string[] { "德鲁伊", "德鲁伊", "变形" };
        public static string[] hero4 = new string[] { "祭司萨满", "萨满" , "图腾召唤" };
        public static string[] hero5 = new string[] { "潜行者", "瓦莉拉", "匕首精通" };
        public static string[] hero6 = new string[] { "战士", "加尔鲁什" , "全副武装" };
        public static string[] hero7 = new string[] { "圣骑士", "乌瑟尔", "援军" };
        public static string[] hero8 = new string[] { "猎人", "雷克萨", "稳固射击" };
        
        //构造方法
        public Hero(int i)
        {
            switch (i)
            {
                case 0:
                    this.hero = hero0;
                    break;
                case 1:
                    this.hero = hero1;
                    break;
                case 2:
                    this.hero = hero2;
                    break;
                case 3:
                    this.hero = hero3;
                    break;
                case 4:
                    this.hero = hero4;
                    break;
                case 5:
                    this.hero = hero5;
                    break;
                case 6:
                    this.hero = hero6;
                    break;
                case 7:
                    this.hero = hero7;
                    break;
                case 8:
                    this.hero = hero8;
                    break;
            }
            this.hero_blood = 30;
        }
        //返回英雄职业和名字索引器
        public string[] this [string n]
        {
            get
            {
                switch (n)
                {
                    case "法师":
                        return hero0;
                        break;
                    case "牧师":
                        return hero1;
                        break;
                    case "术士":
                        return hero2;
                        break;
                    case "德鲁伊":
                        return hero3;
                        break;
                    case "祭祀":
                        return hero4;
                        break;
                    case "潜行者":
                        return hero5;
                        break;
                    case "战士":
                        return hero6;
                        break;
                    case "圣骑士":
                        return hero7;
                        break;
                    case "猎人":
                        return hero8;
                        break;
                    default:
                        return null;
                }
            }
        }


    }

}
