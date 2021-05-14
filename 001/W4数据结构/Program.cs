using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace W4数据结构
{
    //数据结构
    //      描述数据之间的关系
    //      行为：添加数据，删除数据，插入数据，查找数据，修改数据
    //      
    //      追加数据：向这个结构的，末尾添加一个数据
    //      删除数据：在这个结构种删除你指定的数据
    //      插入数据：向这个结构种的某一个位置插入你的数据
    //      查找数据：可以查找并访问到该数据
    //      修改数据：可以对该结构的指定数据进行重新赋值

    //      线性，链式，树状，图形，散列

    //集合
    //      Collection是C#写好的数据结构类库
    //      ArrayList，HashTable，Stack，Queue
    //      如果要用这些数据结构类的模板，要先引用System.Collection
    //      就可以通过类名去实例化它的对象

    class MyTest<T>
    {
        public T a;
        public MyTest(T a)
        {
            this.a = a;
        }
    }
    //泛型类
    //      访问修饰符 class 类名<T>{
    //              T 成员；
    //      }

    //      类型替代符的作用：可以让我们线不定义数据类型，只管逻辑，
    //      在调用此方法或者此类对象的时候，才在<>括号里填上对应类型
    //      这样我这段逻辑或者说这个类就够就可以适用于所有数据类型而且要比Object类型节省资源


    class Weapon
    {
       public int id;
       public string name;

        public Weapon(string name,int id)
        {
            this.name = name;
            this.id = id;
        }
        public override string ToString()
        {
            return id + ":" + name;
        }

        public void Show()
        {
            Console.WriteLine(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            //ArrayKist 
            //  是封装过的数组，里面的元素容器为Object类型
            //这样Arraylist就适用于所有数据类型
            //因为object类型是所有类的父类，又因为里氏转化原则
            //父类可以装载子类，所以arraylist可以装载所有数据类型

            //属性：
            //  count：记录我当前拥有多少个元素
            //  capacity：记录我当前可以包含多少个元素

            //方法：
            //  添加.Add（object value）
            //  把当前这个对象添加到数组种
            //
            //  删除.Remove（object value）
            //  查询此元素，并移除第一个匹配的元素项
            //  .RemoveAt（int index）
            //  根据下标号移除该元素
            //
            //  插入.Insert（int index，Object value）
            //  把对应的对象插入到下标
            //  
            //  访问/修改：通过索引器下标号
            //
            //  排序.Sort（）
            //
            //  反转.Reverse（）
            //
            //  检测是否包含.Contains（Object value）
            //  检测该集合是否包含该元素，如果包含返回true，不包含返回false
            //  
            //  查找索引：.IndexOf（Object value）
            //  找到第一个匹配该元素的下标号并返回
            //  如果没找到，返回-1
            //  

            #region ArrayList例子
            //for (int i = 0; i < 10; i++)
            //{
            //    arrayList.Add(i);
            //}

            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.WriteLine(arrayList[i]);
            //}

            //arrayList.Remove(8);//删除
            //Console.WriteLine("---------------------------------");
            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.WriteLine(arrayList[i]);
            //}

            //Console.WriteLine("---------------------------------");
            //arrayList.Insert(8, 8);
            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.WriteLine(arrayList[i]);
            //} 
            #endregion

            #region arraylist案里2
            //Random d6 = new Random();


            //for (int i = 0; i < 20; i++)
            //{
            //    arrayList.Add(d6.Next(0, 101));
            //}

            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.Write(arrayList[i] + "  ");
            //}
            //Console.WriteLine();


            //for (int i = 1; i < arrayList.Count; i++)
            //{
            //    int j;
            //    object temp = arrayList[i];
            //    for (j = i; j > 0 && (int)temp < (int)arrayList[j - 1]; j--)
            //    {
            //        arrayList[j] = arrayList[j - 1];
            //    }
            //    arrayList[j] = temp;
            //}
            //arrayList.Reverse();

            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.Write(arrayList[i] + "  ");
            //}
            //Console.WriteLine();


            //if (arrayList.Contains(9))
            //{
            //    Console.WriteLine("这个数组包含9");
            //    int temp = arrayList.IndexOf(9);
            //    Console.WriteLine(arrayList[temp]);
            //}

            //Console.WriteLine(arrayList.IndexOf(1)); 
            #endregion

            #region 单例模式题
            //for (int i = 0; i < 10; i++)
            //{
            //    new Monster("哥布林" + i + "号");
            //}

            //for (int i = 0; i < MonsterManager.Monstermanager.ArrayList.Count; i++)
            //{
            //    ((Monster)MonsterManager.Monstermanager.ArrayList[i]).Attack();
            //}
            #endregion

            //HashTable
            //  哈希表
            //  也是Sysrem.Collection集合下的数据结构类
            //  它储存的也是Object类型的对象
            //  但是他在内存中是散列排布的
            //  因为这个特性，非常适合存储大量的数据

            //HashTable储存的是<键，值>对
            //在HashTable中，一个键对应一个值，一个值可以对应多个键

            //HashTable table=new HashTable（）；

            Hashtable hashtable = new Hashtable();
            hashtable.Add("123", "霜之哀伤");
            //Console.WriteLine(hashtable["123"]);
            //属性
            //  Count：HashTable包含的键值对的数目
            //  Keys：HashTable种键的集合
            //  Values：HashTable中值的集合

            //方法
            //  增删查改
            //  Add（key，value）在哈希表中添加一对键值对
            //  Remove（key）删除键值
            //  因为一个值可能对应多个键，这样就不能把整个键值对删除掉
            //  只有没有键指向这个值，就会被自动释放掉，所以只需要删除兼职就可以了
            //  
            //  Contains（key）检测是否包含键值对
            //  ContainsKey（key）检测是否包含这个键
            //  ContainsValue（value）检测是否包含这个值
            //  
            //  访问：索引器[键]

            //遍历使用foreach去键或者值的集合中去吧每个元素都取到



            for (int i = 0; i < 10; i++)
            {
                hashtable.Add(i, new Weapon("第" + i + "武器", i));
            }

            //foreach (var key in hashtable.Keys)//遍历哈希表可以用foreach
            //{
            //    Console.WriteLine(hashtable[key]);//遍历key
            //}

            //foreach (var item in hashtable.Values)
            //{
            //    Console.WriteLine(item);//遍历值
            //}

            //((Weapon)hashtable[5]).Show();





            //栈
            //      也是Sysrem.Collection集合下的数据结构类
            //      储存的也是Object类型的对象
            //  
            //       Stack   名字 = new Stack（）；
            //
            //      Count：实际拥有的元素个数

            //      栈的释放顺序是先进后出（后进先出）
            //
            //      压栈——Push（Object 对象）把这个对象添加到栈低
            //      弹栈——Pop（）把栈顶的元素弹出来，会删除
            //      Peek（）返回栈顶的元素，不删除

            //      在遍历弹栈的时候要注意，Pop方法会删除你的对象，导致Count属性
            //      发生改变，所以，应该用一个变量储存一下一开始的Count值
            //      根据这个变量来弹栈，就可以把栈中所有的数据弹出去

            Stack stack = new Stack();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            //int count = stack.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    Console.WriteLine(stack.Pop());
            //}


            //队列
            //      是System.Collection下的数据结构类，储存Object类型的对象
            //      
            //      Queue 名称 = new Queue（）；
            //
            //属性 Count：该结构包含的元素个数

            //方法：
            //EnQueue（Object value）静茹队列末尾处
            //DeQueue（）返回并移除队列最前面的那个元素
            //Peek（）把队列中队首的元素返回，但不删除

            Queue queue = new Queue();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            //int queueCount= queue.Count;
            //for (int i = 0; i < queueCount; i++)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}


            //泛型
            //      因为我们在编程中想先不定义数据类型，只想先写逻辑
            //      就可以使用Object类型，这样我的逻辑就适用于所有类型，但是
            //      在运行中，Object类型的变量会需要转换成对应类型，浪费资源，所以出现泛型
            //      来替代Object类型的方案
            //      
            //      使用泛型，可以让我们延迟定义数据类型，来编写程序
            //
            //      泛型是一种将逻辑应用到不同数据类型上的机制，可以通过类型替代符
            //      来暂时替代参数的数据类型，这样只需要在编译的时候，编译器会自动将
            //      该替代符编译成对应数据类型来处理

            //泛型方法
            //      访问修饰符 返回类型 方法名<T,U>（T参数 T参数）{  }
            //      在使用的时候 方法名<数据类型>（参数）

            //      我们可以在方法名后面使用<类型替代符>来定义一个泛型方法

            Console.WriteLine(Add<int,int>(10, 20));
            Console.WriteLine(Add<float,int>(10.45f,25));

            //      方法定义好后，在调用泛型方法时，应该在<>括号内填上对应的类型

            //      使用范围：当你的方法适用于所有数据类型的时候
            //      可以使用泛型来代替Object类型，以节省资源

            //泛型集合
            //      在System.Collection.Generic下的泛型数据结构类
            //      比System.Conllections下Object类型的数据结构类要更安全，性能更好
            //泛型列表
            //      List<数据类型> ；列表名 = new List<数据类型>（可填写初始长度）
            //      
            //      属性：
            //      Count：代表这个列表实际包含多少个元素
            //      Capacity：代表这个列表可以包含多少个元素

            List<int> list = new List<int>();
            //      方法：
            //      Add：在列表末尾添加一个元素
            //      Remove：删除指定元素
            //      RemoveAt：删除下标号指定的元素
            //      Contains：检测是否包含这个元素
            //      IndexOf：从头开始查找第一个匹配项的下标号，没有返回-1；
            //      LastIndexOf：从尾开始查找第一个匹配项的下标号，没有返回-1
            //      Insert：在指定Index位置，插入这个元素
            //      Reverse：反转当前列表的排列顺序
            //      Sort：排序
            //
            //      差/改：索引器 [下标号]

            #region 泛型题一
            //for (int i = 10; i > 0; i--)
            //{
            //    list.add(i);
            //}

            //list.removeat(4);

            //for (int i = 0; i < list.count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //} 
            #endregion

            #region 泛型列表题
            //Random d6 = new Random();

            //for (int i = 0; i < 100; i++)
            //{
            //    list.Add(d6.Next(1, 50));
            //}

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine(IndexOf(list, 10));
            //Console.WriteLine(LastIndexOf(list, 10)); 
            #endregion

            #region 泛型列表题二

            //while (true)
            //{
            //    Console.WriteLine("1,添加一个数字 2,排序并显示数字");

            //    char keychar = Console.ReadKey(true).KeyChar;
            //    switch (keychar)
            //    {
            //        case '1':
            //            Console.WriteLine("请输入添加的数字:");
            //            list.Add(int.Parse(Console.ReadLine()));
            //            break;
            //        case '2':
            //            Console.Clear();

            //            list.Sort();
            //            for (int i = 0; i < list.Count; i++)
            //            {
            //                Console.Write(list[i]+" ");
            //            }
            //            Console.WriteLine();
            //            Console.ReadKey(true);
            //            break;
            //        default:
            //            break;
            //    }

            //    Console.Clear();
            //}


            #endregion

            #region 泛型列表题三
            Random d6 = new Random();

            for (int i = 0; i < 10; i++)
            {
                new Goblin(string.Format("{0}号", i), d6.Next(50, 101), d6.Next(50, 101), d6.Next(50, 101));
            }

            for (int i = 0; i < 3; i++)
            {
                new Boss(string.Format("{0}号", i), d6.Next(200, 301), d6.Next(50, 101), d6.Next(500, 1001));
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("请输入按键：");
                Console.WriteLine("1，攻击排序 2，防御排序 3，血量排序 4，反转");

                char input = Console.ReadKey(true).KeyChar;
                bool jumpout = false;
                switch (input)
                {
                    case '1':
                        //攻击力排序
                        MonsterManager.Monstermanager.monsterList.Sort(0, MonsterManager.Monstermanager.monsterList.Count, MonsterManager.Monstermanager.monsterList[0]);
                        jumpout = true;
                        break;
                    case '2':
                        //防御力排序
                        MonsterManager.Monstermanager.monsterList.Sort(0, MonsterManager.Monstermanager.monsterList.Count, MonsterDefSort.instance);
                        jumpout = true;
                        break;
                    case '3':
                        //血量排序
                        MonsterManager.Monstermanager.monsterList.Sort(0, MonsterManager.Monstermanager.monsterList.Count, MonsterHpSort.instance);
                        jumpout = true;
                        break;
                    case '4':
                        MonsterManager.Monstermanager.monsterList.Reverse();
                        jumpout = true;
                        break;
                    default:
                        break;
                }
                if (jumpout)
                {
                    for (int i = 0; i < MonsterManager.Monstermanager.monsterList.Count; i++)
                    {
                        Console.WriteLine(MonsterManager.Monstermanager.monsterList[i]);
                    }
                    Console.WriteLine("请按任意键继续");
                    Console.ReadKey(true);
                }

            }
            

            //MonsterManager.Monstermanager.AllAttack();
            
            //MonsterManager.Monstermanager.MonsterSort();
            //MonsterManager.Monstermanager.monsterList.Sort();

            

            
            //for (int i = 0; i < MonsterManager.Monstermanager.monsterList.Count; i++)
            //{
            //    Console.WriteLine(MonsterManager.Monstermanager.monsterList[i]);
            //}
            //Console.WriteLine();

            
            //for (int i = 0; i < MonsterManager.Monstermanager.monsterList.Count; i++)
            //{
            //    Console.WriteLine(MonsterManager.Monstermanager.monsterList[i]);
            //}
            //Console.WriteLine(); 
            #endregion

            
            

        }
        public static string Add<T, U>(T a, U b)
        {
            return a.ToString() + b.ToString();
        }

        public static string Sum(int a, int b)
        {
            return a.ToString() + b.ToString();
        }
        public static int IndexOf(List<int> list, int num)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == num)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int LastIndexOf(List<int> list,int num)
        {
            for (int i = list.Count-1; i >= 0; i--)
            {
                if (list[i] == num)
                {
                    return i;
                }
            }
            return -1;
        }
        

    }


}
