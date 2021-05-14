using System;
using System.Data;
using System.Dynamic;

namespace 运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "小明";
            int age = 18;
            Console.WriteLine("{0}{1}岁了", name, age);
            Console.WriteLine(name + age + "岁了\n");

            string email = "124621@qq.com";
            string address = "NYC";
            int salary = 8000;
            Console.WriteLine("姓名：{0}\n年龄：{1}\n邮箱：{2}\n家庭住址：{3}\n期望工资：{4}\n", name, age, email, address, salary);


            Console.WriteLine("今年的年龄为:{0}", age);
            age += 10;
            Console.WriteLine("十年后的年龄为:" + age);

            float r = 5;
            const float pi = 3.1415f;
            float c, s;
            s = r * 2 * pi;
            c = r * r * pi;
            Console.WriteLine("圆的面积为：{0}，圆的周长为：{1}\n", s, c);

            int wan = 20, li = 10;
            wan += li;
            li = wan - li;
            wan -= li;
            Console.WriteLine("王：" + wan + "李：" + li + "\n");

            float cSharp = 78;
            float math = 69;
            float unity = 80;
            float sum = cSharp + math + unity;
            float avg = sum / 3;
            Console.WriteLine("三门课的总分为：" + sum);
            Console.WriteLine("三门课的平均分为：" + avg + "\n");

            float tShirt = 285;
            float pants = 720;
            float cost = 2 * tShirt + 3 * pants;
            Console.WriteLine("不打折应付：" + cost);
            cost = cost * 0.38f;
            Console.WriteLine("打折后应付" + cost + "\n");

            //int cin;
            //cin = Console.Read();
            //Console.WriteLine(cin);

            //Console.WriteLine("请输入账号：");
            //string account = Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string password = Console.ReadLine();
            //Console.WriteLine("你的账户为："+account+"\n你的密码为："+password);

            //       \a警报声 \b退格键但后面一定要跟有东西 \0空字符
            //string num1 = Console.ReadLine();
            //string num2 = Console.ReadLine();
            //int a, b;
            //a = Convert.ToInt32(num1);
            //Console.WriteLine(a);

        }
    }
}
