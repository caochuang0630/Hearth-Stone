using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Card
    {
        //变量
        public string card_name;    //卡牌名字
        public int card_attack;     //卡牌攻击
        public int card_blood;      //卡牌血量
        public string card_describe;    //卡牌描述

        //构造方法
        public Card(string cn,int ca,int cb,string cd)
        {
            this.card_name = cn;
            this.card_describe = cd;
            if (ca<99&&cb<99)
            {
                this.card_attack = ca;
                this.card_blood = cb;
            }
        }
        //打出卡牌
        public void ussing_card()
        {

        }
    }
}
