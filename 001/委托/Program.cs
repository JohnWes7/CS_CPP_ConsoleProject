using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace 委托
{
    //泛型数据结构 
    //List<T>  Dictionary<Key T, value T>  Stack<T>  Queue<T> LinkedList<T>

    class Program
    {
        public delegate void MyDelegate();
        public delegate int SortDelegate(int a, int b);
        delegate int D(int i);

        static void Main(string[] args)
        {

            //委托
            //  是方法的载体（引用），可以承载（一个或者多个）方法
            //  是一种特殊的数据类型，专门用来存储方法的
            //  所有委托都派生自System.Delegate类

            //  委托可以让我们把方法当作变量使用
            //  解决了很多代码冗余的问题，也解决了方法回调的问题

            //委托的定义
            //  访问修饰符 delegate 返回类型 委托类型名 （参数列表）；

            //委托类型名 变量名 = new 委托类型（返回类型与参数列表一致的方法）；
            //在装载方法的时候不要写括号

            //委托的赋值
            //  委托变量名 = 返回类型与参数列表一致的方法

            //委托的调用
            //  委托变量名（参数）；
            //  委托变量名.Invoke（参数）

            //列表的查找速度比链表快
            //链表的修改速度比列表快

            //是一种复杂的数据类型，需要我们先定义出来
            //定义好类型后，声明委托的变量来使用
            //可以装载方法
            //只可以装载具有相同返回类型和参数列表一致的方法
            //委托变量名（参数列表）；
            //委托变量名.Invoke（参数列表）；

            //回调
            //把委托变量传入方法中去调用
            #region 委托案例
            //Random d6 = new Random();
            //List<int> list = new List<int>();
            //LinkedList<int> lianbiao = new LinkedList<int>();
            //MyDelegate myDelegate = new MyDelegate(Test);

            //myDelegate();

            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(d6.Next(0, 101));
            //}
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + " ");
            //}
            //Console.WriteLine();

            //SortDelegate del = DownSort;
            //Sort(list, del);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + " ");
            //} 
            #endregion

            //委托的注册与注销
            #region 案例二
            //MyDelegate del = Test;

            //del += Test2;
            //del += Test3;
            ////del -= Test2;

            //del = Test;

            //del.Invoke(); 
            #endregion
            //委托的注册
            //      委托名+=方法名   就可以将多个方法注册进委托变量中
            //委托的注销
            //      委托名-=方法名    就可以将方法从委托队列中删除

            //      注意！委托变量一旦重新赋值，以前的引用方法全部消失
            //      可以使用委托变量=null全部清空方法列表 （小心空引用报错）

            //委托的本质
            //      就是方法引用的队列，先进先出，一旦调用会把队列中所有的方法执行完

            #region 委托题 下课
            Teacher teacher = new Teacher();
            Student xiaoming = new Student("小明", "去毛东西");
            Student xiaozhang = new Student("小张", "去打水");
            Student xiaohong = new Student("小红", "开始练习");
            Student xiaohua = new Student("小花", "去打羽毛球");

            teacher.eventStudentDoing += xiaoming.Doing;


            //teacher.studentDoing += xiaoming.Doing;
            //teacher.studentDoing += xiaozhang.Doing;
            //teacher.studentDoing += xiaohong.Doing;
            //teacher.studentDoing += xiaohua.Doing;

            //teacher.ClassOver();


            #endregion

            //为了委托变量的安全性，我们应该取消委托变量的public
            //使用两个方法作为接口公开给外部使用
            //
            //编写注册与注销方法，同构委托类型的参数来传参
            //这样我们就可以管这个委托变量叫事件
            //
            //C#为了方便我们快速封装委托，就出现了event关键字
            //这样我这个委托变量就算公开出去，外部也只能进行注册与注销
            //只能自身调用这个事件


            //匿名方法
            //通常和委托变量搭配使用
            //方便我们快速对委托变量进行传参
            //delegate（参数列表）{ 方法体 }

            //lambda表达式
            //（参数列表）=>{ 方法体 }
            //当你的方法体只有一条语句时，可以不写return，甚至连花括号也可以省略
            //当方法体里面一旦出现了return，必须加上花括号

            //观察者模式
            //一群对象在观察另外一个对象的行为，当这个对象的行为达成一定条件，则触发了一群对象的反应
            //要做到以上功能，要搭配事件使用
            //要做到以上功能，要搭配事件使用
            //把一群对象的反应行为注册到被观察的对象的事件中去

            V(new D(P).Invoke(5));

        }
        public static void Test2()
        {
            Console.WriteLine("这是测试委托的方法2");
        }
        public static void Test3()
        {
            Console.WriteLine("这是测试委托的方法3");
        }
        public static void Sort(List<int> list, SortDelegate del)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i; j++)
                {
                    if (del.Invoke(list[j], list[j + 1]) > 0)
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
        public static void Test()
        {
            Console.WriteLine("这是测试委托的方法");
        }
        public static int UpSort(int a, int b)
        {
            return a - b;
        }
        public static int DownSort(int a, int b)
        {
            return b - a;
        }

        public static int P(int i)
        {
            return 21;
        }
        public static void V(int t)
        {

        }


    }
}
