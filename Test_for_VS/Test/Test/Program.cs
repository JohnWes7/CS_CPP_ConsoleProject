using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            teststr();
            Console.ReadKey();
        }

        static void teststr()
        {
            string name = "johnwest";
            Console.WriteLine(name);
            test_str_is_class(name);
            Console.WriteLine(name);
        }

        static void test_str_is_class(string name)
        {
            name += "dawdwa";
            Console.WriteLine(name);
        }
    }
}
