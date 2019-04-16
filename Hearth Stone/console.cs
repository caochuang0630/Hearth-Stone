using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class console
    {
        public char[,] display0 = new char[40, 50];   //把输出的字串用二维数组保存下来，相当于屏幕的分辨率
        public Card [] team0_Entourage; //敌方随从数组
        public Card [] team1_Entourage; //我方随从数组
        public Hero team0_hero;   //敌方英雄
        public Hero team1_hero;   //我方英雄

        //构造方法
        public console(Hero h0)
        {
            this.team0_hero = h0;
        }

        //总输出方法
        public void display()
        {
            this.填充空格(display0);
            this.渲染边框(display0);
            this.渲染英雄(team0_hero);
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

        //取二维数组中的一维方法
        public char[] 取一维数组(char[,] a,int i)
        {
            char[] width =new char[a.GetLength(1)];
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

        //渲染英雄
        public void 渲染英雄(Hero h)
        {
            //先渲染英雄单个，再把渲染进整个大画面
            char[,] hero0 = new char[5,8];
            填充空格(hero0);
            渲染边框(hero0);
            char[] a = 居中(取一维数组(hero0,2),h.hero[0].ToCharArray());
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
            
            foreach (int i in Program.range(hero0_display.GetLength(0)))
            {
                foreach (int j in Program.range(hero0_display.GetLength(1)))
                {
                    display0[i + 1, j] = hero0_display[i, j];
                }
            }
        }


    }
}
