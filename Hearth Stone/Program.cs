using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hearth_Stone
{
    class Program
    {
        static void Main(string[] args)
        {
            //主程序


            /*
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "炉石传说";
            Hero h0 = new Hero(0);
            Hero h1 = new Hero(1);
            Card card0 = new Card("炎魔之王拉格纳罗斯",8,8, "让火焰净化一切",8);
            Card[] card1 = new Card[7]; //敌方随从
            Card[] card2 = new Card[7]; //我方随从
            foreach (int i in range(card1.Length))
            {
                card1[i] = card0;
                card2[i] = card0;
            }
            Card_Library cl = new Card_Library();
            Card_Library c2 = new Card_Library();
            console c = new console(h0,h1,card1,card2,false,6,6,cl,c2);
            c.display();
            */
            
            Game G = new Game();
            G.start();



        }

        public static int[] range(int a)
        {
            int[] number = new int[a];
            for (int i =0; i<number.Length;i++)
            {
                number[i] = i;
            }
            return number;
        }
    }
}
