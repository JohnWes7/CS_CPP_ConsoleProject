using System;
using System.Net.NetworkInformation;

namespace 索引器重载运算符
{
    //operator关键字
    //      重载运算符
    //      让我们自定义的数据类型可以通过运算符进行运算
    //      
    //      访问修饰符 static 返回类型 operator 运算符（参数）
    //      { 运算内容以及返回结果}

    struct Vector2
    {
        public int x, y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }//结构体构造函数不能覆盖原本默认的
        //而且必须要给所有东西赋值

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static bool operator ==(Vector2 a,Vector2 b)//重载了相等必须也要重载不相等
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Vector2 a,Vector2 b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }

    class Person
    {
        string name;
        string sex;
        string age;
        string hobby;

        public Person(string name, string sex, string age, string hobby)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.hobby = hobby;
        }

        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return name;
                    case 1:
                        return sex;
                    case 2:
                        return age;
                    case 3:
                        return hobby;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }


        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("老王", "男", "24", "搓炉石");

            Console.WriteLine(person[3]);

            Vector2 pointA = new Vector2(1, 1);
            Vector2 vector = new Vector2(2, 3);

            Console.WriteLine(pointA+vector);

        }



    }
}
