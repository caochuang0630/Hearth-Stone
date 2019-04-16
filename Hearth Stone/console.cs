using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class console
    {
        public char[,] display0 = new char[60, 50];   //把输出的字串用二维数组保存下来，相当于屏幕的分辨率
        public Card [] team0_Entourage; //敌方随从数组
        public Card [] team1_Entourage; //我方随从数组
        public Hero team0_hero;   //敌方英雄
        public Hero team1_hero;   //我方英雄
        public char[,] card = new char[15, 8];       ///卡的分辨率

        //构造方法
        public console(Hero h0,Hero h1,Card[] te0)
        {
            this.team0_hero = h0;
            this.team1_hero = h1;
            this.team0_Entourage = te0;
        }

        //总输出方法
        public void display()
        {
            this.填充空格(display0);
            this.渲染边框(display0);
            this.渲染英雄(team0_hero,team1_hero);
            foreach (int i in Program.range(display0.GetLength(0)))
            {
                foreach (int j in Program.range(display0.GetLength(1)))
                {
                    Console.Write(display0[i, j]);
                }
                Console.WriteLine();
            }
        }

        //居中方法
        public static char[] 居中(char[] big, char[] small)
        {
            int i = (big.Length - small.Length) / 2;
            foreach (int j in Program.range(small.Length))
            {
                big[i + j] = small[j];
            }
            return big;

        }
        public static void 居中不返回(char[] big, char[] small)
        {
            int i = (big.Length - small.Length) / 2;
            foreach (int j in Program.range(small.Length))
            {
                big[i + j] = small[j];
            }
        }

        //取二维数组中的一维方法
        public static char[] 取一维数组(char[,] a,int i)
        {
            char[] width =new char[a.GetLength(a.Rank-1)];
            foreach (int j in Program.range(width.Length))
            {
                width[j] = a[i,j];
            }
            return width;
        }

        //填充空格给显示数组
        public void 填充空格(char[,] a)
        {
            foreach (int i in Program.range(a.GetLength(0)))
            {
                foreach (int j in Program.range(a.GetLength(1)))
                {
                    a[i, j] = '　';
                }
            }
        }

        //渲染方法
        //渲染边框
        public void 渲染边框(char[,] a)
        {
            foreach (int i in Program.range(a.GetLength(1)))
            {
                a[a.GetLowerBound(0), i] = '－';
            }

            for (int i = 1; i< a.GetLength(0)-1;i++)
            {
                //二维数组取下限和上限
                a[i, a.GetUpperBound(1)] = '｜';
                a[i, a.GetLowerBound(1)] = '｜';
            }

            foreach (int i in Program.range(a.GetLength(1)))
            {
                a[a.GetUpperBound(0), i] = '－';
            }

        }

        //渲染两边框
        public void 渲染两边框(char[,] a)
        {
            for (int i = 0; i < a.GetLength(0) - 1; i++)
            {
                //二维数组取下限和上限
                a[i, a.GetUpperBound(1)] = '｜';
                a[i, a.GetLowerBound(1)] = '｜';
            }
        }

        //渲染英雄
        public void 渲染英雄(Hero h0,Hero h1)
        {
            //渲染第一个英雄
            //先渲染英雄单个，再把渲染进整个大画面
            char[,] hero0 = new char[5,8];          //英雄分辨率
            填充空格(hero0);
            渲染边框(hero0);
            char[] a = 居中(取一维数组(hero0,2),h0.hero[0].ToCharArray());
            foreach (int i in Program.range(hero0.GetLength(1)))
            {
                hero0[2, i] = a[i];
            }
            //把渲染进整个大画面
            char[,] hero0_display = new char[hero0.GetLength(0),display0.GetLength(1)];
            this.填充空格(hero0_display);
            渲染边框(hero0_display);
            foreach (int i in Program.range(hero0_display.GetLength(0)))
            {
                char[] b = 居中(取一维数组(hero0_display, i), 取一维数组(hero0, i));
                foreach (int j in Program.range(hero0_display.GetLength(1)))
                {
                    hero0_display[i, j] = b[j];
                }
            }
            //把画面代替成总输出二维数组里面去
            foreach (int i in Program.range(hero0_display.GetLength(0)))
            {
                foreach (int j in Program.range(hero0_display.GetLength(1)))
                {
                    display0[i + 1, j] = hero0_display[i, j];
                }
            }

            //渲染第二个英雄
            //先渲染英雄单个，再把渲染进整个大画面
            char[,] hero1 = new char[5, 8];
            填充空格(hero1);
            渲染边框(hero1);
            char[] a1 = 居中(取一维数组(hero1, 2), h1.hero[0].ToCharArray());
            foreach (int i in Program.range(hero1.GetLength(1)))
            {
                hero1[2, i] = a1[i];
            }
            //把渲染进整个大画面
            char[,] hero1_display = new char[hero1.GetLength(0), display0.GetLength(1)];
            this.填充空格(hero1_display);
            渲染边框(hero1_display);
            foreach (int i in Program.range(hero1_display.GetLength(0)))
            {
                char[] b = 居中(取一维数组(hero1_display, i), 取一维数组(hero1, i));
                foreach (int j in Program.range(hero1_display.GetLength(1)))
                {
                    hero1_display[i, j] = b[j];
                }
            }
            //把画面代替成总输出二维数组里面去
            for (int i = display0.GetLength(0)-2,k = hero1_display.GetLength(0)-1;i> display0.GetLength(0) - 2-(hero1_display.GetLength(0));i--,k--)
            {
                foreach (int j in Program.range(hero1_display.GetLength(1)))
                {
                    display0[i, j] = hero1_display[k, j];
                }
            }
        }

        //渲染一张卡
        public char[,] 渲染一张卡(Card c)
        {
            this.填充空格(card);
            this.渲染边框(card);
            //把攻击力数字放在字符数组里
            char[] attack = c.card_attack.ToString().ToCharArray();         
            foreach (int i in Program.range(attack.Length))
            {
                card[card.GetUpperBound(0), i] = Method.数字半转全(attack[i]);
            }

            //把血数字放在字符数组里
            char[] blood = c.card_blood.ToString().ToCharArray();
            for (int i = card.GetUpperBound(1),k = blood.GetUpperBound(0); i>card.GetUpperBound(1)-blood.GetLength(0);i--,k--)
            {
                card[card.GetUpperBound(0), i] = Method.数字半转全(blood[k]);
            }
            
            //渲染卡牌名字
            int card_name_row;      //卡牌名字行数
            //填充字符串
            card_name_row = c.card_name.Length / 6;
            if (c.card_name.Length%6!=0)
            {
                card_name_row++;
            }
            while (c.card_name.Length % 6 != 0)
            {
                c.card_name += '　'; 
            }
            //字符串放在char[]数组里面
            char[,] card_name = new char[card_name_row,6];
            this.填充空格(card_name);
            for (int i =0,j = 0;i<card_name.GetLength(0) ;i++)
            {
                for (int k = 0; k < card_name.GetLength(1); k++,j++)
                { 
                    card_name[i,k] = c.card_name.ToCharArray()[j];
                }
            }
            //名字数组放进卡牌里面
            for (int i = 0; i<card_name.GetLength(0)+1;i++)
            {
                if (i >= card_name.GetLength(0))
                {
                    for (int j = 0; j < card.GetLength(1); j++)
                    {
                        card[i + 1, j] = '－';
                    }
                    continue;
                }
                for (int j = 0; j < card_name.GetLength(1); j++)
                {
                    card[i + 1, j] = 居中(取一维数组(card, i + 1), 取一维数组(card_name, i))[j] ;
                    
                }
                
            }
            

            //渲染卡牌描述
            return card;
        }

        //渲染敌方随从
        public void 渲染敌方随从(Card[] team)
        {
            //保存整个敌方随从渲染
            char[,] card_big = new char[display0.Length,card.Length];
            this.填充空格(card_big);
            this.渲染两边框(card_big);


            char[,,] card_small = new char[team.Length,card.GetLength(0),card.GetLength(1)];      //保存临时渲染的单张卡
            foreach (int i in Program.range(card_small.GetLength(0)))
            {
                foreach (int j in Program.range(card_small.GetLength(1)))
                {
                    foreach (int k in Program.range(card_small.GetLength(2)))
                    {
                        card_small[i, j, k] = 渲染一张卡(team[i])[j,k];
                    }
                }
            }

            char[,] card_plus = new char[card.GetLength(0), team.Length * card.GetLength(1) + (team.Length - 1)];      //保存把卡加在一起渲染
            填充空格(card_plus);
            int list=0;       //控制列数
            foreach (int k in Program.range(team.Length))
            { 
                foreach (int i in Program.range(card_small.GetLength(2)))
                {
                    foreach (int j in Program.range(card_small.GetLength(1)))
                    {
                        card_plus[j, list] = card_small[k,j,i];
                    }
                    list ++;
                }
                list++;
            }

            foreach (int i in Program.range(card_plus.GetLength(0)))
            {
                foreach (int j in Program.range(card_plus.GetLength(1)))
                {
                    Console.Write(card_plus[i, j]);
                }
                Console.WriteLine();
            }
        } 

    }
}
