using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象类与抽象方法
{
    abstract class Geometry
    {
        protected string name;

        protected Geometry(string name)
        {
            this.name = name;
        }
        public abstract void GetArea();
        public abstract void GetPerimeter();
    }

    class Circle : Geometry
    {
        float r;

        public Circle(string name,float r) : base(name)
        {
            this.r = r;
        }

        public override void GetArea()
        {
            float area = r * r * (float)Math.PI;
            Console.WriteLine("圆{0}的面积为：{1}",name,area);
        }

        public override void GetPerimeter()
        {
            float perimeter = r * 2 * (float)Math.PI;
            Console.WriteLine("圆{0}的周长为：{1}",name,perimeter);
        }
    }
    class Rectangle : Geometry
    {
        float width;
        float height;

        public Rectangle(string name,float width,float height) : base(name)
        {
            this.width = width;
            this.height = height;
        }

        public override void GetArea()
        {
            float area = width * height;
            Console.WriteLine("矩形{0}的面积为：{1}",name,area);
        }

        public override void GetPerimeter()
        {
            float perimeter = width * 2 + height * 2;
            Console.WriteLine("矩形{0}的面积为：{1}",name,perimeter);
        }
    }


}
