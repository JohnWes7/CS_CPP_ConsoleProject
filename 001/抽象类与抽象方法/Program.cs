using System;

namespace 抽象类与抽象方法
{
    class Program
    {
        //抽象类和抽象方法
        //  被adstract关键字修饰的类是修饰类
        //  被abstract关键字修饰的方法叫抽象方法
        //  
        //  1.抽象方法必须放在抽象类中
        //  2.抽象方法不可以实现代码
        //  3.抽象方法可以用override关键字去重写
        //  4.继承了抽象类的子类必须要实现抽象类中所有的抽象方法
        //  5.抽象类不能实例化
        //  6.虚方法必须是非静态的，因为要让子类去继承重写，如果是静态的就无法唯一化
        //  7.abstract不能被private

        //如果你的父类需要实例化，且需要实现方法，用虚方法
        //如果你的父类不需要实例化，也不需要实现方法，用抽象类和抽象方法

        //继承的本质是继承父类的实体
        //虚方法不能private，如果非要关闭，请用sealed

        abstract class Person
        {
            public string name;
            public  Person(string name)
            {
                this.name = name;
            }
            public abstract void SayHello();


        }

        class Student : Person
        {
            public Student(string name) : base(name) { }
            public override void SayHello()
            {
                Console.WriteLine("Hello , This is {0}",name);
            }
        }
        static void Main(string[] args)
        {
            #region 抽象类例子
            //Student xiaoming = new Student("小明");

            ////xiaoming.name = "小明";
            //xiaoming.SayHello(); 
            #endregion

            #region 抽象类练习一
            //Animal[] animals = new Animal[2];
            //animals[0] = new Cat("加菲");
            //animals[1] = new Dog("旺财");

            //for (int i = 0; i < animals.Length; i++)
            //{
            //    animals[i].AnimalNoise();
            //}
            #endregion

            #region 抽象类练习二
            Circle circle = new Circle("1", 5);
            Rectangle rectangle = new Rectangle("2", 5, 10);

            circle.GetArea();
            circle.GetPerimeter();

            rectangle.GetArea();
            rectangle.GetPerimeter();

            #endregion
        }
    }
}
