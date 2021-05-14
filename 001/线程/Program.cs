using System;
using System.Threading;

namespace 线程
{
    class Program
    {
        //开启多线
        //1.需要using System.Threading
        //2.需要定义一个开启的方法
        //3.需要建立一个线程对象，来装嵌你的方法
        //Thread t = new Thread（方法名）
        //注意方法不能带返回值

        //4.开启线程 线程名.Start（）；
        //5.新线程的生命周期
        //从Start（）开始，到转载进去的方法执行完毕结束

        //这样的话就算你在方法里用死循环，也不会卡死主函数
        //Thread.Sleep(毫秒数) 可以让这条语句所在的线程暂停对应的毫秒数，然后再接着执行

        //关闭线程方法Abort
        //线程名.Abort

        static void Main(string[] args)
        {
            Thread t = new Thread(Test);

            t.Start();

            Console.WriteLine("这是主函数的线程");
        }

        public static void Test()
        {
            while (true)
            {
                Console.WriteLine("这是其他线程");
            }
        }

    }
}
