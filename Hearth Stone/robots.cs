using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class robots
    {
        //---------------------------------------------------------------------------------------
        //AI机器人
        //敌方回合
        public static void 敌方回合(Game G)
        {
            //出牌动作，判断法力水晶和出牌
            int[] crystal = new int[G.hand_card1.Length];
            foreach (int i in Program.range(G.hand_card1.Length))
            {
                crystal[i] = G.hand_card1[i].crystal;
            }
            if (G.hand_card1[Method.最大值(crystal)].crystal<=G.crystal_0)
            {
                敌方上牌(Method.最大值(crystal),G);
            }
        }

        //
        public static void 敌方上牌(int card_number,Game G)//参数为出手牌的索引（第一个是0）
        {
            //战场满了没

            if (G.team0_Entourage.Length + 1 <= 7)
            {
                G.crystal_0 -= G.hand_card1[card_number].crystal;
                //战场加上
                G.team0_Entourage = Method.加数组(G.team0_Entourage, G.hand_card1[card_number]);
                //手牌减去
                G.hand_card1 = Method.减数组(G.hand_card1, card_number);

            }
            else
            {
                return;
            }
        }
    }
}
