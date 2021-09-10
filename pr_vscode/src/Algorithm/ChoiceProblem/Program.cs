using System;

namespace ChoiceProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {5,3,8,1,4,6,9,2,7};
            
            System.Console.WriteLine(ChoiceProblem.SelectMinK(arr, 4));
        }

    }

    public class ChoiceProblem
    {
        public static int SelectMinK(int[] arr, int kindex)
        {
            kindex--;
            return SelectMinK(arr, 0, arr.Length - 1, kindex);
        }

        private static int SelectMinK(int[] arr, int left, int right, int kindex)
        {
            int midindex = Partition(arr, left, right);
            if (midindex == kindex)
            {
                return arr[kindex];
            }

            if (kindex < midindex)
            {
                return SelectMinK(arr, left, midindex - 1, kindex);
            }
            else
            {
                return SelectMinK(arr, midindex + 1, right, kindex);
            }
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;

            while (i < j)
            {
                while (i < j)
                {
                    if (arr[j] < arr[i])
                    {
                        swap(ref arr[j], ref arr[i]);
                        i++;
                        break;
                    }
                    j--;
                }

                while (i < j)
                {
                    if (arr[i] > arr[j])
                    {
                        swap(ref arr[j], ref arr[i]);
                        j--;
                        break;
                    }
                    i++;
                }
            }

            return i;
        }

        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }


}

