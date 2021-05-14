using System;
using System.Collections.Generic;
using System.Text;

namespace 接口
{

    public interface ICollectHomework
    {
        void CollectHomework();
    }

    class Person:IRegister
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void Register()
        {
            Console.WriteLine("{0}登记了",name);
        }
    }

    class Student : Person,ICollectHomework
    {
        public Student(string name) : base(name)
        {
        }

        public void CollectHomework()
        {
            Console.WriteLine("学生收普通作业");
        }
    }
    class Teacher : Person,ICollectHomework
    {
        public Teacher(string name) : base(name)
        {
        }

        public void CollectHomework()
        {
            Console.WriteLine("收特别作业的方法");
        }
        void ICollectHomework.CollectHomework()
        {
            Console.WriteLine("老师收普通作业的方法");
        }
    }
    class HeadMaster : Person
    {
        public HeadMaster(string name) : base(name)
        {
        }
    }
}
