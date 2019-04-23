using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Game
    {
        //成员变量
        private Card[] team0_Entourage; //敌方随从数组
        private Card[] team1_Entourage; //我方随从数组
        private Hero team0_hero;   //敌方英雄
        private Hero team1_hero;   //我方英雄
        private bool round;         //保存回合，false为敌方回合，true为我方回合
        private int crystal_0;                          //保存双方水晶数量
        private int crystal_1;
        private Card_Library Remaining_card;            //敌方卡牌相关信息
        private Card_Library Remaining_card1;            //我方卡牌相关信息
        private console c;              //保存输出的数据
        private Card[] hand_card;       //保存手牌信息

        //构造方法
        public Game()
        {
            Card card0 = new Card("炎魔之王拉格纳罗斯", 8, 8, "让火焰净化一切", 8);
            Card[] card1 = new Card[7]; //敌方随从
            Card[] card2 = new Card[7]; //我方随从
            foreach (int i in Program.range(card1.Length))
            {
                card1[i] = card0;
                card2[i] = card0;
            }
            this.team0_Entourage = card1;
            this.team1_Entourage = card2;
            this.team0_hero = new Hero(2);
            this.team1_hero = new Hero(5);
            this.crystal_0 = 5;
            this.crystal_1 = 9;
            this.Remaining_card = new Card_Library();
            this.Remaining_card1 = new Card_Library();
            this.hand_card = new Card[0];
        }


        //游戏从这里开始
        public void start()
        {
            char[,] start_display = new char[3, 20];
            console.填充空格(start_display);
            console.渲染边框(start_display);
            foreach (int i in Program.range(start_display.GetLength(1)))
            {
                start_display[1, i] = console.居中(console.取一维数组(start_display, 1), "请按下任意键开始游戏".ToCharArray())[i];
            }
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Method.输出二维数组(start_display);
            Console.ReadLine();

            //抽四张牌
            for (int i = 0;i<4;i++)
            {
                this.加牌(hand_card,round);
            }
            war();
        }

        //刷新界面
        public void refresh(Hero t0h, Hero t1h, Card[] t0e, Card[] t1e, bool r,int c0,int c1, Card_Library rc, Card_Library rc1,Card[] hc)
        {
            Console.Clear();
            this.c = new console(t0h, t1h, t0e, t1e, r, c0, c1, rc, rc1,hc);
            c.display();
        }

        //战场
        public void war()
        {
            refresh(team0_hero, team1_hero, team0_Entourage, team1_Entourage, round, crystal_0, crystal_1, Remaining_card, Remaining_card1,hand_card);

            Console.WriteLine("按一下抽一张牌");
            Console.ReadLine();
            this.加牌(hand_card,round);
            refresh(team0_hero, team1_hero, team0_Entourage, team1_Entourage, round, crystal_0, crystal_1, Remaining_card, Remaining_card1, hand_card);
            /*
            Console.Clear();
            c = new console(team0_hero, team1_hero, team0_Entourage, team1_Entourage, round, crystal_0, crystal_1, Remaining_card, Remaining_card1, hand_card);
            c.display();
            */
        }

        //攻击方法
        public void 进攻()
        {
            //保存进攻和攻击随从的角标
            Console.WriteLine("请选择你想要进攻随从的编号(从左往右开始数第一个是0)：");
            int my_Entourage = int.Parse(Console.ReadLine());
            Console.WriteLine("请选择你想要攻击随从的编号(从左往右开始数第一个是0)：");
            int he_Entourage = int.Parse(Console.ReadLine());
            Card[][] back_attack = Method.attack(team1_Entourage, my_Entourage, team0_Entourage, he_Entourage);
            team1_Entourage = back_attack[0];
            team0_Entourage = back_attack[1];

        }

        //抽一张牌
        public void 加牌(Card[] card_hand,bool b)
        {
            Card[] card_temporary =new Card[card_hand.Length+1];        //临时保存手牌信息
            foreach (int i in Program.range(card_hand.Length))
            {
                card_temporary[i] = card_hand[i];
            }
            if (b == true)
            {
                card_temporary[card_temporary.GetUpperBound(0)] = this.Remaining_card1.抽一张牌();
            }
            else
            {
                card_temporary[card_temporary.GetUpperBound(0)] = this.Remaining_card.抽一张牌();
            }
            this.hand_card = new Card[card_temporary.Length];
            foreach (int i in Program.range(hand_card.Length))
            {
                this.hand_card[i] = card_temporary[i];
            }
        }
    } 



}
