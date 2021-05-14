using System;
using System.Diagnostics.CodeAnalysis;

namespace 继承
{
    //C#中所有类的最终基类都是object类
    //一个类只能直接继承一个基类
    //声明
    //  访问修饰符 class 派生类名：基类名  {   }
    //特征
    //  1.一个类只能直接继承一个基类
    //  2.派生类拥有基类所有属性和方法
    //  3.基类的访问域，如果基类的成员不允许子类访问，子类是访问不到的
    //  4.子类会默认调用父类的默认构造函数
    //  5.如果你的类没有父类，将默认继承Object类

    //base与this
    //      this关键字指向自身的实例或者自身构造函数
    //      base关键字指向父类实例或者父类的构造函数

    //new
    //  1.实例化对象
    //  2.为子类的成员申请一个新的空间
    //
    //  如果子类中有成员与父类的成员重名，可以用new关键字为子类的这个成员
    //  申请一个新的空间，以便计算机识别，如果不屑，将默认启用new

    class Person
    {
        public string name;
        public string sex;
        public int age;
        public string hobby;

        public Person(string name, string sex, int age, string hobby)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.hobby = hobby;
            Console.WriteLine("我是person基类");
        }


        public void SayHello()
        {
            Console.WriteLine("我叫{0}，今年{1}岁了，性别是{2}，爱好是{3}", name, age, sex, hobby);
        }

    }

    class Reporter : Person
    {
        new string name;
        public Reporter(string name, string sex, int age, string hobby) : base(name, sex, age, hobby)
        {
            this.name = "1";
        }

        public void photo()
        {
            Console.WriteLine("{0}正在偷拍", name);
        }
    }

    class Drive : Person
    {
        public Drive(string name, string sex, int age, string hobby) : base(name, sex, age, hobby)
        {

        }

        public void PlayBasketball()
        {
            Console.WriteLine("{0}正在打篮球", name);
        }
    }

    class Programmer : Person
    {
        public Programmer(string name, string sex, int age, string hobby) : base(name, sex, age, hobby)
        {

        }
        public void WatchMovie()
        {
            Console.WriteLine("{0}在看电影", name);
        }
    }

    //特性
    class Student : Person
    {
        public int csharp;
        public int unity;

        public Student(string name, string sex, int age, string hobby) : base(name, sex, age, hobby)
        {

        }

        public void GetScoer()
        {
            Console.WriteLine("{0}的总分为{1}", name, csharp + unity);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            #region 案例
            //Student xiaoming = new Student();
            //xiaoming.name = "小明";
            //xiaoming.sex = "男";
            //xiaoming.age = 18;
            //xiaoming.csharp = 80;
            //xiaoming.unity = 75;

            //xiaoming.SayHello();
            //xiaoming.GetScoer(); 
            #endregion

            #region 继承构造函数

            //Reporter gouzai = new Reporter("狗仔", "男", 34, "偷怕");
            //Drive zhangsan = new Drive("张三", "男", 43, "打篮球");
            //Programmer lisi = new Programmer("李思思", "女", 23, "看电影");

            //Console.WriteLine(gouzai.name);

            //gouzai.SayHello();
            //zhangsan.SayHello();
            //lisi.SayHello();

            //gouzai.photo();
            //zhangsan.PlayBasketball();
            //lisi.WatchMovie();
            #endregion

            //子类可以当父类去使用（因为子类拿到了父类的所有内容）
            //如果父类中装的是子类对象，我们可以将它强制转换成子类对象拿去使用（因为父类盒子了装的就是子类的内容）
            #region 里氏转化

            //Programmer lisi = new Programmer("李思思", "女", 23, "看电影");
            //Person person1=new Person("狗仔", "男", 34, "偷怕");

            //Person person = lisi;
            ////((Programmer)person).WatchMovie();

            //if (person is Programmer)
            //{
            //    Console.WriteLine("{0}可以转",person.name);
            //    Programmer g = person as Programmer;
            //    g.WatchMovie();
            //}
            //else
            //{
            //    Console.WriteLine("{0}不能",person.name);
            //}

            //if (person1 is Programmer  )
            //{
            //    Console.WriteLine("{0}可以",person1.name);
            //}
            //else
            //{
            //    Console.WriteLine("{0}不能",person1.name);
            //}


            #endregion
            //is：判断这个变量是否能装换成对应类型，如果可以返回true，否则返回false
            //as：尝试转换，如果能，返回转换过后的对象，如果不能，返回null

            //is和as要搭配使用，可以避免空引用报错

            #region 里氏转换题综合题
            Random d6 = new Random();
            Monster[] monsters = new Monster[10];

            for (int i = 0; i < monsters.Length; i++)
            {
                if (d6.Next(0, 2) == 0)
                {
                    monsters[i] = new Boss(string.Format("{0}号Boss", i));
                }
                else
                {
                    monsters[i] = new Goblin(string.Format("{0}号哥布林", i));
                }
            }

            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] is Boss)
                {
                    (monsters[i] as Boss).Attack();
                }
                if (monsters[i] is Goblin)
                {
                    (monsters[i] as Goblin).Attack();
                }
            }


            #endregion

            #region GameObject
            //GameObject gameObject = new GameObject(5, 5, 5, 5, ConsoleColor.Yellow);
            //gameObject.Draw();
            //while (true)
            //{
            //    char input = Console.ReadKey(true).KeyChar;
            //    switch (input)
            //    {
            //        case 'w':
            //            gameObject.Move(0, -1);
            //            break;
            //        case 'a':
            //            gameObject.Move(-1, 0);
            //            break;
            //        case 's':
            //            gameObject.Move(0, 1);
            //            break;
            //        case 'd':
            //            gameObject.Move(1, 0);
            //            break;

            //        default:
            //            break;
            //    }
            //}
            #endregion



        }



    }

    //访问修饰符
    //  public公开的
    //  private私有的 (变量和方法的默认访问修饰符)
    //  protected继承
    //  internal 本程序集（类的默认访问修饰符）
    //命名空间
    //  同一命名空间下的东西不能重名，可以直接调用
    //  不同命名空间下的类可以重名，所以可以用命名空间来区分不同的代码




}
