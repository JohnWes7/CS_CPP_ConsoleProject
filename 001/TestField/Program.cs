using System;
using System.Collections.Generic;

namespace TestField
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Collections.IList list = new List<int>();
            
            //test<string> a = new test<string>();
            
            //Console.ReadKey();


        }

        static void teststr()
        {
            string name = "johnwest";
            test_str_is_class(name);
            Console.WriteLine(name);
        }

        static void test_str_is_class(string name)
        {
            name += "dawdwa";
            Console.WriteLine(name);
        }
    }

    class test<T>
    {
        T[] array;
        
        public test()
        {
            array = new T[10];
        }

        public void Add(T value)
        {
            Add((object)value);
        }

        public void Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            return false;
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
    }

    interface myIlist<T>
    {
        #nullable enable
        public void Add(object? value);
        public bool Contains(object? value);
        #nullable disable
    }
}
