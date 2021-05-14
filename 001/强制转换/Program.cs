using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace 强制转换
{
    class Program
    {
        static int MaxCommonDivisor(int a, int b)
        {
            return (a % b == 0) ? b : MaxCommonDivisor(b, a % b);
        }//最大公约数
        static void BattleWord(string name, string word)
        {
            Console.WriteLine("{0}：{1}", name, word);
        }//旗舰开战
        static void Main(string[] args)
        {
            #region 第一题
            //Console.WriteLine("请输入你的名字：");
            //string name = Console.ReadLine();
            //Console.WriteLine("请输入你的语文成绩：");
            //string chinese = Console.ReadLine();
            //Console.WriteLine("请输入你的数学成绩：");
            //string math = Console.ReadLine();
            //Console.WriteLine("请输入你的英语成绩：");
            //string english = Console.ReadLine();
            //float sum = Convert.ToSingle(chinese) + Convert.ToSingle(math) + Convert.ToSingle(english);
            //float avg = sum / 3;
            //Console.WriteLine("{0}，你三门的总分为{1}，平均分为{2}", name, sum, avg); 
            #endregion

            //Console.WriteLine(Convert.ToBoolean(324) && true);

            #region 好感度
            //int favorability = 100;
            //string info = (favorability == 100) ? "Happy End" : "Bad End";
            //Console.WriteLine(info); 
            #endregion

            //int a = 46, b = 642;
            //int output = MaxCommonDivisor(a, b);

            #region 比大小
            //int a = 10;
            //int b = 20;
            //int max = (a > b) ? a : b;
            //Console.WriteLine("{0}和{1}比，{2}是最大的", a, b, max); 
            #endregion

            #region 成绩
            //Console.WriteLine("请输入姓名：");
            //string name = Console.ReadLine();
            //Console.WriteLine("请输入C#成绩：");
            //int cSharp = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入Unity成绩：");
            //int unity = Convert.ToInt32(Console.ReadLine());
            //if (cSharp >= 90 && unity >= 90)
            //{
            //    Console.WriteLine("{0}可以毕业", name);
            //}
            //else
            //{
            //    Console.WriteLine("{0}不能毕业", name);
            //} 
            #endregion

            #region 判断闰年
            //Console.WriteLine("请输入一个年份：");
            //int year = Convert.ToInt32(Console.ReadLine());
            ////Console.WriteLine("今年是"+year"年");
            //bool conditionA = ((year % 400) == 0) ? true : false;
            //bool conditionB = ((year % 4) == 0) ? true : false;
            //bool conditionC = ((year % 100) == 0) ? true : false;
            //Console.WriteLine(year + "年" + ((conditionA || (conditionB && !conditionC)) ? "是闰年" : "不是闰年")); 
            #endregion

            #region 登录
            //Console.WriteLine("请输入账户：");
            //string account = Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string password = Console.ReadLine();
            //if (account == "admin" && password == "123456")
            //{
            //    Console.WriteLine("欢迎{0}，登录成功", account);
            //}
            //else
            //{
            //    Console.WriteLine("用户名或密码错误");
            //}
            #endregion

            #region  判断字符
            //Console.WriteLine("请用户输入一个字符");
            //char input = char.Parse(Console.ReadLine());
            //if ('0' <= input && input <= '9')
            //{
            //    Console.WriteLine("你输入的是一个数字");
            //}
            //else
            //{
            //    Console.WriteLine("你输入的不是一个数字");
            //}
            #endregion

            #region 登录2.0
            //pool:
            //    Console.WriteLine("请输入用户名：");
            //    string account = Console.ReadLine();
            //    Console.WriteLine("请输入密码：");
            //    string password = Console.ReadLine();
            //    if (account == "admin")
            //    {
            //        if (password == "888888")
            //        {
            //            Console.WriteLine("账号密码正确");
            //        }
            //        else
            //        {
            //            Console.WriteLine("密码错误，请重新输入\n");
            //            goto pool;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("用户不存在，请重新输入\n");
            //        goto pool;
            //    } 
            #endregion

            #region switch计算1
            //    int salary = 4000;
            //    string performance;
            //    int performanceSalary;
            //start:
            //    Console.WriteLine("请输入评级（A  B  C  D  E）：");
            //    performance = Console.ReadLine();
            //    switch (performance)
            //    {
            //        case "A":
            //            performanceSalary = 500;
            //            Console.WriteLine("评级为A级，工资为{0}元", salary + performanceSalary);
            //            break;
            //        case "B":
            //            performanceSalary = 0;
            //            Console.WriteLine("评级为B级，工资为{0}元", salary + performanceSalary);
            //            break;
            //        case "C":
            //            performanceSalary = -300;
            //            Console.WriteLine("评级为C级，工资为{0}元", salary + performanceSalary);
            //            break;
            //        case "D":
            //            performanceSalary = -500;
            //            Console.WriteLine("评级为D级，工资为{0}元", salary + performanceSalary);
            //            break;
            //        case "E":
            //            performanceSalary = -800;
            //            Console.WriteLine("评级为E级，工资为{0}元", salary + performanceSalary);
            //            break;
            //        default:
            //            Console.WriteLine("你的输入有问题请重新输入括号中的英文");
            //            goto start;
            //    } 
            #endregion

            #region switch咖啡            
            //start:
            //    bool condition;
            //    int money = 10;
            //    int sCup = 5;
            //    int mCup = 7;
            //    int lCup = 11;
            //    Console.WriteLine("有三种型号的咖啡\n1.小杯   2.中杯   3.大杯(输入1，2，3)");
            //    string input = Console.ReadLine();


            //    switch (input)
            //    {
            //        case "1":
            //            money -= sCup;
            //            if (money >= 0)
            //            {
            //                condition = true;
            //            }
            //            else
            //            {
            //                condition = false;
            //            }
            //            break;
            //        case "2":
            //            money -= mCup;
            //            if (money >= 0)
            //            {
            //                condition = true;
            //            }
            //            else
            //            {
            //                condition = false;
            //            }
            //            break;
            //        case "3":
            //            money -= lCup;
            //            if (money >= 0)
            //            {
            //                condition = true;
            //            }
            //            else
            //            {
            //                condition = false;
            //            }
            //            break;
            //        default:
            //            Console.WriteLine("\n输入有问题，请输入1，2，3中一个");
            //            goto start;
            //    }
            //    if (condition)
            //    {
            //        Console.WriteLine("\n购买成功还剩" + money + "元");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\n购买成功钱不够，请换其他型号");
            //        goto start;
            //    } 
            #endregion

            #region 评级
            //Console.WriteLine("请输入你的成绩：");
            //int grade = 0;
            //bool condition;
            //do
            //{
            //    condition = int.TryParse(Console.ReadLine(), out grade);
            //    if (!condition)
            //    {
            //        Console.WriteLine("输入有问题，请输入数字");
            //    }
            //} while (!condition);

            //grade = grade / 10;

            //switch (grade)
            //{
            //    case 10:
            //        Console.WriteLine("A");
            //        break;
            //    case 9:
            //        Console.WriteLine("A");
            //        break;
            //    case 8:
            //        Console.WriteLine("B");
            //        break;
            //    case 7:
            //        Console.WriteLine("C");
            //        break;
            //    case 6:
            //        Console.WriteLine("D");
            //        break;
            //    default:
            //        Console.WriteLine("E");
            //        break;
            //} 
            #endregion

            #region 任意数转换成大写 数组+switch
            //Console.WriteLine("请输入一个数：");
            //int input = Convert.ToInt32(Console.ReadLine());
            //int[] num = new int[100];
            //int length = 0;

            //do
            //{
            //    num[length] = input % 10;
            //    input = input / 10;
            //    length++;
            //} while (input != 0);

            //for (int i = length - 1; i >= 0; i--)
            //{
            //    switch (num[i])
            //    {
            //        case 0:
            //            Console.Write("零");
            //            break;
            //        case 1:
            //            Console.Write("一");
            //            break;
            //        case 2:
            //            Console.Write("二");
            //            break;
            //        case 3:
            //            Console.Write("三");
            //            break;
            //        case 4:
            //            Console.Write("四");
            //            break;
            //        case 5:
            //            Console.Write("五");
            //            break;
            //        case 6:
            //            Console.Write("六");
            //            break;
            //        case 7:
            //            Console.WriteLine("七");
            //            break;
            //        case 8:
            //            Console.Write("八");
            //            break;
            //        case 9:
            //            Console.Write("九");
            //            break;
            //        default:
            //            Console.Write("error");
            //            break;
            //    }
            //} 
            #endregion

            #region 年份月份判断天数
            //Console.WriteLine("请输入年份：");
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine("请输入月份：");
            //int month = int.Parse(Console.ReadLine());
            //switch (month)
            //{
            //    case 1:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 2:
            //        if ((year % 400) == 0 || ((year % 4) == 0 && (year % 100) != 0))
            //        {
            //            Console.WriteLine("该月有29天");
            //        }
            //        else
            //        {
            //            Console.WriteLine("该月有28天");
            //        }
            //        break;
            //    case 3:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 4:
            //        Console.WriteLine("该月有30天");
            //        break;
            //    case 5:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 6:
            //        Console.WriteLine("该月有30天");
            //        break;
            //    case 7:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 8:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 9:
            //        Console.WriteLine("该月有30天");
            //        break;
            //    case 10:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    case 11:
            //        Console.WriteLine("该月有30天");
            //        break;
            //    case 12:
            //        Console.WriteLine("该月有31天");
            //        break;
            //    default:
            //        Console.WriteLine("error");
            //        break;
            //} 
            #endregion

            #region 随机数测试
            //Random D6 = new Random();
            //int length = 30;
            //for (int i = 0; i < length; i++)
            //{
            //    int output = D6.Next(1, 101);
            //    Console.WriteLine(output);
            //} 
            #endregion

            #region 随机攻击力减血
            //Random atmATK = new Random();
            //int monsterDEF = 10;
            //int monsterHP = 10;
            //int atmATKmax = 12;
            //int atmATKmin = 8;
            //int trueAtmATK = atmATK.Next(atmATKmin, atmATKmax + 1);
            //int damage = trueAtmATK - monsterDEF;
            //if (damage > 0)
            //{
            //    monsterHP -= damage;
            //    Console.WriteLine("攻击力为{0},怪兽损失{1},怪兽还有{2}HP", trueAtmATK, damage, monsterHP);
            //}
            //else
            //{
            //    damage = 0;
            //    monsterHP -= damage;
            //    Console.WriteLine("攻击力为{0},怪兽损失{1}HP,怪兽还有{2}HP", trueAtmATK, damage, monsterHP);
            //} 
            #endregion

            #region 除了能被7整除之外的和
            //int min = 1;
            //int max = 100;
            //int sum = 0;
            //int divisor = 7;
            //int i = min;
            //while (i <= max)
            //{
            //    if (i % divisor == 0)
            //    {
            //        i++;
            //        continue;
            //    }
            //    else
            //    {
            //        sum += i;
            //        i++;
            //    }
            //}
            //Console.WriteLine("和为" + sum); 
            #endregion

            #region 不知道是不是欧拉的，反正是个素数筛
            //int max = 100;
            //int min = 1;
            //int i = 2;
            //int[] num = new int[max + 1];
            //while (i <= max)
            //{
            //    if (num[i] == 0)
            //    {
            //        Console.Write("{0}\n", i);
            //        for (int j = 2 * i; j <= max; j += i)
            //        {
            //            num[j] = 1;
            //        }
            //    }
            //    i++;
            //}
            #endregion

            #region 累加判断
            //int sum = 0;
            //int min = 1;
            //int max = 100;
            //bool condiction = false;
            //for (int i = min; i <= max; i++)
            //{
            //    sum += i;
            //    if (sum > 500)
            //    {
            //        condiction = true;
            //        Console.WriteLine("累加到第{0}个数字的时候可以使sum大于500，sum的值为{1}", i, sum);
            //        break;
            //    }
            //}
            //if (!condiction)
            //{
            //    Console.WriteLine("一直不能大于500");
            //}
            #endregion

            #region clear
            //string trueAccount = "admin";
            //string truePassword = "888888";
            //while (true)
            //{
            //    Console.WriteLine("请输入用户名：");
            //    string account = Console.ReadLine();
            //    Console.WriteLine("请输入密码：");
            //    string password = Console.ReadLine();
            //    if (account == trueAccount && password == truePassword)
            //    {
            //        Console.WriteLine("登录成功！");
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.WriteLine("账户或密码错误，请重新输入");
            //    }
            //} 
            #endregion

            #region try prase 班级成绩
            //bool numCondition = false;
            //int num = 0;
            //int sum = 0;
            //while (!numCondition)
            //{
            //    Console.WriteLine("请输入班级人数：");
            //    numCondition = int.TryParse(Console.ReadLine(), out num);
            //    if (!numCondition)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("输入的班级人数有规格错误，请重新输入");
            //    }
            //}
            //for (int i = 0; i < num; i++)
            //{
            //gradestart:
            //    Console.WriteLine("请输入第{0}个同学的成绩", i + 1);
            //    int grade;
            //    bool gradeCondition = int.TryParse(Console.ReadLine(), out grade);
            //    if (!gradeCondition)
            //    {
            //        Console.WriteLine("输入的第{0}个同学的成绩有规格错误，请重新输入");
            //        goto gradestart;
            //    }
            //    else
            //    {
            //        sum += grade;
            //    }
            //}
            //float avg = (float)sum / (float)num;
            //Console.WriteLine("该班总成绩为{0}分，平均成绩为{1}分", sum, avg); 
            #endregion

            #region 斐波拉契数列
            //int length = 20;
            //int[] fibonacci = new int[length];
            //fibonacci[0] = 1;
            //fibonacci[1] = 1;
            //for (int i = 2; i < length; i++)
            //{
            //    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //}
            //for (int i = 0; i < length; i++)
            //{
            //    Console.WriteLine("斐波拉契数列的第{0}个是：{1}", i + 1, fibonacci[i]);
            //} 
            #endregion

            #region 猜数字
            //Random D6 = new Random();
            //int min = 1;     //数字范围最小值
            //int max = 100;   //数字范围最大值
            //int num = D6.Next(min, max + 1);
            //int term = 10;  //猜测次数
            //int i = 0;     //记录第几次

            //Console.WriteLine("猜猜随机数是多少（{0}<x<={1}）", min, max);
            //Console.WriteLine("第{0}次尝试，输入你猜的数字吧：", i + 1);

            //for (i = 0; i < term; i++)
            //{
            //inputstart:
            //    int input;
            //    bool inputCondition = int.TryParse(Console.ReadLine(), out input);
            //    if (inputCondition || (input <= max && input >= min))
            //    {
            //        if (input < num)
            //        {
            //            Console.WriteLine("这么小（笑），您就是针男人？");
            //            Console.WriteLine("第{0}次尝试：再猜一个", i + 1);
            //        }
            //        else if (input > num)
            //        {
            //            Console.WriteLine("欸，为什么这么大.....这么大是放不进来的......电脑会坏掉的......");
            //            Console.WriteLine("第{0}次尝试：再猜一个", i + 1);
            //        }
            //        else
            //        {
            //            if (i < 5)
            //            {
            //                Console.WriteLine("你在第{0}次就猜中了，欧皇，去非洲的飞机已经准备好了", i + 1);
            //                break;
            //            }
            //            else if (i == term - 1)
            //            {
            //                Console.WriteLine("你已经游了直布罗陀海峡的一半了，你的非洲子民都在为你招手呢！猜了{0}次才猜中", i + 1);
            //                break;
            //            }
            //            else
            //            {
            //                Console.WriteLine("普普通通上班族，猜了{0}次才猜中", i + 1);
            //                break;
            //            }

            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("kono八嘎，输个数字都能输歪来！\n重数！：");
            //        goto inputstart;
            //    }

            //}
            //if (i == term)
            //{
            //    Console.WriteLine("酋长，不要停下来呀！答案是{0}，Game Over....", num);
            //}
            #endregion

            #region hood and bismarck
            //定义数据
            Random D6 = new Random();

            string hoodName = "HMS Hood胡德";
            int hoodHP = 8445;
            int hoodMaxHP = hoodHP;
            int hood381ATK = 1024;
            int hood381CD = 18;
            int hoodFoundation = 4;
            int hoodLuck = 38;
            string hoodWord = "荣耀与你我同在!";//开战
            string hoodFail = "胜败乃兵家常事，而我们有的是时间";//失败
            string hoodVictor = "温暖的阳光，舒适的海风，漂亮的胜利";//胜利
            string hoodLowHP = "就算是我也有点生气了呢";//血量告急
            bool hoodJudge = true;

            string bismarckName = "KMS Bismarck俾斯麦";
            int bismarckHP = 8762;
            int bismarckMaxHP = bismarckHP;
            int bismarck380ATK = 1056;
            int bismarck380CD = 20;
            int bismarckFoundation = 4;
            int bismarckLuck = 32;
            string bismarckWord = "大家请务必紧随我，别跟着欧根走了。对面的，不管多少，尽管来吧！";//开战
            string bismarckFail = "玷污我骄傲的罪，就在下回以命赎清吧";//失败
            string bismarckVictor = "弱者可能会为此欣喜，不过，我很强";//胜利
            string bismarckLowHP = "大家……都来我的身后";//血量告急
            bool bismarckJudge = true;

            int timeHood = 1;
            int timeBismarck = 1;

            //旗舰开战
            Program.BattleWord(hoodName, hoodWord);
            Program.BattleWord(bismarckName, bismarckWord);
            Console.WriteLine();
            Console.ReadKey(true);

            //TTK
            while (true)
            {

                //hood 开火
                if (timeHood % hood381CD == 0)
                {
                    Console.WriteLine("第{0}分钟：", timeHood);
                    Console.WriteLine("{0}：双联装381mm主炮 Fire！", hoodName);

                    //计算炮塔
                    for (int i = 0; i < hoodFoundation; i++)
                    {
                        int condition = D6.Next(1, 101);
                        if (condition <= hoodLuck)
                        {
                            bismarckHP -= hood381ATK;
                            if (bismarckHP > 0)
                            {
                                Console.WriteLine("命中！{0}受到{1}点伤害，还剩{2}点耐久！", bismarckName, hood381ATK, bismarckHP);
                                if (bismarckHP <= bismarckMaxHP / 4 && bismarckJudge)
                                {
                                    Program.BattleWord(bismarckName, bismarckLowHP);
                                    bismarckJudge = false;
                                }
                            }
                            else
                            {
                                bismarckHP = 0;
                                Console.WriteLine("命中！{0}受到{1}点伤害，还剩{2}点耐久！", bismarckName, hood381ATK, bismarckHP);
                                Console.WriteLine("{0}沉没......", bismarckName);
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("这发偏了，重新测距，注意航速！");
                        }
                    }
                    Console.WriteLine();

                    //暂停
                    Console.ReadKey(true);
                }


                //判断bismarck血量
                if (bismarckHP == 0)
                {
                    Console.WriteLine();
                    Program.BattleWord(hoodName, hoodVictor);
                    Program.BattleWord(bismarckName, bismarckFail);
                    Console.WriteLine("Is Over......");
                    break;
                }



                //bismarck开火
                if (timeBismarck % bismarck380CD == 0)
                {
                    Console.WriteLine("第{0}分钟：", timeBismarck);
                    Console.WriteLine("{0}： 双联装380mm SK C/34舰炮 Feuer!", bismarckName);

                    //计算炮塔
                    for (int i = 0; i < bismarckFoundation; i++)
                    {
                        int condition = D6.Next(1, 101);
                        if (condition <= bismarckLuck)
                        {
                            //引爆弹药库！！
                            int explode = D6.Next(1, 101);
                            if (explode == 7)
                            {
                                hoodHP = 0;
                                Console.WriteLine("命中！{0}的弹药库被引爆了！", hoodName);
                                Console.WriteLine("{0}：啊！咳咳.....", hoodName);
                                break;
                            }


                            hoodHP -= bismarck380ATK;
                            if (hoodHP > 0)
                            {
                                Console.WriteLine("命中！{0}受到{1}点伤害，还剩{2}点耐久！", hoodName, bismarck380ATK, hoodHP);
                                if (hoodHP <= hoodMaxHP / 4 && hoodJudge)
                                {
                                    hoodJudge = false;
                                    Program.BattleWord(hoodName, hoodLowHP);
                                }
                            }
                            else
                            {
                                hoodHP = 0;
                                Console.WriteLine("命中！{0}受到{1}点伤害，还剩{2}点耐久！", hoodName, hood381ATK, hoodHP);
                                Console.WriteLine("{0}沉没......", hoodName);
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("这发偏了，重新测距，注意航速！");
                        }
                    }
                    Console.WriteLine();

                    //暂停
                    Console.ReadKey(true);

                }



                //判断hood
                if (hoodHP == 0)
                {
                    Console.WriteLine("");
                    Program.BattleWord(bismarckName, bismarckVictor);//赢了一方
                    Program.BattleWord(hoodName, hoodFail);//输了一方
                    Console.WriteLine("Is Over......");
                    break;
                }


                //时间走动
                timeHood++;
                timeBismarck++;
            }
            #endregion

            //char a = Console.ReadKey(true).KeyChar;
            //Console.WriteLine("judge");
            //Console.WriteLine(a);








        }
    }
}
