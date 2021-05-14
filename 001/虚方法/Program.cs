using System;

namespace 虚方法
{
    //虚方法
    //  被virtual关键字修饰的方法，叫做虚方法
    //  然后子类就可以通过override关键字去重写你的虚方法
    //  虚方法通常写在你要继承的父类中
    //  让我不同的子类对象对同一指令有不同行为

    //  1.虚方法在调用是，会根据你运行时，实际的对象和最后重写的方法，去决定运行哪一个
    //  2.如果你是非虚方法，是需要转成对应的对象，才能执行对应的方法
    //  3.你的子类只能重写同参数类型同返回类型的虚方法
    //  4.不要在子类中去声明一个和虚方法同名的新方法，虚方法会被new隐藏掉

    //sealed关键字（修饰类和虚方法）
    //      1.可以密封一个虚方法的重写，导致新的派生类无法重写
    //      2.密封一个类，让这个类无法派生
    class Program
    {
        static void Main(string[] args)
        {

            #region 虚方法的调用
            //Monster[] monsters = new Monster[10];

            //for (int i = 0; i < monsters.Length; i++)
            //{
            //    if (i == 9)
            //    {
            //        monsters[i] = new Boss("奥妮克希亚");

            //    }
            //    else
            //    {
            //        monsters[i] = new Goblin("第" + i + "号哥布林");
            //    }
            //}

            //for (int i = 0; i < monsters.Length; i++)
            //{
            //    monsters[i].Attack();
            //} 
            #endregion

            #region 虚方法练习
            //Duck[] ducks = new Duck[10];

            //for (int i = 0; i < ducks.Length; i++)
            //{
            //    if (i < 3)
            //    {
            //        ducks[i] = new RealDuck(string.Format("{0}", i));
            //    }
            //    else if (i >= 3 && i < 6)
            //    {
            //        ducks[i] = new WoodDuck(string.Format("{0}", i));
            //    }
            //    else if (i >= 6 && i < 9)
            //    {
            //        ducks[i] = new RubberDuck(string.Format("{0}", i));
            //    }
            //    else
            //    {
            //        ducks[i] = new Duck(string.Format("{0}", i));
            //    }
            //}

            //for (int i = 0; i < ducks.Length; i++)
            //{
            //    ducks[i].Quack();
            //}
            #endregion

            #region 虚方法练习2
            Person employee = new Employee("1");
            Person manager = new Manager("2");
            Person programmer = new Programmer("3");

            employee.ClockIn();
            manager.ClockIn();
            programmer.ClockIn();

            Console.WriteLine(programmer);

            #endregion
        }
        //抽象类和抽象方法
        //  被adstract关键字修饰的类是修饰类
        //  被abstract关键字修饰的方法叫抽象方法
        //  
        //  1.抽象方法必须放在抽象类中
        //  2.抽象方法不可以实现代码
        //  3.抽象方法可以用override关键字去重写
        //  4.继承了抽象类的子类必须要实现抽象类中所有的抽象方法
    }
}
