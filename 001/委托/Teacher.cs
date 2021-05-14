using System;
using System.Collections.Generic;
using System.Text;

namespace 委托
{

    public delegate void StudentDoing();
    class Teacher
    {
        public StudentDoing studentDoing;
        public event StudentDoing eventStudentDoing;
        public Teacher()
        {
            this.studentDoing = this.Ring;
        }

        public void ClassOver()
        {
            Console.WriteLine("下课打铃了！！");
            Console.WriteLine();
            this.studentDoing.Invoke();
        }
        void Ring()
        {
            Console.WriteLine("铃铃铃~");
            
        }
        public void StudentDoingAdd()
        {

        }
    }

    class Student
    {
        string name;
        string classOverDoing;

        public Student(string name, string classOverDoing)
        {
            this.classOverDoing = classOverDoing;
            this.name = name;


        }

        public void Doing()
        {
            Console.WriteLine(name+":"+classOverDoing);
        }
    }

}
