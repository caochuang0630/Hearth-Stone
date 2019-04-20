using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Card_Library
    {
        public Card[] library = new Card[3];      //牌库

        public Card_Library()
        {
            Card card = new Card("炎魔之王拉格纳罗斯", 8, 8, "让火焰净化一切", 1);
            foreach (int i in Program.range(library.Length))
            {
                library[i] = card;
            }
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
