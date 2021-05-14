using System;

namespace 类
{
    class Person
    {
        public string name;
        public int age;
        public bool isDrive;

        public void SayAge(int age)
        {
            Console.WriteLine(this.age);//this关键字的左右代替实例对象
        }
        public Person(int age)
        {
            this.age = age;
        }
        public Person(string name, int age, bool isDrive) : this(age)//代表构造函数
        {

            this.name = name;
            this.isDrive = isDrive;
        }
        public Person(string name)
        {
            this.name = name;
        }
        //没有返回类型，因为固定返回对应的对象
        //构造函数的方法名必须和类名一致
        //不指定是，将会有一个默认构造
        //如果指定，默认构造将会失效（但是可以重载出默认构造）

        public Person()
        {

        }

        public void SayHello()
        {
            Console.WriteLine("我叫{0}，我今年{1}岁了", this.name, this.age);
        }

        ~Person() { }//析构函数~类名（）{}，注意没有访问修饰符，不允许外部调用
        //没有返回值，不能写void
        //函数名必须是 ~类名
        //不指定是将会有一个析构
        //指定是，默认析构函数将会失效
        //不可以重载
        //在垃圾回收时自动调用

    }

    class Car
    {
        public float speed;
        public float maxSpeed;
        public int passengerNum;
        public Person driver;
        public Person[] passengers;

        public Car(float speed, float maxSpeed, int passengerNum, Person driver)
        {
            this.speed = speed;
            this.maxSpeed = maxSpeed;
            this.passengerNum = passengerNum;
            this.driver = driver;

            passengers = new Person[passengerNum];
        }

        //有上车下车行驶车祸等方法

        public void GetOn(Person person)
        {
            //找到一个空位让person上
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] == null)
                {
                    passengers[i] = person;
                    Console.WriteLine("{0}上车了", person.name);
                    return;
                }
            }

            Console.WriteLine("{0},车上没有位置给你坐了", person.name);

        }

        public void GetOff(Person person)
        {
            for (int i = 0; i < passengers.Length; i++)
            {
                if (person == passengers[i])
                {
                    passengers[i] = null;
                    Console.WriteLine("{0}下车了", person.name);
                    return;
                }
            }

            Console.WriteLine("车上查无此人 404 not found");

        }

        public void Drive()
        {
            if (driver.isDrive == true)
            {
                this.speed+=10;//加速
                Console.WriteLine("现在车速是{0}，司机是{1}，大家都很嗨~",speed,driver.name);
                if (this.speed > maxSpeed)
                {
                    CarAccident();//车祸
                }
            }
            else//司机没驾照
            {
                Console.WriteLine("司机是{0}，他的驾照是学生证！！",driver.name);
                CarAccident();
            }
        }

        void CarAccident()
        {
            Console.WriteLine("发生车祸了!!!!");
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] != null)
                {
                    Console.WriteLine(passengers[i].name + "挂了");
                }



            }
            Console.WriteLine(driver.name + "死的最惨");
        }


    }








    class Program
    {
        static void Main(string[] args)
        {
            //对象：是通过模板类实例化出来的个体，他具有具体的属性和行为（方法）
            //对象不能索引到静态方法
            Person zhangsan = new Person("张三", 18, true);
            Person laowang = new Person("老王");
            Person xiaoming = new Person("小明");
            Person xiaohua = new Person("小花");
            Person lisi = new Person("李四");
            Person xiaogang = new Person("小刚");

            //zhangsan.SayHello();

            //Ticket ticket = new Ticket(125);
            //ticket.TicketInfo();

            Car car = new Car(60, 200, 4, zhangsan);

            car.GetOn(lisi);
            car.GetOn(xiaohua);
            car.GetOn(xiaoming);
            car.GetOn(laowang);
            car.GetOn(xiaogang);


            car.GetOff(lisi);
            car.GetOn(xiaogang);

            while (true)
            {
                Console.ReadKey(true);
                car.Drive();
                
            }
        }
    }
}
