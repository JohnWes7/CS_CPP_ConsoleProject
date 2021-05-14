using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象类与抽象方法
{
    abstract class Animal
    {
        protected string name;

        public Animal(string name)
        {
            this.name = name;
        }

        public abstract void AnimalNoise();
    }

    class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void AnimalNoise()
        {
            Console.WriteLine("{0}（猫）：喵",name);
        }
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void AnimalNoise()
        {
            Console.WriteLine("{0}（狗）：汪！", name);
        }
    }
}
