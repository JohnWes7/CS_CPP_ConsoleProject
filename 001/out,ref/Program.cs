using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics.SymbolStore;

namespace out_ref
{
    //out 可以使用数组或结构体返回多个数据，也可以使用基本数据类型返回单一数据
    //      被out修饰的参数在函数内部是需要被赋值的参数
    //      在函数调用的时候，out参数前一定要加out
    //ref 使用变量的地址
    //      直接修改值类型实参的值
    //      变量如果使用ref进行传参，必须先赋值
    //params 可变参数传参，在函数定义的时候在参数前加上
    //              被params修饰的必须是数组类型（int数组string数组结构体数组）
    //              必须放在最后一位
    //
    //当参数列表不一致时
    //则同名参数构成重载

    struct Fighter
    {
        public int atk;
        public int health;

        public void Fight(ref Fighter x)
        {
            x.health -= this.atk;
        }

    }

    class P
    {
        string name;
    }



    class Program
    {

        static void Main(string[] args)
        {


            int n;
            P p;
            p = new P();

            #region 登录 out练习
            //bool login;
            //Console.WriteLine("请输入用户名");
            //string account = Console.ReadLine();
            //Console.WriteLine("请输入密码");
            //string password = Console.ReadLine();
            //string loginInfo;

            //login = Login(account, password, out loginInfo);

            //Console.WriteLine(loginInfo); 
            #endregion

            #region 工资 ref练习
            //int salary = 5000;
            //Console.WriteLine(salary);

            //AddSalary(ref salary);
            //Console.WriteLine(salary);

            //PenaltySalary(ref salary);
            //Console.WriteLine(salary); 
            #endregion

            #region swap
            //int a = 10;
            //int b = 5;

            //Console.WriteLine("a:{0}   b:{1}", a, b);

            //swap(ref a, ref b);

            //Console.WriteLine("a:{0}   b:{1}", a, b);
            #endregion

            #region ref 结构体
            //Fighter xiaoming = new Fighter();
            //xiaoming.atk = 100;
            //xiaoming.health = 500;

            //Fighter xiaohua = new Fighter();
            //xiaohua.health = 1000;
            //xiaohua.atk = 70;

            //while (true)
            //{
            //    xiaoming.Fight(ref xiaohua);
            //    if (xiaohua.health <= 0)
            //    {
            //        Console.WriteLine("小花被小明活活打死了");
            //        break;
            //    }

            //    Console.SetCursorPosition(0, 2);
            //    Console.WriteLine("小明：血量{0}\t攻击力{1}\t", xiaoming.health, xiaoming.atk);



            //    if (xiaoming.health <= 0)
            //    {
            //        Console.WriteLine("小花终于战胜了小明");
            //        break;
            //    }
            //} 
            #endregion

            #region params
            //GetIntArrSum(1, 23, 4, 5, 4, 5, 6, 7, 8);

            #endregion

            test(ref p);
        }

        public static void test(ref P a)
        {

        }
        static bool Login(string userName, string passWord, out string loginInfo)
        {
            loginInfo = "";
            if (userName == "admin" && passWord == "888888")
            {
                loginInfo = "登陆成功";
                return true;
            }
            else
            {
                if (userName != "admin")
                {
                    loginInfo = "账号错误";

                }
                if (passWord != "888888")
                {
                    loginInfo += "密码错误";
                }
                return false;
            }
        }

        static void AddSalary(ref int salary)
        {
            salary += 500;
        }

        static void PenaltySalary(ref int salary)
        {
            salary -= 500;
        }

        static void swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }

        static void GetIntArrSum(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine(sum);

        }

    }
}
