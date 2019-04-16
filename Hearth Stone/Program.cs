using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class Program
    {
        static void Main(string[] args)
        { 
            Hero h = new Hero(0);
            console c = new console(h);
            c.display();
        }

        public static int[] range(int a)
        {
            int[] number = new int[a];
            for (int i =0; i<number.Length;i++)
            {
                number[i] = i;
            }
            return number;
        }
    }
}
