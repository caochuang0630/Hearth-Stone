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
            int[][] a = new int[5][];
            int[] b = new int[] { 3, 4 };
            a[2] = b;
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

        public static void change(string[] big,string[] small)
        {
            int i = (big.Length - small.Length) / 2;
            foreach (int j in range(small.Length))
            {
                big[i + j] = small[j];
            }
            
        }
    }

}
