using System;
using System.Security.Cryptography.X509Certificates;

namespace 面向对象
{
    class MonsterControler
    {//单例模式：因为创造不出第二个实例
        //  使用唯一一个静态变量来索引堆中的内容

        private static MonsterControler instance;//封装了一个静态的对象
        public static MonsterControler Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new MonsterControler();//一旦要用到了，开始访问了，没有再生成一个
                }
                return instance;//返回地址，之前没有就开
            }
        }
        //把对象索引地址从栈中，放到了静态区域中

        public Monster[] monsters;

        private MonsterControler()
        {
            monsters = new Monster[1];
        }//不能实例化

        public void LeiPu()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i]!=null)
                {
                    monsters[i].LeiPu();
                }

            }
        }
        public void AddMonster(Monster monster)
        {
            int i;
            for ( i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == null)
                {
                    monsters[i] = monster;//如果有空位，就安插进去
                    return;
                }
            }
            //如果没有return，则开始扩容
            Monster[] temp = new Monster[monsters.Length + 1];//声明新数组长度是原长度加一
            
            //把原数组中的数据复制进去
            for ( i = 0; i < monsters.Length; i++)
            {
                temp[i] = monsters[i];
            }
            //把没放进去的东西放进去
            temp[i] = monster;
            
            monsters = temp;//让老的数组指向新的数组

            return;
        }

        //因为不能实例化，一切非静态的都访问不到
        //单例模式
        //  单一的实例
        //  把类对象封装成静态对象
        //  关闭此类的构造函数
        //  用属性封装静态对象
        //  公开这个属性，以供外部调用
        //  这样就达到了，再静态区中只有一个变量地址，但是内容再堆中的效果
        //  这样既发挥了静态的有点，又避免了静态的缺点
        //  1.不允许别人去实例化（封闭构造函数）
        //  2.为了别人方便索引，而且只能访问（使用属性的get去封装这个变量）
        //  3.在外人访问的时候，先得判断一下，这个静态储存变量储存的地址是否为空
        //  4.如果为空，就要去堆中开辟空间（使用new构造函数（）创建一个新对象）
        //  5.如果不为空直接返回
        //  这样，该类中的其他非静态的成员，就可以通过这唯一一个静态变量去索引（用dot语法）
    }

    class Weapon
    {
        public string name;
        public int durability;
        public int maxDurability;
        public int atkAdd;

        public Weapon(string name, int durability, int maxDurability, int atkAdd)
        {
            this.name = name;
            this.durability = durability;
            this.maxDurability = maxDurability;
            this.atkAdd = atkAdd;
        }
    }

    class Player
    {
        string name;
        int hp;
        int maxHp;
        int def;
        int atk;
        Weapon weapon;

        public int Speed
        {//自动属性
            get;
            set;
        }
        //用空语句代替get块和set块，则被称为自动属性
        //自动属性的set是可以不用写的
        //他会在编译时自动生成一个变量共getset使用
        //
        //访问修饰符 数据类型 属性名

        public int Atk
        {
            get
            {
                return atk;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 500)
                {
                    value = 500;
                }
                atk = value;
            }
        }

        public string GetName()
        {
            return name;
        }
        public void PlayerInfo()
        {
            if (weapon == null)
            {
                Console.WriteLine("{0}:\tHp:{1}/{2}\tATK:{3}\tDEF:{4}", name, hp, maxHp, atk, def);
                return;
            }
            else
            {
                Console.WriteLine("{0}:\tHp:{1}/{2}\tATK:{3}\tDEF:{4}\tWeapon:{5}", name, hp, maxHp, atk, def, weapon.name);
            }

        }
        public Player(string name, int atk, int def, int hp, int maxHp)
        {
            this.name = name;
            this.hp = hp;
            this.def = def;
            this.atk = atk;
            this.maxHp = maxHp;

        }
        public void Attack(Monster monster)
        {
            monster.OnDamage(this.atk);
        }
        public void Equip(Weapon weapon)
        {
            this.weapon = weapon;
            atk += weapon.atkAdd;
        }
        public void OnDamage(int atk)
        {
            int damage = (atk - this.def) <= 0 ? 1 : atk - this.def;

            this.hp -= damage;
            //Console.WriteLine("");
        }
        public void DeadChop(Monster monster)
        {
            int attack = this.atk * 2;
            monster.OnDamage(attack);

        }
    }

    //属性
    //   因为你把字段全public，会非常不安全，外部可以随意更改你的值
    //有可能会导致你的程序出问题，这个时候，我们就把它取消public
    //但外部就不能访问了，所以我们公开了两个api，一个是get方法
    //可以让外部访问我的字段，一个是set方法可以接受外部的传参来修改
    //因为两个方法都是自己定义的，所以可以保护你的字段的合法性
    //后来c#针对这个问题，出了一个特性——属性

    //get块和set块本质上是两个方法

    //1.属性内部有两个块，set和get
    //2.get快代表外界访问，所以get块必须有return返回结果
    //3.return的返回结果要和属性的数据结构保持一致
    //4.set块代表外界写入，可以通过value关键字来接受外界的参数
    //5.可以只有一个块
    //6.get块和set块前面都可以加访问修饰符
    //7.属性名一般和你保护的字段保持一致，只不过首字母大写
    class Monster
    {
        string name;
        int hp;
        int maxHp;
        int def;
        int atk;

        public string GetName()
        {
            return name;
        }

        public Monster(string name, int atk, int def, int hp, int maxHp)
        {
            this.maxHp = maxHp;
            this.name = name;
            this.hp = hp;
            this.def = def;
            this.atk = atk;


        }
        public Monster(string name)
        {
            this.name = name;
            MonsterControler.Instance.AddMonster(this);

        }

        public void OnDamage(int atk)
        {
            int damage = (atk - this.def) <= 0 ? 1 : atk - this.def;

            this.hp -= damage;
            //Console.WriteLine("");
        }
        public void Attack(Player player)
        {
            player.OnDamage(atk);
        }
        public void MonsterInfo()
        {
            Console.WriteLine("{0}:\tHp:{1}/{2}\tATK:{3}\tDEF:{4}", name, hp, maxHp, atk, def);
        }
        public void LeiPu()
        {
            Console.WriteLine("{0}，攻击了", name);
        }
    }

    class Student
    {
        string name;
        string sex;
        int age;
        int cSharp;
        int unity;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    name = "张三";
                }
                else
                {
                    name = value;
                }
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                if (value == "男" || value == "女")
                {
                    sex = value;
                }
                else
                {
                    sex = "未知";
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 150)
                {
                    value = 150;
                }
                age = value;
            }
        }
        public int CSharp
        {
            get
            {
                return cSharp;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 100)
                {
                    value = 100;
                }
                cSharp = value;
            }
        }
        public int Unity
        {
            get
            {
                return unity;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 100)
                {
                    value = 100;
                }
                unity = value;
            }
        }

        public Student(string name, string sex, int age, int csharp, int unity)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
            this.CSharp = csharp;
            this.Unity = unity;
        }

        public void SayHello()
        {
            Console.WriteLine("我叫{0}，{1}，今年{2}岁了", Name, Sex, Age);
        }
        public void SayGrade()
        {
            Console.WriteLine("{0}的C#分数为{1}，Unity成绩为{2}，总分为{3}，平均分为{4}", Name, CSharp, Unity, CSharp + Unity, ((float)CSharp + Unity) / 2);
        }

    }

    //静态类
    //  用static修饰的类叫做静态类
    //  静态类只能有静态成员（静态的方法，字段，属性)
    //  静态类不允许实例化
    //  静态类在项目中是资源共享的
    //  所以，当我们需要一个同意管理的工具，或者制作工具时，可以考虑使用静态类
    //  静态类会随着程序同生共死，会一致占有资源
    //  所以静态类在项目中应该越少越好——单例设计模式
    //  类对象是引用类型，在栈空间中储存的是地址
    //  属性可以修正我外部的访问
    //  静态类的声明
    //  static class 类名
    //{
    //      static 字段；static 属性；static 方法
    //}
    //调用静态类成员：类名.静态成员

    //静态与非静态的区别
    //  成员调用：静态成员通过类名调用，非静态成员通过对象名调用
    //  类的成员：静态类只能包含静态成员，非静态类可以包含静态成员
    //  方法的区别：静态方法只能调用静态成员，非静态类可以调用静态成员
    class Program
    {
        static void Main(string[] args)
        {
            //string.Format()字符串格式化输出
            //相当于console,writeline
            //而string.Format()是返回以一个字符串
            #region 属性
            Random d6 = new Random();
            Player p1 = new Player("footman", d6.Next(100, 201), d6.Next(120, 201), 1000, 1000);
            Weapon weapon = new Weapon("火之高兴", 100, 100, 300);
            Monster monster = new Monster("奥妮克希亚", d6.Next(150, 401), d6.Next(200, 301), 2000, 2000);
            p1.Equip(weapon);




            #region 过程
            //while (true)
            //{

            //    ShowInfo(p1, monster);
            //    Console.SetCursorPosition(0, 7);
            //    Console.WriteLine("                                                                                        ");
            //    Console.SetCursorPosition(0, 7);
            //    Console.WriteLine("1,普通攻击\t2.致命打击");
            //    char input = Console.ReadKey(true).KeyChar;
            //    if (input == '1')
            //    {
            //        Console.SetCursorPosition(0, 7);
            //        p1.Attack(monster);
            //        Console.WriteLine("{0}攻击了{1}", p1.GetName(), monster.GetName());
            //    }
            //    else
            //    {
            //        Console.SetCursorPosition(0, 7);
            //        p1.DeadChop(monster);
            //        Console.WriteLine("{0}使用了致命打击，攻击了{1}", p1.GetName(), monster.GetName());
            //    }


            //    ShowInfo(p1, monster);
            //    Console.ReadKey(true);


            //    monster.Attack(p1);
            //    Console.SetCursorPosition(0, 7);
            //    Console.WriteLine("                                                                                        ");
            //    Console.SetCursorPosition(0, 7);
            //    Console.WriteLine("{0}攻击了{1}", monster.GetName(), p1.GetName());
            //    ShowInfo(p1, monster);
            //    Console.ReadKey(true);
            //} 
            #endregion

            //p1.Atk = -1000;
            //Console.WriteLine(p1.Atk);
            #endregion

            #region 属性题1
            //Student zhangsan = new Student("张三", "男", 20, 80, 85);
            //Student lisi = new Student("李四", "女", 19, 85, 90);
            //Student xiaoming = new Student("小明", " ", 200, 200, -100);


            //zhangsan.SayHello();
            //zhangsan.SayGrade();
            //lisi.SayHello();
            //lisi.SayGrade();
            //xiaoming.SayHello();
            //xiaoming.SayGrade();
            #endregion

            #region 静态类
            Monster monster1 = new Monster("胡德");
            Monster monster2 = new Monster("索米");
            Monster monster3 = new Monster("RFB");

            for (int i = 0; i < 10; i++)
            {
                new Monster(string.Format("哥布林{0}号", i));
            }

            Console.WriteLine(MonsterControler.Instance.monsters.Length);
            MonsterControler.Instance.LeiPu();


            #endregion
        }

        static void ShowInfo(Player p1, Monster monster)
        {
            Console.SetCursorPosition(0, 5);
            p1.PlayerInfo();
            Console.SetCursorPosition(0, 15);
            monster.MonsterInfo();
        }
    }
}
