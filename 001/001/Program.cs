using System;

namespace _001
{
    class Program
    {
        static void Main(string[] args)
        {
            ReferenceTest referenceTest = new ReferenceTest(99);
            Console.WriteLine(referenceTest.data);

            ReferenceTest.NullTest(ref referenceTest);
            if (referenceTest == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(referenceTest.data);
            }
        }
    }

    public class ReferenceTest
    {
        public int data;

        public ReferenceTest(int data)
        {
            this.data = data;
        }

        public static void NullTest(ref ReferenceTest referenceTest)
        {
            referenceTest = null;
        }
    }
}
