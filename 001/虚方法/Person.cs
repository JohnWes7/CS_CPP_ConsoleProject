using System;
using System.Collections.Generic;
using System.Text;

namespace 虚方法
{
    class Person
    {
        protected string name;

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void ClockIn()
        {
            Console.WriteLine("不打卡");
        }
        public override string ToString()
        {
            return string.Format("我是{0}", name);
        }
    }


    class Manager : Person
    {
        public Manager(string name) : base(name) { }

        public override void ClockIn()
        {
            Console.WriteLine("{0}经理,1点打卡",name);
        }
    }

    class Employee : Person
    {
        public Employee(string name) : base(name) { }

        public override void ClockIn()
        {
            Console.WriteLine("{0}员工,9点打卡",name);
        }
    }

    class Programmer : Person
    {
        public Programmer(string name) : base(name) { }


    }
}
