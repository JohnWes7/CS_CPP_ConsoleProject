using System;
using System.Collections.Generic;

namespace 泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //delegate T 委托名<T> (T参数)；

            //C#提供好了两个泛型委托
            //这两个模板基本上可以适用于所有的委托
            //所以其实时不需要我们自定义
            //1.不带返回类型的泛型委托——Action
            //Action<类型1，类型2......类型n>参数列表是对应的参数类型
            //2.带返回类型的泛型委托——Func
            //Func<类型1，类型2......类型n>参数列表的末尾类型是作为返回类型使用

            Test(100,23.33f, ActionEvent);

            #region func演示
            List<int> list = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(1, 101));
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("----------------------------------------------");

            Sort(list, delegate (int a, int b) { return a - b; });

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("----------------------------------------------");

            Sort(list, (a, b) => b - a);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            #endregion




        }
        public static void Sort(List<int> list, Func<int, int, int> func)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i; j++)
                {
                    if (func(list[j], list[j + 1]) > 0)
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
        public static void ActionEvent(int a, float b)
        {
            Console.WriteLine(a + b);
        }
        public static void Test(int num, float num2, Action<int, float> action)
        {
            action(num, num2);
        }


    }



}
