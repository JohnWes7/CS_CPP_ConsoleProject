using System;

namespace 接口
{

    //接口
    //      和类进行一个约定
    //      1.接口可以包含方法，属性，事件，索引器
    //      2.接口不提供所定义的成员的代码实现，只能由继承接口的类或者结构去实现
    //      3.接口的继承者必须实现接口的所有属性和方法
    //      4.一个类可以继承多个接口，但当你的继承关系有类的时候，类要放在继承列表的第一个
    //      5.接口时可以继承接口的
    //      6.接口不能有构造函数，不能有字段，不能有重载运算符
    //      7.接口中的成员已经强制为public了

    //声明
    //  访问修饰符 interface 接口名{
    //      属性，
    //      方法，
    //      索引器，
    //      事件
    //      }

    //接口取名，前面必须要加大写的I（代表是接口）

    //接口的使用

    //访问修饰符 class 类名：基类，接口名，接口名{
    //         实现所有接口的成员
    //}


    public interface IFly
    {
        void Fly();
    }

    //class Bird : IFly
    //{
    //    public void Fly()
    //    {
    //        Console.WriteLine("鸟儿在飞");
    //    }
    //}

    class Superman : IFly
    {
        public void Fly()
        {
            Console.WriteLine("超人在飞~");
        }
    }

    class Plane : IFly
    {
        public void Fly()
        {
            Console.WriteLine("飞机在飞");
        }
    }
    //接口的显示实现
    //当我们的类继承了多个接口，有可能会有重名的成员，这个时候
    //可以使用显示实现在区别不同接口的成员
    // 接口名.成员名 {}

    class Program
    {
        static void Main(string[] args)
        {
            #region 接口例子
            //IFly[] flies = new IFly[3];
            //flies[0] = new Bird();
            //flies[1] = new Superman();
            //flies[2] = new Plane();

            //for (int i = 0; i < flies.Length; i++)
            //{
            //    flies[i].Fly();
            //} 
            #endregion

            #region 接口题
            //Ostrich ostrich = new Ostrich();
            //Swan swan = new Swan();
            //Penguin penguin = new Penguin();
            //Parrot parrot = new Parrot();
            //Sparrow sparrow = new Sparrow();
            //Helicopter helicopter = new Helicopter();

            //ostrich.walk();
            //Console.WriteLine();
            //swan.Fly();
            //swan.walk();
            //swan.swim();
            //Console.WriteLine();
            //penguin.walk();
            //penguin.swim();
            //Console.WriteLine();
            //parrot.walk();
            //parrot.Fly();
            //Console.WriteLine();
            //sparrow.walk();
            //sparrow.Fly();
            //Console.WriteLine();
            //helicopter.Fly();


            #endregion

            #region 接口题二

            //Student student = new Student("小明");
            //Teacher teacher = new Teacher("老李");
            //HeadMaster headMaster = new HeadMaster("老王");

            //ICollectHomework[] list = new ICollectHomework[2] { student, teacher };

            //for (int i = 0; i < list.Length; i++)
            //{
            //    list[i].CollectHomework();
            //}
            //teacher.CollectHomework();

            #endregion

            #region 接口题三

            //Person person = new Person("老王");
            //Car car = new Car();
            //House house = new House();

            //IRegister[] list = new IRegister[3] { person, car, house };

            //for (int i = 0; i < list.Length; i++)
            //{
            //    list[i].Register();
            //}

            #endregion

            #region 接口题4，交互！
            Computer computer = new Computer();

            USB_Drive UDisk = new USB_Drive();
            HardDisk hardDisk = new HardDisk();
            MP3 mp3 = new MP3();
            HardDisk hardDisk1 = new HardDisk();

            UDisk.Connect(computer);
            hardDisk.Connect(computer);
            mp3.Connect(computer);
            hardDisk1.Connect(computer);

            UDisk.ReadData();
            hardDisk.ReadData();
            mp3.ReadData();
            hardDisk1.ReadData();
            #endregion

        }
    }





}
