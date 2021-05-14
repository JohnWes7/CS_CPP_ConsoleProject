using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字典泛型栈泛型队列
{
    class Program
    {
        static void Main(string[] args)
        {
            //字典
            //  在System.Collections.Generic;下
            //  对应HashTable，添加了泛型的特性，性能更高更安全
            //  在内存中是散列排布的，储存也是键值对

            //  Dictionary<键的数据类型，值的数据类型> 字典名 = new Dictionary<键的数据类型，值的数据类型>（）；

            //添加元素： Add（key，value）
            //比HashTable多一种，可以直接通过索引器添加 字典名[key]=value；
            //
            //删除元素
            //Remove（key）通过键去删除
            //
            //访问
            //this[key]通过键值来访问元素
            //
            //遍历
            //可以直接用foreach 取到每一对键值对KeyValuePair<Key类型,值类型>对象
            //通过这个键值对对象，.出key属性和value属性

            #region 字典案例
            //Dictionary<string, string> weaponLibrary = new Dictionary<string, string>();

            //weaponLibrary.Add("123", "子午鸳鸯钺");

            //Console.WriteLine(weaponLibrary["123"]);

            //foreach (var item in weaponLibrary)
            //{
            //    Console.WriteLine(item.Key + ":" + item.Value);//hashtable没有
            //} 


            #endregion

            #region 字典题一
            //Console.WriteLine("请输入一个数字");
            //string num = Console.ReadLine();
            //UpperNum(num);
            #endregion

            #region 字典题二
            //Dictionary<char, int> letterCount = new Dictionary<char, int>();

            //Console.WriteLine("请输入一串英文");
            //string input = Console.ReadLine();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    if ((input[i]>=65&&input[i]<=90)||(input[i]>=97&&input[i]<=122))//如果是字母
            //    {
            //        if (letterCount.ContainsKey(input[i]))//如果已经有了
            //        {
            //            letterCount[input[i]]++;//值++
            //        }
            //        else//如果还没有
            //        {
            //            letterCount[input[i]] = 1;//等于一
            //        }
            //    }

            //}

            //foreach (var item in letterCount)
            //{
            //    Console.WriteLine(item.Key+":"+item.Value);
            //}

            #endregion

            //栈与队列
            //  在System.Collections.Generic下的泛型集合
            //  对比Stack和Queue多了泛型的特性

            //Stack<数据类型> 栈名 = new Stack<数据类型>（）；

            //压栈：栈名.Push（元素）
            //弹栈：栈名.Pop（）会返回栈顶的元素
            //查看栈顶的元素：栈名.Peek（）；

            #region 栈的案列
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            int stack_Count = stack.Count;

            for (int i = 0; i < stack_Count; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            
            #endregion

            //Queue<数据类型> 队列名=new Queue<数据类型>（）；
            //进队：队列名.EnQueue（元素）在队尾添加元素
            //出队：队列名.DeQueue（）把队首的元素弹出来
            //查看队首的元素：队列名.Peek（）；

            Queue<int> que = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                que.Enqueue(i);
            }

            int queCount = que.Count;
            for (int i = 0; i < queCount; i++)
            {
                Console.WriteLine(que.Dequeue());
            }




            Console.ReadKey(true);
        }

        public static void UpperNum(string num)
        {
            Dictionary<char, char> numToCN = new Dictionary<char, char>();

            numToCN.Add('1', '壹');
            numToCN.Add('2', '贰');
            numToCN.Add('3', '叁');
            numToCN.Add('4', '肆');
            numToCN.Add('5', '伍');
            numToCN.Add('6', '陆');
            numToCN.Add('7', '柒');
            numToCN.Add('8', '捌');
            numToCN.Add('9', '玖');
            numToCN.Add('0', '零');

            for (int i = 0; i < num.Length; i++)
            {
                Console.Write(numToCN[num[i]]);
            }
            Console.ReadKey(true);
        }


    }
}
