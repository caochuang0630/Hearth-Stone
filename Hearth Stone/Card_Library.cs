using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Card_Library
    {
        public Card[] library = new Card[8];      //牌库

        public Card_Library()
        {
            library[0] = new Card("闪金镇步兵", 1, 2, "嘲讽", 1);
            library[1] = new Card("厄运鼹鼠", 1, 3, "呃呃呃呃", 1);
            library[2] = new Card("鳄鱼", 3, 2, "呃呃呃", 2);
            library[3] = new Card("冲锋鱼人", 2, 1, "冲锋", 2);
            library[4] = new Card("炎魔之王拉格纳罗斯", 5, 5, "让火焰净化一切", 5);
            library[5] = new Card("城墙", 2, 4, "嘲讽", 3);
            library[6] = new Card("布莱恩铜须", 2, 4, "战吼效果触发两次", 3);
            library[7] = new Card("软泥怪", 3, 3, "摧毁对手武器", 3);
        }

        //抽一张牌方法
        public Card 抽一张牌()
        {
            Random r = new Random();
            int ran = r.Next(library.Length);       //保存随机数
            Card c = this.library[ran];
            Card[] new_library = new Card[library.Length-1];
            //两个步长来减取一个成员
            int i_library = 0;
            int i_new_library = 0;
            for (; i_new_library<new_library.Length; i_library++)
            {
                if (i_library==ran)
                {
                    continue;
                }
                new_library[i_new_library] = library[i_library];
                i_new_library++;
            }

            library = new Card[new_library.Length];
            library = new_library;
            return c;
        }
    }
}
