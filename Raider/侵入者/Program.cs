using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Threading.Channels;

namespace Raider
{
    class Program
    {
        const int inWigth = 80;
        static void PrintfUI()//打印UI
        {

            int width = 82;
            int length = 17;
            int length2 = 4;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.Write('\n');
            Console.Write('|');
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write('|');
            Console.Write('\n');



            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");


            for (int i = 0; i < length; i++)
            {
                Console.Write('|');
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|\n");
            }

            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.Write('\n');

            for (int i = 0; i < length2; i++)
            {
                Console.Write('|');
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|\n");
            }

            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.Write('\n');

            //Console.SetCursorPosition=()
        }

        static void Say(string name, string word, int x, int y)//用来说话（名字，话，x坐标，y坐标）
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < inWigth - x + 1; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("{0}：{1}", name, word);
            Console.ReadKey(true);
        }
        static void SayNoPause(string name, string word, int x, int y)//用来说话（名字，话，x坐标，y坐标）
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < inWigth - x + 1; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("{0}：{1}", name, word);
        }
        static void Say(string name, int num, int x, int y)
        {
            //Console.SetCursorPosition(x, y);
            //for (int i = 0; i < inWigth - x + 1; i++)
            //{
            //    Console.Write(" ");
            //}
            Console.SetCursorPosition(x, y);
            Console.Write("{0}：{1}", name, num);
            //Console.ReadKey(true);
        }

        static void PrHPATK(int myHP, int myATK)
        {
            Program.Say("耐久值", myHP, 1, 23);
            Program.Say("ATK", myATK, 1, 24);
        }//打印耐久攻击力

        static void PrPoint(int x, int y, char figure)//打印地图上的人物
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write(figure);
        }

        static void PrWeapon(bool drone3,bool urban4)
        {
            if (drone3)
            {
                Console.SetCursorPosition(25, 23);
                Console.Write("攻击无人机群,就绪");
            }
            if (urban4)
            {
                Console.SetCursorPosition(25, 24);
                Console.Write("乌尔班闪电大炮,就绪");
            }
        }


        static void PrPaccReport(string name, int ATK, int x, int y)//遭到或者进攻报告(不暂停)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < inWigth - x + 1; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y);
            if (ATK >= 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("P.A.C.C：{0}的行动成功了，对方损失{1}的耐久！", name, ATK);
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("P.A.C.C：做好准备，遭到{0}的攻击，我们损失了{1}的耐久", name, 0-ATK);
            }
        }


        //public int a=0;
        static void PrResources(int month, int oil, int iron, int aluminium)//打印资源月份
        {
            //Program.a += 1;
            Program.Say("month", month, 1, 1);
            Program.Say("oil", oil, 16, 1);
            Program.Say("iron", iron, 31, 1);
            Program.Say("aluminium", aluminium, 46, 1);
        }
        static void PrResources(long hour, int oil, int iron, int aluminium)//打印资源小时
        {
            //Program.a += 1;
            Program.Say("hour", (int)hour, 1, 1);
            Program.Say("oil", oil, 16, 1);
            Program.Say("iron", iron, 31, 1);
            Program.Say("aluminium", aluminium, 46, 1);
        }

        static void PrReturn()//打印回车键退出
        {
            Console.SetCursorPosition(61, 18);
            Console.Write("按回车退出基地");
        }
        static void Main(string[] args)
        {
            //▲：土著敌人     □：事件      ▼：玩家       ■：基地
            //基地周围刷敌人
            //基础
            Random d6 = new Random();
            int baseX = 20;
            int baseY = 11;
            int bottomUIY = 21;
            int month = 1;
            int varMonth = month;
            int oil = 200;
            int iron = 200;
            int aluminium = 50;

            //player 
            bool myJudge = true;
            int myHP = 2000;
            int myMaxHP = myHP;
            int myX = baseX;
            int myY = baseY + 1;
            int myATK = 114;
            int myCD = 14;
            int myLuck = 90;
            bool drone3 = false;
            bool urban4 = false;
            bool wpDrone = false;
            bool wpUrban = false;
            int droneOil = 50;
            int urbanOil = 10;
            int droneATK = 75;
            int droneCD = 20;
            int urbanATK = 500;
            int urbanCD = 15;
            string droneName = "无人机攻击群";
            string urbanName = "乌尔班大炮";
            int droneLuck = 60;
            int urbanLuck = 100;
            string droneMiss = "没打中！重来！这都没打中还想开无人机！";
            

            //map
            int mapTop = 3;
            int mapLeft = 1;
            int mapRigth = 39;
            int mapBottom = 19;
            int[,] map = new int[mapRigth + 1, mapBottom + 1];

            //事件
            int eventX;
            int eventY;


            //pacc
            string PACCName = "P.A.C.C";
            string PACCNoShop = "你没有足够的资源进行该操作 (按任意键继续)";
            string PACCYesShop = "操作成功 (按任意键继续)";
            string myFire = "集中火力，攻击！";
            string droneFire = "我方无人机群升空！";
            string urbanFire = "吊死威尼斯总督，他将如闪电班归来！";
            string FanllyATK = "呼...作战…完成";

            //异星土著
            string hoodName = "HMS Hood";
            int hoodX;
            int hoodY;
            int hoodHP = 844;
            int hoodMaxHP = hoodHP;
            int hood381ATK = 102;
            int hood381CD = 18;
            int hoodFoundation = 4;
            int hoodLuck = 38;
            string hoodWord = "荣耀与你我同在!";//开战
            string hoodFail = "胜败乃兵家常事，而我们有的是时间";//失败
            string hoodVictor = "温暖的阳光，舒适的海风，漂亮的胜利";//胜利
            string hoodLowHP = "就算是我也有点生气了呢";//血量告急
            string hoodFire = "双联装381mm主炮 Fire！";//开火
            string hoodHit = "优雅，可不是花瓶";//命中
            string hoodNoHit = "唉……看来不下猛药不行了呢";//没命中
            bool hoodJudge = true;

            string bismarckName = "KMS Bismarck";
            int bismarckX;
            int bismarckY;
            int bismarckHP = 876;
            int bismarckMaxHP = bismarckHP;
            int bismarck380ATK = 105;
            int bismarck380CD = 20;
            int bismarckFoundation = 4;
            int bismarckLuck = 32;
            string bismarckWord = "大家请务必紧随我，别跟着欧根走了。对面的，不管多少，尽管来吧！";//开战
            string bismarckFail = "玷污我骄傲的罪，就在下回以命赎清吧";//失败
            string bismarckVictor = "弱者可能会为此欣喜，不过，我很强";//胜利
            string bismarckLowHP = "大家……都来我的身后";//血量告急
            string bismarckFire = "双联装380mm SK C/34舰炮 Feuer!";//开火
            string bismarckHit = "真理只在我的射程范围内";//命中
            string bismarckNoHit = "Wie kann das möglich sein?";//没命中
            bool bismarckJudge = true;



            //UI
            Program.PrintfUI();


            //开头
            #region 线性开头
            Console.SetCursorPosition(15 * 2, 5);
            Console.WriteLine("▼*  R A I D E R  *▲");
            Console.SetCursorPosition(14 * 2, 6);
            Console.WriteLine("press any key to continue");
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("先别急着按，下面有文字教程：");
            Console.WriteLine("控制台版本：");
            Console.WriteLine("▲：土著敌人    □：事件(还没有)     ▼：玩家     ■：基地");
            Console.WriteLine("每打完一个敌人月份会+1，撑到第六个月就算赢了");
            Console.WriteLine("如果你的耐久值被打成0了，Game Over");
            Console.WriteLine();
            Console.WriteLine("控制台实在是不好做随机的机制，以后用Unity做的话机制应该是（原本的想法）：");
            Console.WriteLine("定义是一个类rougelite游戏");
            Console.WriteLine("会新增战斗地图，战斗方式变成远行星号（StarSector）那个样子在而外的战斗地图进行，\n但还是没多派出一个单元，要多消耗燃料，可以手动操纵任意一个");
            Console.WriteLine("新增自己的种族，有几种初始战斗单位可选");
            Console.WriteLine("大地图是随机生成的，每一块有自己的地形固定模型，上面有可能有资源，战斗地图只有几个，和大地图上格子的地形对应");
            Console.WriteLine("下来的轨道空投仓（也就是玩家的基地）会把离基地4格范围内的资源进行收集，并且离基地小于等于4格的格子会变为你的占领区域");
            Console.WriteLine("敌人和事件点会在你的占领区域外沿着边缘刷新，每个月会刷2（暂定）个敌人有可能是精英，和一个事件点（未完成）");
            Console.WriteLine("每个月你只能在这两几个敌人和事件点中选一个，做完之后就会进入下一个月");
            Console.WriteLine("如果你选择去事件点，事件点有好有坏有战斗，选完选项会有个事件结尾，比如会给专门的作战单位，或者遗物（控制台项目里也没做）");
            Console.WriteLine("如果是去敌人，打完获胜后，会按照敌人所在的点为原点，4格范围内的所有地区全部会给你");
            Console.WriteLine("游戏目标就是把地区全部占领完就算赢了");
            Console.WriteLine();
            Console.WriteLine("好了，往上滚一下滚轮");
            Console.ReadKey(true);

            

            Console.Clear();
            Program.PrintfUI();
            Console.SetCursorPosition(20 * 2, 6);
            Console.Write("||");
            Console.SetCursorPosition(20 * 2, 7);
            Console.Write("■");
            Program.Say(PACCName, "系统初始化...完成，你好，行动指挥官，我叫Perceptual AI Combat Computer", 1, bottomUIY);

            Console.SetCursorPosition(20 * 2, 7);
            Console.Write("||");
            Console.SetCursorPosition(20 * 2, 8);
            Console.Write("■");
            Program.Say(PACCName, "什么，太长了？叫我PACC就好，毕竟我也也是实验的第一台", 1, bottomUIY);

            Console.SetCursorPosition(20 * 2, 8);
            Console.Write("||");
            Console.SetCursorPosition(20 * 2, 9);
            Console.Write("■");
            Program.Say(PACCName, "ETA 5min....反推引擎点火，完毕", 1, bottomUIY);

            Console.SetCursorPosition(20 * 2, 6);
            Console.Write("  ");
            Console.SetCursorPosition(20 * 2, 9);
            Console.Write("||");
            Console.SetCursorPosition(20 * 2, 10);
            Console.Write("■");
            Program.Say(PACCName, "ETA 10sec，嵌入式缓冲支架已展开，Prepare for impact！！", 1, bottomUIY);

            Console.SetCursorPosition(20 * 2, 7);
            Console.Write("  ");
            Console.SetCursorPosition(20 * 2, 8);
            Console.Write("  ");
            Console.SetCursorPosition(20 * 2, 9);
            Console.Write("  ");
            Console.SetCursorPosition(20 * 2, 10);
            Console.Write("  ");
            Console.SetCursorPosition(20 * 2, 11);
            Console.Write("■");
            Program.Say(PACCName, "已着陆，检查完整性....完成，先遣队基地建设.....完成，击败他们的头目，\n|光复地联！", 1, bottomUIY);
            //Console.SetCursorPosition(1, bottomUIY);
            //Console.Write(hoodVictor);
            //Console.ReadKey();
            #endregion


            //初始化地图
            #region 初始化地图
            while (true)
            {
                hoodX = d6.Next(mapLeft, mapRigth + 1);
                hoodY = d6.Next(mapTop, mapBottom + 1);
                if ((hoodY != baseY && hoodX != baseX) && (hoodY != myY && hoodX != myX))
                {
                    break;
                }
            }
            while (true)
            {
                bismarckX = d6.Next(mapLeft, mapRigth + 1);
                bismarckY = d6.Next(mapTop, mapBottom + 1);
                if ((bismarckY != baseY && bismarckX != baseX) && (bismarckY != myY && bismarckX != myX) && (bismarckX != hoodX && bismarckY != hoodY))
                {
                    break;
                }
            }

            //for (int i = 0; i <= mapRigth; i++)
            //{
            //    for (int j = 0; j < mapBottom; j++)
            //    {

            //    }
            //} 
            #endregion

            #region 本体
            while (true)
            {
                Console.Clear();//清屏

                #region 打印
                //打印UI
                Program.PrintfUI();
                Program.PrHPATK(myHP, myATK);

                //打印资源
                Program.PrResources(month, oil, iron, aluminium);
                PrWeapon(drone3, urban4);


                //打印自己 
                Program.PrPoint(myX, myY, '▼');
                Program.PrPoint(hoodX, hoodY, '▲');
                Program.PrPoint(bismarckX, bismarckY, '▲');
                Console.SetCursorPosition(baseX * 2, baseY);
                Console.Write("■");

                if (month>=6)
                {
                    Console.Clear();
                    //打印UI
                    Program.PrintfUI();
                    Program.PrHPATK(myHP, myATK);

                    //打印资源
                    Program.PrResources(month, oil, iron, aluminium);
                    PrWeapon(drone3, urban4);
                    Say(PACCName, "耗时六个月的攻势，终于落下帷幕了吗.....", 18, 6);
                    break;
                }

                #endregion

                #region 移动
                char move = Console.ReadKey(true).KeyChar;
                switch (move)
                {
                    case 'w':
                        myY -= 1;
                        if (myY <= 2)
                        {
                            myY = 3;
                        }
                        break;
                    case 'a':
                        myX -= 1;
                        if (myX <= 0)
                        {
                            myX = 1;
                        }
                        break;
                    case 's':
                        myY += 1;
                        if (myY >= bottomUIY - 1)
                        {
                            myY = bottomUIY - 2;
                        }
                        break;
                    case 'd':
                        myX += 1;
                        if (myX >= 40)
                        {
                            myX = 39;
                        }
                        break;
                    case '\r':
                        month++;
                        break;
                }
                #endregion

                #region 基地商店
                if (myX == baseX && myY == baseY)
                {
                shop:

                    //价格   
                    int costIron1 = myMaxHP - myHP;
                    int costIron2 = 200;
                    int costIron3 = 150;
                    int costAluminium3 = 50;
                    int costIron4 = 200;
                    int costAluminium4 = 50;
                    int costHP4 = 1500;

                    #region 打印
                    Console.Clear();
                    Program.PrintfUI();
                    Program.PrResources(month, oil, iron, aluminium);
                    Program.PrHPATK(myHP, myATK);

                    Say(PACCName, "欢迎回来，长官，按下数字键进行对应的操作", 1, bottomUIY);
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("损害管理：");
                    Console.SetCursorPosition(2, 6);
                    Console.WriteLine("   1.维修至满耐久 iron:{0}", costIron1);
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("升级：");
                    Console.SetCursorPosition(2, 8);
                    Console.WriteLine("   2.加强进攻性装备 iron:{0}", costIron2);
                    Console.SetCursorPosition(2, 9);
                    Console.Write("制造：");
                    Console.SetCursorPosition(2, 10);
                    Console.Write("  3.无人机攻击群 iron:{0} aluminium:{1}", costIron3, costAluminium4);
                    Console.SetCursorPosition(2, 11);
                    Console.Write("  4.乌尔班大炮 iron:{0}  aluminium:{1} HP:{2}", costIron4, costAluminium4, costHP4);
                    Console.SetCursorPosition(61, 18);
                    Console.Write("按回车退出基地");

                    #endregion

                    #region 购买流程
                    char input = Console.ReadKey(true).KeyChar;
                    switch (input)
                    {
                        case '1'://血量
                            if (costIron1 > iron)
                            {
                                Program.Say(PACCName, PACCNoShop, 1, bottomUIY);
                                goto shop;
                            }
                            else
                            {
                                myHP = myMaxHP;
                                iron -= costIron1;
                                Program.Say(PACCName, PACCYesShop, 1, bottomUIY);
                                goto shop;
                            }
                            break;
                        case '2'://升级攻击力
                            if (costIron2 > iron)
                            {
                                Program.Say(PACCName, PACCNoShop, 1, bottomUIY);
                                goto shop;
                            }
                            else
                            {
                                iron -= costIron2;
                                myATK += 100;
                                Program.Say(PACCName, PACCYesShop, 1, bottomUIY);
                                goto shop;
                            }
                            break;
                        case '3'://无人机攻击群
                            if (costIron3 <= iron && costAluminium3 <= aluminium && !drone3)
                            {
                                iron -= costIron3;
                                aluminium -= costAluminium3;
                                drone3 = true;
                                Program.Say(PACCName, PACCYesShop, 1, bottomUIY);
                                goto shop;
                            }
                            else
                            {
                                Program.Say(PACCName, PACCNoShop, 1, bottomUIY);
                                goto shop;
                            }
                            break;
                        case '4'://乌尔班大炮
                            if (costIron4 <= iron && costAluminium4 <= aluminium && costHP4 <= myHP && !urban4)
                            {
                                iron -= costIron4;
                                aluminium -= costAluminium4;
                                myHP -= costHP4;
                                urban4 = true;
                                Program.Say(PACCName, PACCYesShop, 1, bottomUIY);
                                goto shop;
                            }
                            else
                            {
                                Program.Say(PACCName, PACCNoShop, 1, bottomUIY);
                                goto shop;
                            }
                            break;
                        case '\r':
                            break;


                    }
                    #endregion


                }
                #endregion

                #region 战斗
                //与俾斯麦战斗
                if (bismarckX == myX && bismarckY == myY)
                {
                    bool condition = true;
                    long hour = 0;
                    int bismarckBatHP = bismarckHP;
                    wpDrone = false;
                    wpUrban = false;
                    Console.Clear();
                    PrintfUI();
                    PrHPATK(myHP, myATK);
                    PrResources(hour, oil, iron, aluminium);


                    #region 上场
                    while (condition)//选择上场消耗油
                    {
                    chose:
                        Console.Clear();
                        PrintfUI();
                        PrHPATK(myHP, myATK);
                        PrResources(hour, oil, iron, aluminium);
                        Console.SetCursorPosition(20, 5);
                        if (drone3)
                        {
                            Console.WriteLine("1.{0}   油耗:{1}  ATK:{2}   CD:{3}    {4}", droneName, droneOil, droneATK, droneCD, wpDrone);
                        }
                        Console.SetCursorPosition(20, 6);
                        if (urban4)
                        {
                            Console.WriteLine("2.{0}   油耗:{1}  ATK:{2}   CD:{3}    {4}", urbanName, urbanOil, urbanATK, urbanCD, wpUrban);
                        }

                        Say(PACCName, "按数字键启用或者关闭,如果没有请直接回车继续（按下）", 1, bottomUIY);

                        char choseWp = Console.ReadKey(true).KeyChar;
                        switch (choseWp)
                        {
                            case '1':
                                if (wpDrone)
                                {
                                    wpDrone = false;
                                    oil += droneOil;
                                }
                                else
                                {
                                    wpDrone = true;
                                    oil -= droneOil;
                                }
                                goto chose;
                                break;
                            case '2':
                                if (wpUrban)
                                {
                                    oil += urbanOil;
                                    wpUrban = false;
                                }
                                else
                                {
                                    oil -= urbanOil;
                                    wpUrban = true;
                                }
                                goto chose;
                                break;
                            case '\r':
                                condition = false;
                                break;
                            default:
                                goto chose;
                                break;
                        }
                    }
                    #endregion
                    Console.Clear();

                    while (true)
                    {


                        int sayX = 5;
                        int sayY = 4;
                        
                        PrintfUI();
                        PrHPATK(myHP, myATK);
                        PrResources(hour, oil, iron, aluminium);
                        Say("KMS Bimarck", bismarckBatHP, 20, 5);
                        Say("ATK", bismarck380ATK, 20, 6);
                        if (hour == 0) Say(bismarckName, bismarckWord, 5, 4);

                        hour++;

                        #region bismarck term
                        if (hour % bismarck380CD == 0)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= bismarckLuck)
                            {
                                myHP -= bismarck380ATK;
                                if(myHP<0)
                                {
                                    myHP = 0;
                                }
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(bismarckName, bismarckFire, sayX, sayY);
                                PrPaccReport(bismarckName, 0 - bismarck380ATK, 1, bottomUIY);
                                Say(bismarckName, bismarckHit, sayX, sayY + 3);//命中
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(bismarckName, bismarckFire, sayX, sayY);
                                Say(bismarckName, bismarckNoHit, sayX, sayY + 3);//没命中

                            }

                            if (myHP == 0)
                            {
                                myJudge = false;
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(bismarckName, bismarckVictor, sayX, sayY);
                                Say(PACCName, "我.....好像......失败..了,,呢..........", 1, bottomUIY);
                                break;
                            }
                        }
                        #endregion

                        

                        #region my term
                        if (hour % myCD == 0)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= myLuck)
                            {
                                 bismarckBatHP-= myATK;
                                if (bismarckBatHP < 0)
                                {
                                    bismarckBatHP = 0;
                                }
                                
                                Console.Clear();
                                
                                PrintfUI();
                                if (bismarckBatHP <= bismarckHP / 4)
                                {
                                    SayNoPause(bismarckName, bismarckLowHP, sayX, sayY);
                                }
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                
                                PrPaccReport("指挥官", myATK, 1, bottomUIY+1);//命中
                                Say(PACCName, myFire, 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);

                                SayNoPause(PACCName, "指挥官你在干什么呀！指挥官！不要停下来呀！", 1, bottomUIY+1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (bismarckBatHP == 0)
                            {
                                bismarckJudge = false;
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(bismarckName, bismarckFail, sayX, sayY);
                                break;
                            }

                        }
                        #endregion


                        #region Drone term
                        if (hour % droneCD == 0&&wpDrone )
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= droneLuck)
                            {

                                bismarckBatHP -= droneATK;
                                if (bismarckBatHP < 0)
                                {
                                    bismarckBatHP = 0;
                                }

                                Console.Clear();
                                if(bismarckBatHP <= bismarckHP / 4)
                                {
                                    SayNoPause(bismarckName, bismarckLowHP, sayX, sayY);
                                }
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);

                                PrPaccReport(droneName, droneATK, 1, bottomUIY + 1);//命中
                                Say(PACCName, droneFire, 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);

                                SayNoPause(PACCName,droneMiss , 1, bottomUIY + 1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (bismarckBatHP == 0)
                            {
                                bismarckJudge = false;
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(bismarckName, bismarckFail, sayX, sayY);
                                break;
                            }

                        }

                        #endregion

                        #region urban term
                        if (hour % urbanCD == 0 && wpUrban)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= urbanLuck)
                            {

                                bismarckBatHP -= urbanATK;
                                if (bismarckBatHP < 0)
                                {
                                    bismarckBatHP = 0;
                                }

                                Console.Clear();
                                if (bismarckBatHP <= bismarckHP / 4)
                                {
                                    SayNoPause(bismarckName, bismarckLowHP, sayX, sayY);
                                }
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);

                                PrPaccReport(urbanName, urbanATK, 1, bottomUIY + 1);//命中
                                Say(PACCName,urbanFire , 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);

                                SayNoPause(PACCName, droneMiss, 1, bottomUIY + 1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (bismarckBatHP == 0)
                            {
                                bismarckJudge = false;
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("KMS Bimarck", bismarckBatHP, 20, 5);
                                Say("ATK", bismarck380ATK, 20, 6);
                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(bismarckName, bismarckFail, sayX, sayY);
                                break;
                            }

                        }
                        #endregion


                    }

                    if (!myJudge)
                    {
                        break;
                    }
                    else
                    {
                        int addOil = d6.Next(50, 101);
                        int addIron = d6.Next(200, 301);
                        int addAluminium = d6.Next(0, 51);
                        oil += addOil;
                        iron += addIron;
                        aluminium += addAluminium;

                        Console.SetCursorPosition(1, bottomUIY);
                        Console.Write("P.A.C.C：我们她守护的地方弄到了不少好东西");
                        Console.SetCursorPosition(1, bottomUIY+1);
                        Console.Write("P.A.C.C：我们获得了{0}  Oil，{1}  Iron，{2}  Aluminium",addOil,addIron,addAluminium);
                        Console.ReadKey(true);
                        month++;
                        goto NextMonth;
                    }
                }



                //与hood战斗
                if (hoodX == myX && hoodY == myY)
                {
                    bool condition = true;
                    long hour = 0;
                    int hoodBatHP = bismarckHP;
                    wpDrone = false;
                    wpUrban = false;
                    Console.Clear();
                    PrintfUI();
                    PrHPATK(myHP, myATK);
                    PrResources(hour, oil, iron, aluminium);


                    #region 上场
                    while (condition)//选择上场消耗油
                    {
                    chose:
                        Console.Clear();
                        PrintfUI();
                        PrHPATK(myHP, myATK);
                        PrResources(hour, oil, iron, aluminium);
                        Console.SetCursorPosition(20, 5);
                        if (drone3)
                        {
                            Console.WriteLine("1.{0}   油耗:{1}  ATK:{2}   CD:{3}    {4}", droneName, droneOil, droneATK, droneCD, wpDrone);
                        }
                        Console.SetCursorPosition(20, 6);
                        if (urban4)
                        {
                            Console.WriteLine("2.{0}   油耗:{1}  ATK:{2}   CD:{3}    {4}", urbanName, urbanOil, urbanATK, urbanCD, wpUrban);
                        }

                        Say(PACCName, "按数字键启用或者关闭,如果没有请直接回车继续（按下）", 1, bottomUIY);

                        char choseWp = Console.ReadKey(true).KeyChar;
                        switch (choseWp)
                        {
                            case '1':
                                if (wpDrone)
                                {
                                    wpDrone = false;
                                    oil += droneOil;
                                }
                                else
                                {
                                    wpDrone = true;
                                    oil -= droneOil;
                                }
                                goto chose;
                                break;
                            case '2':
                                if (wpUrban)
                                {
                                    oil += urbanOil;
                                    wpUrban = false;
                                }
                                else
                                {
                                    oil -= urbanOil;
                                    wpUrban = true;
                                }
                                goto chose;
                                break;
                            case '\r':
                                condition = false;
                                break;
                            default:
                                goto chose;
                                break;
                        }
                    }
                    #endregion
                    Console.Clear();

                    while (true)
                    {


                        int sayX = 5;
                        int sayY = 4;

                        PrintfUI();
                        PrHPATK(myHP, myATK);
                        PrResources(hour, oil, iron, aluminium);
                        Say("HMS Hood", hoodBatHP, 20, 5);
                        Say("ATK", hood381ATK, 20, 6);

                        if (hour == 0) Say(hoodName, hoodWord, 5, 4);

                        hour++;

                        #region hood term
                        if (hour % hood381CD == 0)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= hoodLuck)
                            {
                                myHP -= hood381ATK;
                                if (myHP < 0)
                                {
                                    myHP = 0;
                                }
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(hoodName,hoodFire , sayX, sayY);
                                PrPaccReport(hoodName, 0 - hood381ATK, 1, bottomUIY);
                                Say(hoodName, hoodHit, sayX, sayY + 3);//命中
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(hoodName, hoodFire, sayX, sayY);
                                Say(hoodName, bismarckNoHit, sayX, sayY + 3);//没命中

                            }

                            if (myHP == 0)
                            {
                                myJudge = false;
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(hoodName, hoodVictor, sayX, sayY);
                                Say(PACCName, "我.....好像......失败..了,,呢..........", 1, bottomUIY);
                                break;
                            }
                        }
                        #endregion



                        #region my term
                        if (hour % myCD == 0)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= myLuck)
                            {
                                hoodBatHP -= myATK;
                                if (hoodBatHP < 0)
                                {
                                    hoodBatHP = 0;
                                }
                                Console.Clear();
                                if (hoodBatHP <= hoodHP / 4)
                                {
                                    SayNoPause(hoodName, hoodLowHP, sayX, sayY);
                                }
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                PrPaccReport("指挥官", myATK, 1, bottomUIY + 1);//命中
                                Say(PACCName, myFire, 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, "指挥官你在干什么呀！指挥官！不要停下来呀！", 1, bottomUIY + 1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (hoodBatHP == 0)
                            {
                                hoodJudge = false;
                                Console.Clear();

                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(hoodName, hoodFail, sayX, sayY);
                                break;
                            }

                        }
                        #endregion


                        #region Drone term
                        if (hour % droneCD == 0 && wpDrone)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= droneLuck)
                            {

                                hoodBatHP -= droneATK;
                                if (hoodBatHP < 0)
                                {
                                    hoodBatHP = 0;
                                }

                                Console.Clear();
                                if (hoodBatHP <= hoodHP / 4)
                                {
                                    SayNoPause(hoodName, hoodLowHP, sayX, sayY);
                                }
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                PrPaccReport(droneName, droneATK, 1, bottomUIY + 1);//命中
                                Say(PACCName, droneFire, 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, droneMiss, 1, bottomUIY + 1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (hoodBatHP == 0)
                            {
                                hoodJudge = false;
                                Console.Clear();

                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(hoodName, hoodFail, sayX, sayY);
                                break;
                            }

                        }

                        #endregion

                        #region urban term
                        if (hour % urbanCD == 0 && wpUrban)
                        {
                            int luck = d6.Next(1, 101);



                            if (luck <= urbanLuck)
                            {

                                hoodBatHP -= urbanATK;
                                if (hoodBatHP < 0)
                                {
                                    hoodBatHP = 0;
                                }

                                Console.Clear();
                                if (hoodBatHP <= hoodHP / 4)
                                {
                                    SayNoPause(hoodName, hoodLowHP, sayX, sayY);
                                }
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                PrPaccReport(urbanName, urbanATK, 1, bottomUIY + 1);//命中
                                Say(PACCName, urbanFire, 1, bottomUIY);//开火
                            }
                            else
                            {
                                Console.Clear();
                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, droneMiss, 1, bottomUIY + 1);
                                Say(PACCName, myFire, 1, bottomUIY);//开火

                            }

                            if (hoodBatHP == 0)
                            {
                                hoodJudge = false;
                                Console.Clear();

                                PrintfUI();
                                PrHPATK(myHP, myATK);
                                PrResources(hour, oil, iron, aluminium);
                                Say("HMS Hood", hoodBatHP, 20, 5);
                                Say("ATK", hood381ATK, 20, 6);

                                SayNoPause(PACCName, FanllyATK, 1, bottomUIY);
                                Say(hoodName, hoodFail, sayX, sayY);
                                break;
                            }

                        }
                        #endregion


                    }

                    if (!myJudge)
                    {
                        break;
                    }
                    else
                    {
                        int addOil = d6.Next(50, 101);
                        int addIron = d6.Next(200, 301);
                        int addAluminium = d6.Next(0, 51);
                        oil += addOil;
                        iron += addIron;
                        aluminium += addAluminium;

                        Console.SetCursorPosition(1, bottomUIY);
                        Console.Write("P.A.C.C：我们她守护的地方弄到了不少好东西");
                        Console.SetCursorPosition(1, bottomUIY + 1);
                        Console.Write("P.A.C.C：我们获得了{0}  Oil，{1}  Iron，{2}  Aluminium", addOil, addIron, addAluminium);
                        Console.ReadKey(true);
                        month++;
                        goto NextMonth;
                    }
                }
            #endregion


            NextMonth:
                if (month == varMonth + 1)//如果月份变了就重新roll
                {
                    varMonth = month;
                    hoodJudge = true;
                    bismarckJudge = true;

                    while (true)
                    {
                        hoodX = d6.Next(mapLeft, mapRigth + 1);
                        hoodY = d6.Next(mapTop, mapBottom + 1);
                        if ((hoodY != baseY && hoodX != baseX) && (hoodY != myY && hoodX != myX))
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        bismarckX = d6.Next(mapLeft, mapRigth + 1);
                        bismarckY = d6.Next(mapTop, mapBottom + 1);
                        if ((bismarckY != baseY && bismarckX != baseX) && (bismarckY != myY && bismarckX != myX) && (bismarckX != hoodX && bismarckY != hoodY))
                        {
                            break;
                        }
                    }
                    
                }

            }
            #endregion

            Console.Clear();
            //打印UI
            Program.PrintfUI();
            Program.PrHPATK(myHP, myATK);

            //打印资源
            Program.PrResources(month, oil, iron, aluminium);
            PrWeapon(drone3, urban4);

            
            Say(PACCName, "It's.....Over......", 24, 6);
            if(myJudge)
            {
                Say(PACCName, "我们的名字无人知晓，我们的功绩永世长存!", 18, 6);
            }
            else
            {
                Say(PACCName, "是时候....该做个告别了......", 24, 6);
            }


        }
    }
}
