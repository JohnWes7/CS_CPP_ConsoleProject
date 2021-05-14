using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;

//程序的东西，你不能生成了，就不管了
//必须要有数据结构去管理他


namespace 第二周
{
    enum QQSta
    {
        Qme,
        Online,
        Offline,
        Leave,
        Buzy
    }


    //结构体中static用：  类型名称.静态成员调用
    //非静态：对象名.成员调用
    struct WarShipGirl
    {
        public string name;
        public int hp;
        public int atk;

        public void Attack(WarShipGirl warShipGirl)
        {
            warShipGirl.hp -= this.atk;
        }
    }
    //传参：值类型，引用类型
    //值类型：存在栈中
    //引用类型：存在堆中，地址存在栈中

    //值类型传参特征：去栈中复制了一份值
    //引用类型传参特征：因为复制的地址，而地址指向的一个空间，所以会改变原内容

    //为了让值类型传参可以修改原内容：ref关键字
    //使用：
    //1，定义函数的参数列表是，把你想要的值类型的那个参数前加上ref
    //2，在调用方法时，在传递参数的时候，依然也要写上ref

    struct Student
    {
        public string name;
        public string sex;
        public int age;
        public string hobby;

    }
    //结构体中不能包含自己
    //包含自己会无限展开，把栈堆满，导致爆栈
    //但是可以包含其他结构体的成员不会无限展开
    struct Vector2
    {
        public int x;
        public int y;
        public static Vector2 Add(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;
        }
    }

    struct Rect
    {
        public Vector2 size;
        public Vector2 position;
    }

    struct SumMaxMinAvg
    {
        public int sum;
        public int max;
        public int min;
        public float avg;
        public void tool(int[] a)
        {
            this.sum = 0;
            this.max = a[0];
            this.min = a[0];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                this.sum += a[i];
                if (a[i] > this.max)
                {
                    this.max = a[i];
                }
                if (a[i] < this.min)
                {
                    this.min = a[i];
                }
            }

            this.avg = (float)this.sum / a.GetLength(0);



        }



    }

    public struct NumInfo
    {
        public int sum;
        public int evenSum;
        public int oddSum;

    }

    //结构体也有构造函数
    //也可以重载
    //只能重载有参的构造函数
    //在构造函数中必须对结构体的每个属性赋值


    class Program
    {

        static void Main(string[] args)
        {


            #region 水仙花数
            //Console.WriteLine("100到999水仙花数一共有：");
            //for (int i = 100; i < 1000; i++)
            //{
            //    int num = i;
            //    int units = num % 10;
            //    num = num / 10;
            //    int tens = num % 10;
            //    num = num / 10;
            //    int hundreds = num % 10;
            //    if (i == (units * units * units + tens * tens * tens + hundreds * hundreds * hundreds))
            //    {
            //        Console.WriteLine(i);
            //    }

            //} 
            #endregion

            #region for打印
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (i == 0 || i == 9)
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            if (j == 0 || j == 9)
            //            {
            //                Console.Write("*");
            //            }
            //            else
            //            {
            //                Console.Write(" ");
            //            }
            //        }
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            #region 三角形阵列
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < i + 1; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region 打印X
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (i == j || j + i == 9)
            //        {
            //            Console.Write("* ");

            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            #region 枚举应用
            //QQSta myQQSta;
            //int input = 0;
            //bool jugdeInput;
            //Console.WriteLine("1.Qme,    2.Online,    3. Offline,    4.Leave,    5.Buzy");
            //do
            //{
            //    jugdeInput = int.TryParse(Console.ReadLine(), out input);

            //} while (!jugdeInput);

            //myQQSta = (QQSta)input - 1;
            //Console.WriteLine("现在你的状态为：" + myQQSta); 
            #endregion

            #region 枚举的转换
            //QQSta myQQSta;
            //string temp = "Online";
            ////字符串转枚举
            //myQQSta = (QQSta)Enum.Parse(typeof(QQSta), temp);
            //Console.WriteLine(myQQSta);
            ////枚举转字符串
            //myQQSta = QQSta.Buzy;
            //temp = myQQSta.ToString();
            //Console.WriteLine(temp); 
            #endregion

            #region 结构体练习
            //    Student xiaoming = new Student();
            //    xiaoming.age = 18;
            //    xiaoming.hobby = "手铳";
            //    xiaoming.name = "小明";
            //    xiaoming.sex = "男";
            //    Console.WriteLine("我叫{0}，{1}，今年{2}，爱好是{3}", xiaoming.name, xiaoming.sex, xiaoming.age, xiaoming.hobby);
            // 
            #endregion

            #region Rect结构体
            //Rect r = new Rect();
            //r.size.x = 10;
            //r.size.y = 5;
            //r.position.x = 5;
            //r.position.y = 5;

            //while (true)
            //{

            //    Console.Clear();
            //    for (int i = 0; i < r.size.x; i++)
            //    {
            //        for (int j = 0; j < r.size.y; j++)
            //        {
            //            Console.SetCursorPosition((r.position.x + i) * 2, r.position.y + j);
            //            Console.WriteLine("*");
            //        }
            //    }

            //    ConsoleKey key = Console.ReadKey(true).Key;
            //    switch (key)
            //    {
            //        case ConsoleKey.Backspace:
            //            break;
            //        case ConsoleKey.Tab:
            //            break;
            //        case ConsoleKey.Clear:
            //            break;
            //        case ConsoleKey.Enter:
            //            break;
            //        case ConsoleKey.Pause:
            //            break;
            //        case ConsoleKey.Escape:
            //            break;
            //        case ConsoleKey.Spacebar:
            //            break;
            //        case ConsoleKey.PageUp:
            //            break;
            //        case ConsoleKey.PageDown:
            //            break;
            //        case ConsoleKey.End:
            //            break;
            //        case ConsoleKey.Home:
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            break;
            //        case ConsoleKey.UpArrow:
            //            break;
            //        case ConsoleKey.RightArrow:
            //            break;
            //        case ConsoleKey.DownArrow:
            //            break;
            //        case ConsoleKey.Select:
            //            break;
            //        case ConsoleKey.Print:
            //            break;
            //        case ConsoleKey.Execute:
            //            break;
            //        case ConsoleKey.PrintScreen:
            //            break;
            //        case ConsoleKey.Insert:
            //            break;
            //        case ConsoleKey.Delete:
            //            break;
            //        case ConsoleKey.Help:
            //            break;
            //        case ConsoleKey.D0:
            //            break;
            //        case ConsoleKey.D1:
            //            break;
            //        case ConsoleKey.D2:
            //            break;
            //        case ConsoleKey.D3:
            //            break;
            //        case ConsoleKey.D4:
            //            break;
            //        case ConsoleKey.D5:
            //            break;
            //        case ConsoleKey.D6:
            //            break;
            //        case ConsoleKey.D7:
            //            break;
            //        case ConsoleKey.D8:
            //            break;
            //        case ConsoleKey.D9:
            //            break;
            //        case ConsoleKey.A:
            //            r.position.x -= 1;
            //            break;
            //        case ConsoleKey.B:
            //            break;
            //        case ConsoleKey.C:
            //            break;
            //        case ConsoleKey.D:
            //            r.position.x += 1;
            //            break;
            //        case ConsoleKey.E:
            //            break;
            //        case ConsoleKey.F:
            //            break;
            //        case ConsoleKey.G:
            //            break;
            //        case ConsoleKey.H:
            //            break;
            //        case ConsoleKey.I:
            //            break;
            //        case ConsoleKey.J:
            //            break;
            //        case ConsoleKey.K:
            //            break;
            //        case ConsoleKey.L:
            //            break;
            //        case ConsoleKey.M:
            //            break;
            //        case ConsoleKey.N:
            //            break;
            //        case ConsoleKey.O:
            //            break;
            //        case ConsoleKey.P:
            //            break;
            //        case ConsoleKey.Q:
            //            break;
            //        case ConsoleKey.R:
            //            break;
            //        case ConsoleKey.S:
            //            r.position.y += 1;
            //            break;
            //        case ConsoleKey.T:
            //            break;
            //        case ConsoleKey.U:
            //            break;
            //        case ConsoleKey.V:
            //            break;
            //        case ConsoleKey.W:
            //            r.position.y -= 1;
            //            break;
            //        case ConsoleKey.X:
            //            break;
            //        case ConsoleKey.Y:
            //            break;
            //        case ConsoleKey.Z:
            //            break;
            //        case ConsoleKey.LeftWindows:
            //            break;
            //        case ConsoleKey.RightWindows:
            //            break;
            //        case ConsoleKey.Applications:
            //            break;
            //        case ConsoleKey.Sleep:
            //            break;
            //        case ConsoleKey.NumPad0:
            //            break;
            //        case ConsoleKey.NumPad1:
            //            break;
            //        case ConsoleKey.NumPad2:
            //            break;
            //        case ConsoleKey.NumPad3:
            //            break;
            //        case ConsoleKey.NumPad4:
            //            break;
            //        case ConsoleKey.NumPad5:
            //            break;
            //        case ConsoleKey.NumPad6:
            //            break;
            //        case ConsoleKey.NumPad7:
            //            break;
            //        case ConsoleKey.NumPad8:
            //            break;
            //        case ConsoleKey.NumPad9:
            //            break;
            //        case ConsoleKey.Multiply:
            //            break;
            //        case ConsoleKey.Add:
            //            break;
            //        case ConsoleKey.Separator:
            //            break;
            //        case ConsoleKey.Subtract:
            //            break;
            //        case ConsoleKey.Decimal:
            //            break;
            //        case ConsoleKey.Divide:
            //            break;
            //        case ConsoleKey.F1:
            //            break;
            //        case ConsoleKey.F2:
            //            break;
            //        case ConsoleKey.F3:
            //            break;
            //        case ConsoleKey.F4:
            //            break;
            //        case ConsoleKey.F5:
            //            break;
            //        case ConsoleKey.F6:
            //            break;
            //        case ConsoleKey.F7:
            //            break;
            //        case ConsoleKey.F8:
            //            break;
            //        case ConsoleKey.F9:
            //            break;
            //        case ConsoleKey.F10:
            //            break;
            //        case ConsoleKey.F11:
            //            break;
            //        case ConsoleKey.F12:
            //            break;
            //        case ConsoleKey.F13:
            //            break;
            //        case ConsoleKey.F14:
            //            break;
            //        case ConsoleKey.F15:
            //            break;
            //        case ConsoleKey.F16:
            //            break;
            //        case ConsoleKey.F17:
            //            break;
            //        case ConsoleKey.F18:
            //            break;
            //        case ConsoleKey.F19:
            //            break;
            //        case ConsoleKey.F20:
            //            break;
            //        case ConsoleKey.F21:
            //            break;
            //        case ConsoleKey.F22:
            //            break;
            //        case ConsoleKey.F23:
            //            break;
            //        case ConsoleKey.F24:
            //            break;
            //        case ConsoleKey.BrowserBack:
            //            break;
            //        case ConsoleKey.BrowserForward:
            //            break;
            //        case ConsoleKey.BrowserRefresh:
            //            break;
            //        case ConsoleKey.BrowserStop:
            //            break;
            //        case ConsoleKey.BrowserSearch:
            //            break;
            //        case ConsoleKey.BrowserFavorites:
            //            break;
            //        case ConsoleKey.BrowserHome:
            //            break;
            //        case ConsoleKey.VolumeMute:
            //            break;
            //        case ConsoleKey.VolumeDown:
            //            break;
            //        case ConsoleKey.VolumeUp:
            //            break;
            //        case ConsoleKey.MediaNext:
            //            break;
            //        case ConsoleKey.MediaPrevious:
            //            break;
            //        case ConsoleKey.MediaStop:
            //            break;
            //        case ConsoleKey.MediaPlay:
            //            break;
            //        case ConsoleKey.LaunchMail:
            //            break;
            //        case ConsoleKey.LaunchMediaSelect:
            //            break;
            //        case ConsoleKey.LaunchApp1:
            //            break;
            //        case ConsoleKey.LaunchApp2:
            //            break;
            //        case ConsoleKey.Oem1:
            //            break;
            //        case ConsoleKey.OemPlus:
            //            break;
            //        case ConsoleKey.OemComma:
            //            break;
            //        case ConsoleKey.OemMinus:
            //            break;
            //        case ConsoleKey.OemPeriod:
            //            break;
            //        case ConsoleKey.Oem2:
            //            break;
            //        case ConsoleKey.Oem3:
            //            break;
            //        case ConsoleKey.Oem4:
            //            break;
            //        case ConsoleKey.Oem5:
            //            break;
            //        case ConsoleKey.Oem6:
            //            break;
            //        case ConsoleKey.Oem7:
            //            break;
            //        case ConsoleKey.Oem8:
            //            break;
            //        case ConsoleKey.Oem102:
            //            break;
            //        case ConsoleKey.Process:
            //            break;
            //        case ConsoleKey.Packet:
            //            break;
            //        case ConsoleKey.Attention:
            //            break;
            //        case ConsoleKey.CrSel:
            //            break;
            //        case ConsoleKey.ExSel:
            //            break;
            //        case ConsoleKey.EraseEndOfFile:
            //            break;
            //        case ConsoleKey.Play:
            //            break;
            //        case ConsoleKey.Zoom:
            //            break;
            //        case ConsoleKey.NoName:
            //            break;
            //        case ConsoleKey.Pa1:
            //            break;
            //        case ConsoleKey.OemClear:
            //            break;
            //        default:
            //            break;
            //    }


            //} 
            #endregion

            #region 数组
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Console.WriteLine(arr[2]);
            //Console.WriteLine();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            #endregion
            //数组的声明
            //数据类型[] 数组名;    （没有任何东西的空数组 没有空间）
            //数据类型[] 数组名=new 数据类型[长度]； 
            //数据类型[] 数组名={元素1，元素2，元素3.....}；
            //数据类型[] 数组名=new 数组类型[] {元素1，元素2，元素3.......}；
            //new 在内存中开辟空间，如果没有复制，则赋上默认值
            //
            //数组的属性
            //.length 代表数组的长度（通过对象dot出来非静态）
            //数据结构
            //       数据与数据之间的关系

            #region 数组第一题
            //int length = 20;
            //int[] numA = new int[length];
            //int[] numB = new int[length];

            //for (int i = 0; i < numA.GetLength(0); i++)
            //{
            //    numA[i] = i;
            //}

            //for (int i = 0; i < numA.GetLength(0); i++)
            //{
            //    numB[i] = numA[i] * 2;
            //    Console.WriteLine(numB[i]);
            //} 
            #endregion

            #region 数组第二题
            //Random d6 = new Random(0);
            //int length = 20;
            //int[] rollArr = new int[length];
            //int max = 0;
            //int min = 0;
            //int sum = 0;
            //float avg;


            //for (int i = 0; i < rollArr.GetLength(0); i++)
            //{
            //    rollArr[i] = d6.Next(0, 101);
            //    sum += rollArr[i];
            //    Console.WriteLine("{0}  {1}", i + 1, rollArr[i]);
            //    if (i == 0)
            //    {
            //        max = rollArr[0];
            //        min = rollArr[0];
            //    }
            //    else
            //    {
            //        if (rollArr[i] > max)
            //        {
            //            max = rollArr[i];
            //        }
            //        if (rollArr[i] < min)
            //        {
            //            min = rollArr[i];
            //        }
            //    }

            //}

            //avg = (float)sum / rollArr.Length;

            //Console.WriteLine("最大值为{0}，最小值为{1}，平均值为{2}，总和为{3}", max, min, avg, sum);

            //for (int i = 0; i < rollArr.Length / 2; i++)
            //{
            //    int temp = rollArr[i];
            //    rollArr[i] = rollArr[rollArr.Length - i - 1];
            //    rollArr[rollArr.Length - i - 1] = temp;
            //}

            //for (int i = 0; i < rollArr.Length; i++)
            //{
            //    Console.WriteLine("{0}  {1}", i + 1, rollArr[i]);
            //}


            //for (int i = 0; i < rollArr.Length; i++)
            //{
            //    if (i == 0)
            //    {
            //        Console.Write(rollArr[i]);
            //    }
            //    else
            //    {
            //        Console.Write("|" + rollArr[i]);
            //    }
            //} 
            #endregion

            #region 插入法排序

            //int length = 20;
            //int[] arr = new int[length];
            //int min = 0;
            //int max = 10;

            ////赋值
            //Assignment(arr, min, max);

            ////打印
            //PrintArr(arr);

            ////插入法排序
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    int temp = arr[i];
            //    int j;
            //    for (j = i - 1; j >= 0 && arr[j] > temp; j--)
            //    {
            //        arr[j + 1] = arr[j];
            //    }
            //    arr[j + 1] = temp;
            //}

            //Console.WriteLine();

            ////打印
            //PrintArr(arr);

            #endregion

            #region 冒泡发排序
            //int length = 20;
            //int[] arr = new int[length];
            //int min = 0;
            //int max = 100;

            ////给数组赋值
            //Assignment(arr, min, max);
            ////打印数组
            //PrintArr(arr);

            ////冒泡法排序
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    for (int j = 0; j < arr.Length - i - 1; j++)
            //    {
            //        if (arr[j] > arr[j + 1])
            //        {
            //            int temp = arr[j];
            //            arr[j] = arr[j + 1];
            //            arr[j + 1] = temp;
            //        }
            //    }
            //}

            //PrintArr(arr);
            #endregion

            #region 二维数组 第一题
            //int[,] arr = new int[5, 5];
            //int num = 1;

            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        arr[i, j] = num;
            //        num++;
            //    }
            //}

            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        Console.Write(arr[i, j] + "\t");

            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            #region 算对角线的数据和
            //int[,] a = new int[3, 3];
            //int min = 0;
            //int max = 10;
            //int sum = 0;

            //Assignment(a, min, max);
            //PrintArr(a);

            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    for (int j = 0; j < a.GetLength(1); j++)
            //    {
            //        if (i == j)
            //        {
            //            sum += a[i, j];

            //        }
            //        if (i + j == 2)
            //        {
            //            sum += a[i, j];
            //        }
            //    }
            //}

            //sum -= a[1, 1];
            //Console.WriteLine(sum); 
            #endregion


            //交错数组
            //             声明：
            //             数据类型[][] 数组名=new 数据类型[num][]{元素[]，new int[] {},}
            //             foreach(数据结构 元素 in 集合)
            //              {}
            //              item只能访问，不能修改
            //              会产生内存碎片消耗资源
            //              foreach(var )



            #region 交错数组
            //int[][] arr = new int[3][] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 1 } };

            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr[i].GetLength(0); j++)
            //    {
            //        Console.Write(arr[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            ////会产生内存垃圾，且GC不能完全回收
            //foreach(int[] x in arr)
            //{
            //    foreach (int item in x)
            //    {
            //        Console.Write(item+"\t");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            //写一个方法
            //第一步，考虑是否要静态的
            //如果说不是对象本身的行为就是静态的

            //比如喷火龙放个大字爆，是喷火龙本身的行为
            //所以应该是非静态的

            //不需要实例化的，唯一的，作为工具使用，就使用静态
            //比如两个数字相加的结果
            //控制台，控制台是唯一的，是一个工具，所以控制台下全部是静态的

            //第二步，考虑是否公开这个方法
            //public private protected

            //第三步，考虑是否需要返回值
            //不是所有的罗技都必须要求有返回值

            //第四步，用帕斯卡命名法

            //第五步，考虑需不需要参数，需要，需要几个，什么类型

            //作为实体对象的行为是非静态的
            //作为工具是静态的

            //在调用方法前，先定义出这个方法
            //1. 方法定义在结构体，类，接口中
            //2.方法的定义模板
            //static 访问修饰符 返回类型 方法名（形参列表）
            //{      
            //      代码序列
            //}
            //

            //可访问性
            //      （1） public：公开，谁都可以访问
            //      （2） private：私有，除了自己谁都不能访问，一般方法前没有写访问修饰符默认为private
            //      （3） protected：继承，只有自己和自己的派生系可以访问

            //构建方法前：先分清你的需求，是否需要静态的，是否需要公开，是否需要参数
            //在调用时，要传入对应的参数
            //值类型传参：把值类型数据的值直接赋值给对应的形参（局部变量），就算你修改新参的值也不会对外部的实际参数有影响
            //引用类型传参：形参复制的实参的地址，因为地址指向的同一块空间，所以你如果更改形参的数值，也会对实参做影响
            #region 静态方法
            //Vector2 a = new Vector2();
            //a.x = 5;
            //a.y = 5;
            //Vector2 b = new Vector2();
            //b.x = 10;
            //b.y = 10;

            //a = Vector2.Add(a, b);
            //Console.WriteLine("({0},{0})", a.x, a.y);
            #endregion

            #region 非静态方法
            //SumMaxMinAvg a = new SumMaxMinAvg();
            //int[] arr = new int[10];
            //Assignment(arr, 1, 100);

            //a.tool(arr);

            //Console.WriteLine("sum:{0} max:{1} min:{2} avg:{3}",a.sum,a.max,a.min,a.avg);



            #endregion

            #region array.sort
            //int[] arr = new int[10];
            //int max = 100;
            //int min = 0;
            //Assignment(arr, min, max);
            //PrintArr(arr);

            //Array.Sort(arr);

            //PrintArr(arr);
            #endregion

            #region 奇偶数和
            //NumInfo a = new NumInfo();
            //a = GetSum();
            //Console.WriteLine("整数和：{0}，偶数和：{1}，奇数和：{2}", a.sum, a.evenSum, a.oddSum); 
            #endregion

            #region 递归阶乘
            //int n = 5;
            //n = Factorial(n);
            //Console.WriteLine(n);
            #endregion

            #region 递归竹子
            //float n = 100;
            //int day = 10;

            //n = banboon(n, day);
            //Console.WriteLine(n);

            #endregion

            #region 函数综合练习一
            //bool judge;
            //int sum;


            //do
            //{
            //    Console.WriteLine("请输入第一个数字");
            //    int min = int.Parse(Console.ReadLine());
            //    Console.WriteLine("请输入第二个数字");
            //    int max = int.Parse(Console.ReadLine());
            //    judge = GetSum(min, max, out sum);
            //} while (!judge);

            //Console.WriteLine(sum);

            #endregion

            #region 函数综合练习二

            //string[] name = { "迈克尔乔丹", "马龙", "雷吉米勒", "科比布莱恩特", "蒂姆邓肯" };

            //string longestName = GetLongestSring(name);

            //Console.WriteLine("最长的是：{0}",longestName);


            #endregion

            #region 函数综合练习三
            //Console.WriteLine(GetAvg(5,3,4,6,6,7,8,1,7,7,5,32,7));

            #endregion

            #region 交换字符串数组
            //string[] arr = { "中国", "美国", "英国", "巴西", "澳大利亚", "加拿大" };

            //Reverse(arr);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //} 
            #endregion




        }




        /// <summary>
        /// 给一维数组赋随机值
        /// </summary>
        /// <param name="a">传入数组</param>
        /// <param name="min">赋值范围最小值</param>
        /// <param name="max">赋值范围最大值</param>
        static void Assignment(int[] a, int min, int max)
        {
            Random d6 = new Random();



            for (int i = 0; i < a.Length; i++)
            {
                a[i] = d6.Next(min, max + 1);
            }

        }

        /// <summary>
        /// 打印数组
        /// </summary>
        /// <param 传入数组="a"></param>
        static void PrintArr(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + "  ");
            }
            Console.WriteLine();
        }

        static void PrintArr(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 给二维数组赋随机值
        /// </summary>
        /// <param name="a">传入数组</param>
        /// <param name="min">赋值范围最小值</param>
        /// <param name="max">赋值范围最大值</param>
        static void Assignment(int[,] a, int min, int max)
        {
            Random d6 = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = d6.Next(min, max + 1);
                }
            }
        }

        static NumInfo GetSum()
        {
            NumInfo result = new NumInfo();
            result.sum = 0;
            result.evenSum = 0;
            result.oddSum = 0;

            for (int i = 1; i <= 100; i++)
            {
                result.sum += i;

                if (i % 2 == 0)
                {
                    result.evenSum += i;
                }
                else
                {
                    result.oddSum += i;
                }
            }


            return result;


        }

        static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static int AddFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Factorial(n) + AddFactorial(n - 1);
            }
        }

        static float banboon(float n, int day)
        {
            if (day == 0)
            {
                return n;
            }
            else
            {
                return banboon(n, day - 1) / 2;
            }//返回时才进行除法
        }

        static bool GetSum(int min, int max, out int sum)
        {
            sum = 0;
            bool jugde = true;
            if (min > max)
            {
                return jugde = false;

            }
            else
            {
                for (int i = min; i <= max; i++)
                {
                    sum += i;
                }
                return jugde;
            }
        }

        static string GetLongestSring(string[] a)
        {
            int max = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[max].Length<a[i].Length)
                {
                    max = i;
                }
            }

            return a[max];
        }

        static float GetAvg(params int[] arg)
        {
            float sum = 0;

            for (int i = 0; i < arg.Length; i++)
            {
                sum += arg[i];
            }

            
            float avg = sum / arg.Length;
            Console.WriteLine("in:{0}",avg);
            int temp = (int)(avg * 100);
            avg = (float)temp / 100;

            return avg;
        }

        static void Reverse(string[] arr)
        {
            for (int i = 0; i < arr.Length/2; i++)
            {
                string temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }


        }
        


    }
}
