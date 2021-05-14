using System;

namespace chess
{
    class Program
    {
        static void Main(string[] args)
         {
            int a = 'a' , d;
            char b = (char)a;
            d = sizeof(bool);
            Console.WriteLine("{0}  {1}  {2}",a,b,d);
            #region 棋盘打印
            for (int i = 1; i <= 64; i++)
            {
                if (((i - 1) / 8) % 2 == 0)
                {
                    if (i % 2 != 0) Console.Write("■");
                    else Console.Write("□");
                }
                else
                {
                    if (i % 2 != 0) Console.Write("□");
                    else Console.Write("■");
                }
                if (i % 8 == 0) Console.Write("\n");
            }
            #endregion
            Console.ReadKey(true);
        }
    }
}
