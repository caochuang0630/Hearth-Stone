using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    struct Card
    {
        //变量
        public string card_name;    //卡牌名字
        public int card_attack;     //卡牌攻击
        public int card_blood;      //卡牌血量
        public string card_describe;    //卡牌描述
        public int crystal;         //卡牌需要消耗的法力值
        public bool Alive;          //随从是否存活
        public int attack_times;       //随从攻击次数

        //构造方法
        public Card(string cn,int ca,int cb,string cd, int cry)
        {
            this.card_name = cn;
            this.card_describe = cd;
            this.crystal = cry;
            if (ca<99&&cb<99)
            {
                this.card_attack = ca;
                this.card_blood = cb;
            }
            else
            {
                this.card_attack = 0;
                this.card_blood = 0;
            }
            this.Alive = true;
            this.attack_times = 0;
        }
        //打出卡牌
        public void ussing_card()
        {

        }
    }
}
