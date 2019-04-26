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
            int[] i = new int[0];
            if (i==null)
            {
                Console.WriteLine("给哈哈哈");
            }
            Console.WriteLine(i);

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

        public static void 结构体(c[] stu)
        {
            c[] cc1 = new c[2];
            c c1 = new c(9,"sasa");
            cc1[0] = c1;
            cc1[1] = c1;
            stu = cc1;
        }
    }

    struct c
    {
        public int a;
        public string b;


        public c(int a0,string b0)
        {
            this.a = a0;
            this.b = b0;
        }
    }
    
 }


