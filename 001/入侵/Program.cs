using System;
using System.Diagnostics;

namespace 入侵
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            x = 5;
            y = 5;


            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(x);

            //Console.SetCursorPosition(x * 2, y);
            //Console.WriteLine("▼");
            #region 行动
            //while (true)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(x * 2, y);
            //    Console.WriteLine("▼");

            //    char wasd = Console.ReadKey(true).KeyChar;
            //    switch (wasd)
            //    {
            //        case 'w':
            //            y -= 1;
            //            if (y < 0)
            //            {
            //                y = 0;
            //            }
            //            break;
            //        case 'a':
            //            x -= 1;
            //            if (x < 0)
            //            {
            //                x = 0;
            //            }
            //            break;
            //        case 's':
            //            y += 1;
            //            break;
            //        case 'd':
            //            x += 1;
            //            if (x > 50)
            //            {
            //                x = 50;
            //            }
            //            break;
            //    }




            //}
            #endregion


        }
    }
}
