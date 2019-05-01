using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Hearth_Stone
{
    class Game
    {
        //成员变量
        public Card[] team0_Entourage; //敌方随从数组
        private Card[] team1_Entourage; //我方随从数组
        public Hero team0_hero;   //敌方英雄
        public Hero team1_hero;   //我方英雄
        private bool round;         //保存回合，false为敌方回合，true为我方回合
        public int crystal_0;                          //保存敌方水晶数量
        private int crystal_1;                          //保存我方水晶数量
        public int crystal_0_upper;                     //保存敌方水晶回合上限
        private int crystal_1_upper;                   //保存我方水晶回合上限
        public Card_Library Remaining_card;            //敌方卡牌相关信息
        private Card_Library Remaining_card1;            //我方卡牌相关信息
        private console c;              //保存输出的数据
        private Card[] hand_card;       //保存我方手牌信息
        public Card[] hand_card1;       //保存敌方手牌信息
        private int Tired;              //我方疲劳值
        public int Tired1;              //敌方疲劳值

        public List<string> game_history;

        //构造方法
        public Game()
        {
            /*
            Card card0 = new Card("炎魔之王拉格纳罗斯", 8, 8, "让火焰净化一切", 8);
            Card[] card1 = new Card[7]; //敌方随从
            Card[] card2 = new Card[7]; //我方随从
            foreach (int i in Program.range(card1.Length))
            {
                card1[i] = card0;
                card2[i] = card0;
            }
            */
            this.team0_Entourage = new Card[0];
            this.team1_Entourage = new Card[0];
            this.team1_hero = new Hero(5);
            this.team0_hero = new Hero(2);
            this.crystal_0_upper = 1;
            this.crystal_1_upper = 1;
            this.Remaining_card = new Card_Library();
            this.Remaining_card1 = new Card_Library();
            this.hand_card = new Card[0];
            this.hand_card1 = new Card[0];
            this.round = true;
            this.game_history = new List<string>();
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

            this.选择英雄();
            crystal_1 = crystal_1_upper;


            //抽四张牌
            for (int i = 0;i<4;i++)
            {
                this.加牌(hand_card,true);
                this.加牌(hand_card1, false);
            }
            war();
        }

        //刷新界面
        public void refresh()
        {
            Console.Clear();
            this.c = new console(this.team0_hero,this.team1_hero,this.team0_Entourage,this.team1_Entourage,this.round,this.crystal_0,this.crystal_1,this.Remaining_card,this.Remaining_card1,this.hand_card);
            c.display();
        }

        //选择英雄
        public void 选择英雄()
        {
            Console.Clear();
            Console.WriteLine("请选择你的英雄：编号依次为法师为1，猎人为9");
            Console.WriteLine("法师   |   牧师   |术士");
            Console.WriteLine("德鲁伊 |  祭司萨满|潜行者");
            Console.WriteLine("战士   |  圣骑士  |猎人");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    team1_hero = new Hero(0);
                    break;
                case "2":
                    team1_hero = new Hero(1);
                    break;
                case "3":
                    team1_hero = new Hero(2);
                    break;
                case "4":
                    team1_hero = new Hero(3);
                    break;
                case "5":
                    team1_hero = new Hero(4);
                    break;
                case "6":
                    team1_hero = new Hero(5);
                    break;
                case "7":
                    team1_hero = new Hero(6);
                    break;
                case "8":
                    team1_hero = new Hero(7);
                    break;
                case "9":
                    team1_hero = new Hero(8);
                    break;
                default:
                    Console.WriteLine("请重新选择");
                    Console.ReadLine();
                    this.选择英雄();
                    break;
            }
        }


        //战场
        public void war()
        {
            this.抽牌();
            //选择操作
            this.回合();
            /*
            Console.Clear();
            c = new console(team0_hero, team1_hero, team0_Entourage, team1_Entourage, round, crystal_0, crystal_1, Remaining_card, Remaining_card1, hand_card);
            c.display();
            */
        }

        //攻击方法
        public void 进攻()
        {
            //判断我方有没有随从
            if (this.team1_Entourage.Length!=0)
            {
                //保存进攻和攻击随从的角标
                Console.WriteLine("请选择你想要进攻随从的编号(从左往右开始数第一个是0");
                int my_Entourage = int.Parse(Console.ReadLine());
                Console.WriteLine("请选择你想要攻击随从的编号(从左往右开始数第一个是0，输入-1为攻击英雄)：)：");
                int he_Entourage = int.Parse(Console.ReadLine());

                if ((my_Entourage>team1_Entourage.GetUpperBound(0)|| my_Entourage < team1_Entourage.GetLowerBound(0)))
                {
                    Console.WriteLine("没有这个随从！，请按任意键重试！");
                    Console.ReadLine();
                    this.进攻();
                }
                //判断能不能攻击
                if (team1_Entourage[my_Entourage].attack_times!=0)
                {
                    //判断攻击的是随从还是英雄
                    if (he_Entourage != -1)
                    {
                        if (this.team0_Entourage.Length != 0)
                        {
                            //减一次攻击次数
                            team1_Entourage[my_Entourage].attack_times--;
                            Card[][] back_attack = Method.attack(team1_Entourage, my_Entourage, team0_Entourage, he_Entourage);
                            team1_Entourage = back_attack[0];
                            team0_Entourage = back_attack[1];
                        }
                        else
                        {
                            Console.WriteLine("没有敌方随从，请按任意键重试！");
                            Console.ReadLine();
                            this.进攻();
                        }

                    }
                    else if (he_Entourage == -1)
                    {
                        //减一次攻击次数
                        team1_Entourage[my_Entourage].attack_times--;
                        this.team0_hero.hero_blood -= this.team1_Entourage[my_Entourage].card_attack;
                    }
                }
                else
                {
                    Console.WriteLine("该随从无法攻击，请按任意键重试！");
                    Console.ReadLine();
                    this.回合();
                }

                
            }
            else
            {
                Console.WriteLine("场上没有随从，请按任意键重试！");
                Console.ReadLine();
            }
            this.回合();


        }

        //抽一张牌
        public void 加牌(Card[] card_hand,bool b)//当时写的带了一个手牌参数，后来发现没用，算了算了，不改了，能用就。还有一个参数是回合
        {
            Card[] card_temporary =new Card[card_hand.Length+1];        //临时保存手牌信息
            foreach (int i in Program.range(card_hand.Length))
            {
                card_temporary[i] = card_hand[i];
            }
            if (b == true)
            {
                card_temporary[card_temporary.GetUpperBound(0)] = this.Remaining_card1.抽一张牌();
                this.hand_card = new Card[card_temporary.Length];
                foreach (int i in Program.range(hand_card.Length))
                {
                    this.hand_card[i] = card_temporary[i];
                }
            }
            else
            {
                card_temporary[card_temporary.GetUpperBound(0)] = this.Remaining_card.抽一张牌();
                this.hand_card1 = new Card[card_temporary.Length];
                foreach (int i in Program.range(hand_card.Length))
                {
                    this.hand_card1[i] = card_temporary[i];
                }
            }
            
        }

        public void 抽牌()
        {
            /*
            Console.WriteLine("按一下抽一张牌");
            Console.ReadLine();
            */
            if (Remaining_card1.library.Length!=0)
            {
                this.加牌(hand_card, round);
            }
            else
            {
                this.Tired++;
                this.team1_hero.hero_blood -= this.Tired;
                Console.WriteLine("你没牌了，扣{0}滴血", this.Tired);
                Thread.Sleep(2000);
            }
            this.回合();
        }

        //回合操作
        public void 回合()
        {
            this.refresh();
            Console.WriteLine("请选择一个操作");
            Console.WriteLine("1、攻击\t2、结束回合\t3、打出牌\t4、抽一张牌\t5、查看日志");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    this.进攻();
                    break;
                case "2":
                    this.round = false;
                    foreach (int i in Program.range(team1_Entourage.Length))
                    {
                        team1_Entourage[i].attack_times = 1;
                    }
                    if (crystal_1_upper<10)
                    {
                        this.crystal_1_upper++;
                    }
                    this.crystal_1 = crystal_1_upper;
                    this.敌方回合();
                    break;
                case "3":
                    this.出牌();
                    break;
                case "4":
                    this.抽牌();
                    break;
                case "5":
                    foreach (string i in game_history)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("按任意键返回");
                    Console.ReadLine();
                    this.回合();
                    break;
                default:
                    Console.WriteLine("重新输");
                    this.回合();
                    break;
            }
        }

        //出一张牌
        public void 上牌(int card_number)//参数为出手牌的索引（第一个是0）
        {
            //判断两次，法力水晶够不够，战场满了没
            if (this.hand_card[card_number].crystal<=this.crystal_1)
            {
                if (this.team1_Entourage.Length + 1 <= 7)
                {
                    this.crystal_1 -= this.hand_card[card_number].crystal;
                    //战场加上
                    team1_Entourage = Method.加数组(team1_Entourage, this.hand_card[card_number]);
                    //手牌减去
                    this.hand_card = Method.减数组(this.hand_card, card_number);
                    
                }
                else
                {
                    Console.WriteLine("随从满了，不能加了，请按任意键继续");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("你的法力水晶不够！请按任意键继续");
                Console.ReadLine();
                this.回合();
            }
            this.refresh();
        }

        public void 出牌()
        {
            Console.WriteLine("请输入你想打出的牌的索引");
            int result = int.Parse(Console.ReadLine());
            if (result>=0&&result<this.hand_card.Length)
            {
                this.上牌(result);
            }
            else
            {
                Console.WriteLine("索引错误,请按任意键继续");
                Console.ReadLine();
            }
            
            this.回合();
        }


        //---------------------------------------------------------------------------------------
        //AI机器人
        //敌方回合
        public  void 敌方回合()
        {
            this.敌方抽牌();
            this.敌方出牌();
            this.敌方进攻();

            this.round = true;
            foreach (int i in Program.range(team0_Entourage.Length))
            {
                team0_Entourage[i].attack_times = 1;
            }
            if (crystal_0_upper < 10)
            {
                this.crystal_0_upper++;
            }
            this.crystal_0 = crystal_0_upper;
            this.war();
        }

        //电脑出牌
        public void 敌方出牌()
        {
            //出牌动作，判断法力水晶和出牌

            while (true)
            {
                int[] crystal = new int[this.hand_card1.Length];
                foreach (int i in Program.range(this.hand_card1.Length))
                {
                    crystal[i] = this.hand_card1[i].crystal;
                }
                if (crystal.Length == 0 || this.hand_card1[Method.最大值(crystal)].crystal > this.crystal_0)
                {
                    return;
                }
                else if (this.hand_card1[Method.最大值(crystal)].crystal <= this.crystal_0)
                {
                    this.game_history.Add("敌方出了一张" + this.hand_card1[Method.最大值(crystal)].card_name);
                    敌方上牌(Method.最大值(crystal));
                }
                //电脑出牌延迟
                Thread.Sleep(1000);
            }
        }

        public  void 敌方上牌(int card_number)//参数为出手牌的索引（第一个是0）
        {
            //战场满了没

            if (this.team0_Entourage.Length + 1 <= 7)
            {
                this.crystal_0 -= this.hand_card1[card_number].crystal;
                //战场加上
                this.team0_Entourage = Method.加数组(this.team0_Entourage, this.hand_card1[card_number]);
                //手牌减去
                this.hand_card1 = Method.减数组(this.hand_card1, card_number);

            }
            else
            {
                return;
            }
        }

        //电脑攻击
        public void 敌方进攻()
        {
            //全部a脸（更高级的AI不想写码在以后吧）
            if (this.team0_Entourage.Length != 0)
            {
                foreach (int i in Program.range(team0_Entourage.Length))
                {
                    if (team0_Entourage[i].attack_times != 0)
                    {
                        this.game_history.Add(team0_Entourage[i].card_name + "攻击了我方英雄" + team0_Entourage[i].card_attack + "血");
                        team1_hero.hero_blood -= team0_Entourage[i].card_attack;
                    }
                        
                    //电脑出牌延迟
                    Thread.Sleep(500);
                }
            }
            else
            {
                return;
            }


        }

        //抽牌
        public void 敌方抽牌()
        {
            if (Remaining_card.library.Length != 0)
            {
                this.加牌(hand_card1, round);
            }
            else
            { 
                this.Tired++;
                this.team1_hero.hero_blood -= this.Tired;
                game_history.Add("敌方没牌了，扣" + Tired + "滴血");
                Thread.Sleep(500);
            }
        }
    } 



}
