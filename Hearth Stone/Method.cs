using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    static class Method
    {
        //数字半角转全角
        public static char 数字半转全(char i)
        {
            switch (i)
            {
                case '0':
                    return '０';
                    break;
                case '1':
                    return '１';
                    break;
                case '2':
                    return '２';
                    break;
                case '3':
                    return '３';
                    break;
                case '4':
                    return '４';
                    break;
                case '5':
                    return '５';
                    break;
                case '6':
                    return '６';
                    break;
                case '7':
                    return '７';
                    break;
                case '8':
                    return '８';
                    break;
                case '9':
                    return '９';
                    break;
                default:
                    return ' ';
            }
        }
        public static char 数字半转全(int i)
        {
            switch (i)
            {
                case 0:
                    return '０';
                    break;
                case 1:
                    return '１';
                    break;
                case 2:
                    return '２';
                    break;
                case 3:
                    return '３';
                    break;
                case 4:
                    return '４';
                    break;
                case 5:
                    return '５';
                    break;
                case 6:
                    return '６';
                    break;
                case 7:
                    return '７';
                    break;
                case 8:
                    return '８';
                    break;
                case 9:
                    return '９';
                    break;
                default:
                    return ' ';
            }
        }

        //等长数组和不等长数组转换__char
        public static char[][] 等长转不等长(char[,] a)
        {
            char[][] b = new char[a.GetLength(0)][];
            foreach (int j in Program.range(a.Rank-1)) { 
                foreach (int i in Program.range(a.GetLength(j)))
                {
                    b[i] = console.取一维数组(a,i);
                }
            }
            return b;
        }

        //攻击方法
        public static Card[][] attack(Card[] A,int i, Card[] B,int j)
        {
            B[j].card_blood = B[j].card_blood - A[i].card_attack;
            A[i].card_blood = A[i].card_blood - B[j].card_attack;
            if (B[j].card_blood <= 0)
            {
                B[j].Alive = false;
                B = 减数组(B,j);
            }
            if (A[i].card_blood <= 0)
            {
                A[i].Alive = false;
                A = 减数组(A, i);
            }
            Card[][] Entourage = new Card[2][];
            Entourage[0] = A;
            Entourage[1] = B;
            return Entourage;
        }

        //输出一个二维数组
        public static void 输出二维数组(char[,] array)
        {
            foreach (int i in Program.range(array.GetLength(0)))
            {
                foreach (int j in Program.range(array.GetLength(1)))
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }

        //一个数组减一个元素
        public static Card[] 减数组(Card[] big,int reduce)
        {
            Card[] new_big = new Card[big.Length-1];
            int i = 0;
            int j = 0;
            for (;i<new_big.Length;j++ )
            {
                if (i==reduce)
                {
                    reduce = -1;
                    continue;
                }
                new_big[i] = big[j];
                i++;
            }
            return new_big;
        }
    }
}
