using System;
using System.Collections.Generic;
using System.Text;

namespace 虚方法
{
    class Duck
    {
        protected string name;

        public Duck(string name)
        {
            this.name = name;
        }

        public virtual void Quack()
        {
            Console.WriteLine("{0}:父类的鸭子叫",name);
        }
    }

    class WoodDuck : Duck
    {
        public WoodDuck(string name) : base(name) { }

        public override void Quack()
        {
            Console.WriteLine("{0}:吱吱叫",name);
        }
    }

    class RubberDuck : Duck
    {
        public RubberDuck(string name) : base(name) { }

        public override void Quack()
        {
            Console.WriteLine("{0}:鸡鸡叫",name);
        }
    }

    class RealDuck : Duck
    {
        public RealDuck(string name) : base(name) { }

        public override void Quack()
        {
            Console.WriteLine("{0}:嘎嘎叫",name);
        }
    }
}
