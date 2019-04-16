using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] a = new char[1, 5];
            渲染边框(a);
            foreach (int i in Program.range(a.GetLength(0)))
            {
                foreach (int j in Program.range(a.GetLength(1)))
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int[] range(int a)
        {
            int[] number = new int[a];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }
            return number;
        }

        public static void 渲染边框(char[,] a)
        {
            foreach (int i in Program.range(a.GetLength(1)))
            {
                a[a.GetLowerBound(0), i] = '－';
            }

            for (int i = 1; i < a.GetLength(0) - 1; i++)
            {
                //二维数组取下限和上限
                a[i, a.GetUpperBound(1)] = '｜';
                a[i, a.GetLowerBound(1)] = '｜';
            }

            foreach (int i in Program.range(a.GetLength(1)))
            {
                a[a.GetUpperBound(0), i] = '－';
            }

        }
    }

}
