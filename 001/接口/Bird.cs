using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace 接口
{

    public interface IWalk
    {
        void walk();
    }
    public interface ISwim
    {
        void swim();
    }

    class Bird : IWalk
    {
        public string name;

        public void walk()
        {
            Console.WriteLine("{0}在走", name);
        }
    }

    class Ostrich : Bird
    {
        public Ostrich()
        {
            this.name = "鸵鸟";
        }
    }
    class Penguin : Bird, ISwim
    {
        public Penguin()
        {
            name = "企鹅";
        }
        public void swim()
        {
            Console.WriteLine("{0}正在游泳", name);
        }
    }
    class Parrot : Bird, IFly
    {
        public Parrot()
        {
            name = "鹦鹉";
        }
        public void Fly()
        {
            Console.WriteLine("{0}正在飞", name);
        }
    }
    class Helicopter : IFly
    {
        string name;
        public Helicopter()
        {
            name = "直升机";
        }
        public void Fly()
        {
            Console.WriteLine("{0}正在飞", name);
        }
    }
    class Swan : Bird, IFly, ISwim
    {
        public Swan()
        {
            name = "天鹅";
        }
        public void Fly()
        {
            Console.WriteLine("{0}正在飞", name);
        }

        public void swim()
        {
            Console.WriteLine("{0}正在游泳", name);
        }
    }
    class Sparrow : Bird, IFly
    {
        public Sparrow()
        {
            name = "麻雀";
        }
        public void Fly()
        {
            Console.WriteLine("{0}正在飞", name);
        }
    }


}
