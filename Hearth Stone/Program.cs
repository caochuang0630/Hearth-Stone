using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Program
    {
        static void Main(string[] args)
        { 
            Hero h0 = new Hero(0);
            Hero h1 = new Hero(1);
            Card card0 = new Card("炎魔之王拉格纳罗斯",8,8, "让火焰净化一切");
            Card[] card1 = new Card[2];
            card1[0] = card0;
            card1[1] = card0;
            console c = new console(h0,h1,card1);
            c.渲染敌方随从(card1);
            
            
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
