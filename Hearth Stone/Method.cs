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
    }
}
