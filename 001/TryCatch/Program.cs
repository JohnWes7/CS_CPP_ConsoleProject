using System;
using System.Collections.Generic;

namespace TryCatch
{
    class Program
    {
        static Stack<int> output = new Stack<int>();
        static void Main(string[] args)
        {
            int num = 0;
            int[] map = new int[20];
            Random r = new Random();

            


            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {

                Console.WriteLine("输入格式有误");
            }
            catch (OverflowException)
            {
                Console.WriteLine("输入超过了int的最大上限");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("null 引用（Visual Basic 中为 Nothing）传递到不接受其作为有效参数的方法时引发的异常。");
            }

            //for (int i = 0; i < 32; i++)
            //{
            //    output.Push(num & 1);
            //    num >>= 1;
            //}

            //while (true)
            //{
            //    int temp = output.Pop();
            //    if (temp==1)
            //    {
            //        Console.Write(temp);
            //        break;
            //    }
            //}

            Ten2Tow(num);

            int outputCount = output.Count;
            for (int i = 0; i < outputCount; i++)
            {
                Console.Write(output.Pop());
            }
            Console.WriteLine();

            //二分
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = r.Next(1, 21);
            }
            Array.Sort(map);
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write(map[i]+" ");
            }
            Console.WriteLine();

            Console.WriteLine(Find(map, num));

        }
        static void Ten2Tow(int x)
        {
            if (x >> 1 == 0)
            {
                output.Push(x % 2);
                return;
            }
            else
            {
                output.Push(x % 2);
                Ten2Tow(x >> 1);
            }
        }
        static int Find(int[] map, int target)
        {
            int l, r;
            l = 0;
            r = map.Length - 1;


            while (true)
            {

                int m = (l + r) >> 1;

                if (map[m] == target)
                {
                    return m+1;
                }
                else if (map[m] > target)
                {
                    r = m-1;
                }
                else if (map[m] < target)
                {
                    l = m+1;
                }


                if (l > r)
                {
                    return -1;
                }



            }


            

        }
    }
}
