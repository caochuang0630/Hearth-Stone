using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearth_Stone
{
    class display
    {
        //显示胜利
        public static void 胜利()
        {
            char[,] start_display = new char[3, 20];
            console.填充空格(start_display);
            console.渲染边框(start_display);
            foreach (int i in Program.range(start_display.GetLength(1)))
            {
                start_display[1, i] = console.居中(console.取一维数组(start_display, 1), "胜利！".ToCharArray())[i];
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Method.输出二维数组(start_display);      
        }

        public static void 败北()
        {
            char[,] start_display = new char[3, 20];
            console.填充空格(start_display);
            console.渲染边框(start_display);
            foreach (int i in Program.range(start_display.GetLength(1)))
            {
                start_display[1, i] = console.居中(console.取一维数组(start_display, 1), "败北！".ToCharArray())[i];
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Method.输出二维数组(start_display);
        }
    }
}
