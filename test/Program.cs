using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test
{
    class Program
    {
        public static int a = 0;

        static void Main(string[] args)
        { 
            Thread th = new Thread(判断);
            th.Start();
            while (true)
            {
                if (a==10)
                {
                    Console.WriteLine("到10了");
                    th.Abort();
                    return;
                }
                
                Thread.Sleep(500);
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
        
        public static void 判断()
        {
            while (true)
            {
                a += 1;
                Console.WriteLine(a);
                Thread.Sleep(1000);
            }
        } 
    } 
 }


