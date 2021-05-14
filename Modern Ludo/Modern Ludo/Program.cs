using System;
using System.Drawing;
using System.Threading;

namespace Modern_Ludo
{
    class Program
    {
        public const string MINE_ICON = "▲";
        public const string TUNNEL_ICON = "卐";
        public const string LUCK_ICON = "◎";
        public const string PAUSE_ICON = "P ";
        public const string PLAYER_ICON = "★";
        public const string INDICATE_ICON = "↘";

        struct Vector
        {
            public int x;
            public int y;
        }

        enum FloorSta
        {
            方块,
            地雷,
            时空隧道,
            幸运轮盘,
            暂停,
        }

        struct Floor
        {
            public Vector position;
            public string icon;
            public FloorSta floorSta;

        }

        struct player
        {
            public int index;
            public int runPoint;
            public string id;
            public Vector position;
            public string icon;
            public bool isAI;
            public int feet;
            public bool isPause;
            public string side;
            public int isLuck;
        }


        static void Main(string[] args)
        {

            Floor[] mapI = new Floor[19];
            Floor[] map = new Floor[60];
            player p1 = new player();
            player p2 = new player();
            int mineCount = 5;
            int tunnelCount = 5;
            int luckCount = 5;
            int pauseCount = 5;

            //开始设置
            StartSetting(ref mineCount, ref tunnelCount, ref luckCount, ref pauseCount);


            //初始化地图
            int round = 1;
            InitializationMapO(map, mineCount, tunnelCount, luckCount, pauseCount);
            InitializationMapI(map, mapI);

            //初始化玩家
            p1.position.x = map[0].position.x;
            p2.position.x = map[30].position.x;
            p1.position.y = map[0].position.y;
            p2.position.y = map[30].position.y;
            p1.index = 0;
            p2.index = 30;
            p1.feet = 0;
            p2.feet = 0;
            p1.icon = PLAYER_ICON;
            p2.icon = PLAYER_ICON;
            p1.side = "left";
            p2.side = "right";
            p1.isLuck = 0;
            p2.isLuck = 0;

            PrintfUI();
            while (true)
            {
                bool jumpOut = false;
                ClearMainScreen();
                Console.SetCursorPosition(12, 8);
                Console.Write("请输入P1玩家名字：");
                p1.id = Console.ReadLine();
                p1.isAI = false;

                while (true)
                {
                    Console.SetCursorPosition(7, 8);
                    Console.Write("欢迎，{0}，请按下数字键选择是单人模式还是双人模式", p1.id);
                    Console.SetCursorPosition(12, 9);
                    Console.Write("1.单人模式，2.双人模式");

                    char key = Console.ReadKey(true).KeyChar;
                    switch (key)
                    {
                        case '1':
                            p2.id = "AI";
                            p2.isAI = true;
                            jumpOut = true;
                            break;
                        case '2':
                            ClearMainScreen();
                            Console.SetCursorPosition(12, 8);
                            Console.Write("请输入P2玩家名字：");
                            p2.id = Console.ReadLine();
                            p2.isAI = false;
                            jumpOut = true;
                            break;
                        default:
                            break;
                    }

                    if (jumpOut)
                    {
                        break;
                    }

                }

                if (jumpOut)
                {
                    break;
                }

            }

            ClearMainScreen();
            DrawMap(map);
            DrawMap(mapI);
            DrawPlayer(p1);
            DrawPlayer(p2);
            //begin
            while (true)
            {


                //画主屏幕
                
                

                //p1回合
                DrawRound(round, p1.id);
                IndicatePlayer(p1);
                DrawMap(map);
                DrawMap(mapI);
                DrawYellowPlayer(p1);
                DrawPlayer(p2);
                if (p1.isPause==false)
                {
                    
                    p1.runPoint = ThrowD6(p1);
                    Thread.Sleep(2000);
                    Move(ref p1, map, mapI);
                    if (isSuccess(p1))
                    {
                        Thread.Sleep(1500);
                        break;
                    }
                    Thread.Sleep(1500);
                    if (p1.isLuck > 0)
                    {
                        p1.runPoint = 2;
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("{0}获得幸运轮盘加成", p1.id);

                        Move(ref p1, map, mapI);
                        if (isSuccess(p1))
                        {
                            Thread.Sleep(1500);
                            break;
                        }
                        p1.isLuck--;
                        Thread.Sleep(1500);
                    }
                    Judge(ref p1, map, mapI);
                    
                    DrawPlayer(p1);
                }
                else
                {
                    ClearBottomScreen();
                    Console.SetCursorPosition(10, 21);
                    Console.Write("{0}被暂停了", p1.id);
                    Thread.Sleep(2000);
                    DrawPlayer(p1);
                    p1.isPause = false;
                }
                
                round++;


                //p2回合
                DrawRound(round, p2.id);
                IndicatePlayer(p2);
                DrawMap(map);
                DrawMap(mapI);
                DrawYellowPlayer(p2);
                DrawPlayer(p1);
                if (p2.isPause == false)
                {

                    p2.runPoint = ThrowD6(p2);
                    Thread.Sleep(2000);
                    Move(ref p2, map, mapI);
                    if (isSuccess(p1))
                    {
                        Thread.Sleep(1500);
                        break;
                    }
                    Thread.Sleep(1500);
                    if (p2.isLuck > 0)
                    {
                        p2.runPoint = 2;
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("{0}获得幸运轮盘加成", p2.id);

                        Move(ref p2, map, mapI);
                        if (isSuccess(p1))
                        {
                            Thread.Sleep(1500);
                            break;
                        }
                        p2.isLuck--;
                        Thread.Sleep(1500);
                    }
                    Judge(ref p2, map, mapI);
                    DrawPlayer(p2);
                }
                else
                {
                    ClearBottomScreen();
                    Console.SetCursorPosition(10, 21);
                    Console.Write("{0}被暂停了", p2.id);
                    Thread.Sleep(2000);
                    DrawPlayer(p2);
                    p2.isPause = false;
                }
                round++;








            }

            Console.SetCursorPosition(1, 25);













        }














        /// <summary>
        /// 初始话地图
        /// </summary>
        /// <param name="map">地图</param>
        /// <param name="mineCount">地雷数量</param>
        /// <param name="tunnelCount">隧道数量</param>
        /// <param name="luckCount">幸运数量</param>
        /// <param name="pauseCount">暂停数量</param>
        static void InitializationMapO(Floor[] map, int mineCount, int tunnelCount, int luckCount, int pauseCount)//初始话外圈地图
        {
            Random d6 = new Random();


            map[0].position.x = 6;
            map[0].position.y = 10;
            map[0].icon = "□";
            map[0].floorSta = FloorSta.方块;

            //全部设置坐标，都变为"□"
            for (int i = 1; i < 6; i++)
            {
                map[i].position.y = map[i - 1].position.y - 1;
                map[i].position.x = map[i - 1].position.x;
                map[i].icon = map[i - 1].icon;
                map[i].floorSta = FloorSta.方块;
            }

            for (int i = 6; i < 26; i++)
            {
                map[i].position.x = map[i - 1].position.x + 1;
                map[i].position.y = map[i - 1].position.y;
                map[i].icon = map[i - 1].icon;
                map[i].floorSta = FloorSta.方块;
            }

            for (int i = 26; i < 36; i++)
            {
                map[i].position.x = map[i - 1].position.x;
                map[i].position.y = map[i - 1].position.y + 1;
                map[i].icon = map[i - 1].icon;
                map[i].floorSta = FloorSta.方块;
            }

            for (int i = 36; i < 56; i++)
            {
                map[i].position.x = map[i - 1].position.x - 1;
                map[i].position.y = map[i - 1].position.y;
                map[i].icon = map[i - 1].icon;
                map[i].floorSta = FloorSta.方块;
            }

            for (int i = 56; i < 60; i++)
            {
                map[i].position.x = map[i - 1].position.x;
                map[i].position.y = map[i - 1].position.y - 1;
                map[i].icon = map[i - 1].icon;
                map[i].floorSta = FloorSta.方块;
            }

            map[30].icon = "==";
            map[0].icon = "==";

            //埋雷
            Bury(map, mineCount, MINE_ICON, FloorSta.地雷);

            //埋隧道
            Bury(map, tunnelCount, TUNNEL_ICON, FloorSta.时空隧道);

            //埋幸运轮盘
            Bury(map, luckCount, LUCK_ICON, FloorSta.幸运轮盘);

            //埋暂停
            Bury(map, pauseCount, PAUSE_ICON, FloorSta.暂停);









        }

        static void InitializationMapI(Floor[] mapO, Floor[] mapI)
        {
            for (int i = 0; i < mapI.Length; i++)
            {
                mapI[i].floorSta = FloorSta.方块;
                mapI[i].position.x = mapO[0].position.x + i + 1;
                mapI[i].position.y = mapO[0].position.y;
                mapI[i].icon = "□";
            }

            mapI[0].icon = "》";
            mapI[mapI.Length - 1].icon = "《";
            mapI[9].icon = "☆";
        }

        /// <summary>
        /// 将该格位置给player
        /// </summary>
        /// <param name="a"></param>
        /// <param name="floor"></param>
        static void PlayerChangePosition(ref player a, Floor floor)
        {
            a.position.x = floor.position.x;
            a.position.y = floor.position.y;
        }

        /// <summary>
        /// 埋东西
        /// </summary>
        /// <param name="map">埋在的地图</param>
        /// <param name="num">数量</param>
        /// <param name="icon">图标</param>
        /// <param name="floorSta">floor类型</param>
        static void Bury(Floor[] map, int num, string icon, FloorSta floorSta)
        {
            Random d6 = new Random();

            while (num > 0)
            {
                int temp = d6.Next(1, map.Length);
                if (map[temp].floorSta == FloorSta.方块 && temp != 30)
                {
                    map[temp].floorSta = floorSta;
                    map[temp].icon = icon;
                    num--;
                }

            }


        }

        /// <summary>
        /// 画地图
        /// </summary>
        /// <param name="map">地图</param>
        static void DrawMap(Floor[] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                Console.SetCursorPosition(map[i].position.x * 2, map[i].position.y);
                Console.Write(map[i].icon);
            }
        }

        /// <summary>
        /// 画地块
        /// </summary>
        /// <param name="cell"></param>
        static void DrawFloor(Floor cell)
        {
            Console.SetCursorPosition(cell.position.x * 2, cell.position.y);
            Console.Write(cell.icon);
        }

        /// <summary>
        /// 打印UI
        /// </summary>
        static void PrintfUI()
        {
            int width2 = 65;
            int width = 90;
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
                    if (j == width2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
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

        /// <summary>
        /// 开局设定
        /// </summary>
        /// <param name="mineCount">地雷数量</param>
        /// <param name="tunnelCount">隧道数量</param>
        /// <param name="luckCount">幸运数量</param>
        /// <param name="pauseCount">暂停数量</param>
        static void StartSetting(ref int mineCount, ref int tunnelCount, ref int luckCount, ref int pauseCount)
        {
            PrintfUI();

            while (true)
            {
                Console.Clear();
                PrintfUI();
                PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                Console.SetCursorPosition(10, 8);
                Console.Write("是否调整随机点个数：");
                Console.SetCursorPosition(10, 9);
                Console.Write("1,调整 2,不调整直接开始");




                //选择要改吗
                char key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        bool escape = false;

                        //选择要改，要改什么
                        while (!escape)
                        {
                            Console.Clear();
                            PrintfUI();
                            PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                            Console.SetCursorPosition(10, 8);
                            Console.Write("请选择要修改的项：");

                            Console.SetCursorPosition(10, 9);
                            Console.Write("1.地雷数量");

                            Console.SetCursorPosition(10, 10);
                            Console.Write("2.时空隧道数量 ");

                            Console.SetCursorPosition(10, 11);
                            Console.Write("3.幸运轮盘数量");

                            Console.SetCursorPosition(10, 12);
                            Console.Write("4.暂停数量");

                            Console.SetCursorPosition(10, 13);
                            Console.Write("5.返回上一级");

                            char inKey = Console.ReadKey(true).KeyChar;
                            switch (inKey)
                            {
                                case '1':
                                    Console.Clear();
                                    PrintfUI();
                                    PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                                    Console.SetCursorPosition(10, 8);
                                    Console.Write("请输入新的地雷数量：");
                                    mineCount = ReceiveInputInt();
                                    break;
                                case '2':
                                    Console.Clear();
                                    PrintfUI();
                                    PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                                    Console.SetCursorPosition(10, 8);
                                    Console.Write("请输入新的时空隧道数量：");
                                    tunnelCount = ReceiveInputInt();
                                    break;
                                case '3':
                                    Console.Clear();
                                    PrintfUI();
                                    PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                                    Console.SetCursorPosition(10, 8);
                                    Console.Write("请输入新的幸运轮盘数量：");
                                    luckCount = ReceiveInputInt();
                                    break;
                                case '4':
                                    Console.Clear();
                                    PrintfUI();
                                    PrintSettingNum(mineCount, tunnelCount, luckCount, pauseCount);
                                    Console.SetCursorPosition(10, 8);
                                    Console.Write("请输入新的暂停数量：");
                                    pauseCount = ReceiveInputInt();
                                    break;
                                case '5':
                                    escape = true;
                                    break;

                                default:
                                    break;
                            }



                        }

                        break;

                    case '2':
                        goto end;
                        break;

                    default:
                        break;
                }




            }

        end:
            Console.Clear();



        }

        /// <summary>
        /// 打印设置的数量到右侧
        /// </summary>
        static void PrintSettingNum(int mineCount, int tunnelCount, int luckCount, int pauseCount)
        {
            Console.SetCursorPosition(67, 8);
            Console.Write("当前设置：");
            Console.SetCursorPosition(70, 9);
            Console.Write("地雷数量：{0}", mineCount);
            Console.SetCursorPosition(70, 10);
            Console.Write("时空隧道数量：{0}", tunnelCount);
            Console.SetCursorPosition(70, 11);
            Console.Write("幸运轮盘数量：{0}", luckCount);
            Console.SetCursorPosition(70, 12);
            Console.Write("暂停数量：{0}", pauseCount);
        }

        /// <summary>
        /// 接受用户输入
        /// </summary>
        /// <returns>返回用户输入</returns>
        static int ReceiveInputInt()
        {
            bool isRight = false;
            int output = 0;

            while (!isRight)
            {
                isRight = int.TryParse(Console.ReadLine(), out output);

                if (!isRight || output < 0 || output > 10)
                {
                    Console.SetCursorPosition(1, 23);
                    Console.Write("输入有误请重新输入");
                }
            }


            return output;

        }

        /// <summary>
        /// 清理主屏幕
        /// </summary>
        static void ClearMainScreen()
        {
            for (int i = 1; i <= 65; i++)
            {
                for (int j = 3; j <= 19; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// 清理右侧屏幕
        /// </summary>
        static void ClearRightScreen()
        {
            for (int i = 67; i <= 88; i++)
            {
                for (int j = 3; j <= 19; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// 清理底部屏幕
        /// </summary>
        static void ClearBottomScreen()
        {
            for (int i = 1; i <= 88; i++)
            {
                for (int j = 21; j <= 24; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// 打印棋子
        /// </summary>
        /// <param name="a">棋子</param>
        static void DrawPlayer(player a)
        {
            Console.SetCursorPosition(a.position.x * 2, a.position.y);
            Console.Write(a.icon);

        }

        static void DrawYellowPlayer(player a)
        {
            Console.SetCursorPosition(a.position.x * 2, a.position.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(a.icon);
            Console.ForegroundColor = ConsoleColor.White;

        }

        /// <summary>
        /// 顶部显示回合数和该回合玩家名字
        /// </summary>
        /// <param name="round">回合数</param>
        /// <param name="id">该回合玩家名字</param>
        static void DrawRound(int round, string id)
        {
            Console.SetCursorPosition(15, 1);
            Console.Write("R O U N D：{0}", round);

            Console.SetCursorPosition(30, 1);
            Console.Write("现在是{0}的回合", id);

        }

        /// <summary>
        /// 提示玩家哪个人的回合
        /// </summary>
        /// <param name="a">该回合的玩家</param>
        static void IndicatePlayer(player a)
        {
            //↖↗↘↙
            Console.ForegroundColor = ConsoleColor.Yellow;

            DrawPlayer(a);


            for (int i = 1; i < 3; i++)
            {

                Thread.Sleep(500);
                Print((a.position.x + i) * 2, a.position.y + i, "↖");
                Print((a.position.x - i) * 2, a.position.y - i, "↘");
                Print((a.position.x - i) * 2, a.position.y + i, "↗");
                Print((a.position.x + i) * 2, a.position.y - i, "↙");

            }
            for (int i = 1; i < 3; i++)
            {

                Thread.Sleep(500);
                Print((a.position.x + i) * 2, a.position.y + i, "  ");
                Print((a.position.x - i) * 2, a.position.y - i, "  ");
                Print((a.position.x - i) * 2, a.position.y + i, "  ");
                Print((a.position.x + i) * 2, a.position.y - i, "  ");

            }


            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 打字
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="word">字</param>
        static void Print(int x, int y, string word)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(word);
        }

        /// <summary>
        /// 投掷骰子
        /// </summary>
        /// <param name="a">该回合的玩家</param>
        /// <returns></returns>
        static int ThrowD6(player a)
        {
            Random d6 = new Random();
            int temp = 0;
            if (a.isAI == false)
            {
                ClearBottomScreen();
                Console.SetCursorPosition(10, 21);
                Console.Write("{0}，请按下空格，掷出骰子", a.id);

                while (true)
                {

                    bool jumpOut = false;
                    char key = Console.ReadKey(true).KeyChar;
                    switch (key)
                    {
                        case ' ':
                            for (int i = 0; i < 20; i++)
                            {
                                Thread.Sleep(50);
                                temp = d6.Next(1, 7);
                                Console.SetCursorPosition(69, 10);
                                Console.Write("骰子：{0}", temp);
                            }
                            for (int i = 0; i < 6; i++)
                            {
                                Thread.Sleep(100);
                                temp = d6.Next(1, 7);
                                Console.SetCursorPosition(69, 10);
                                Console.Write("骰子：{0}", temp);
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                Thread.Sleep(500);
                                temp = d6.Next(1, 7);
                                Console.SetCursorPosition(69, 10);
                                Console.Write("骰子：{0}", temp);
                            }
                            Thread.Sleep(500);
                            jumpOut = true;
                            break;
                        default:
                            break;
                    }

                    if (jumpOut)
                    {
                        break;
                    }

                }

                ClearBottomScreen();
                Console.SetCursorPosition(10, 21);
                Console.Write("{0}掷出的骰子为{1}", a.id, temp);

                return temp;

            }
            else
            {
                ClearBottomScreen();
                Console.SetCursorPosition(10, 21);
                Console.Write("现在是{0}的回合", a.id);
                Thread.Sleep(1000);

                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(50);
                    temp = d6.Next(1, 7);
                    Console.SetCursorPosition(69, 10);
                    Console.Write("骰子：{0}", temp);
                }
                for (int i = 0; i < 6; i++)
                {
                    Thread.Sleep(100);
                    temp = d6.Next(1, 7);
                    Console.SetCursorPosition(69, 10);
                    Console.Write("骰子：{0}", temp);
                }
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(500);
                    temp = d6.Next(1, 7);
                    Console.SetCursorPosition(69, 10);
                    Console.Write("骰子：{0}", temp);
                }

                ClearBottomScreen();
                Console.SetCursorPosition(10, 21);
                Console.Write("{0}掷出的骰子为{1}", a.id, temp);

                Thread.Sleep(1500);

                return temp;

            }
        }

        /// <summary>
        /// 行动
        /// </summary>
        /// <param name="a"></param>
        /// <param name="mapO"></param>
        /// <param name="mapI"></param>
        static void Move(ref player a, Floor[] mapO, Floor[] mapI)
        {
            for (; a.runPoint > 0; a.runPoint--)
            {

                a.feet++;
                if (a.feet == 61)
                {

                    Console.SetCursorPosition((mapO[a.index%60].position.x) * 2, mapO[a.index%60].position.y);
                    Console.Write(mapO[a.index%60].icon);
                    if (a.side == "left")
                    {
                        a.index = 0;
                        a.position.x = mapI[0].position.x;
                        a.position.y = mapI[0].position.y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (a.side == "right")
                    {
                        a.index = 18;
                        a.position.x = mapI[18].position.x;
                        a.position.y = mapI[18].position.y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (a.feet > 61 && a.feet < 70)
                {
                    if (a.side == "left")
                    {
                        DrawFloor(mapI[a.index]);
                        a.index++;
                        PlayerChangePosition(ref a, mapI[a.index]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (a.side == "right")
                    {
                        DrawFloor(mapI[a.index]);
                        a.index--;
                        PlayerChangePosition(ref a, mapI[a.index]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (a.feet >= 70)
                {
                    if (a.side == "left")
                    {
                        DrawFloor(mapI[a.index]);
                        a.index=9;
                        PlayerChangePosition(ref a, mapI[a.index]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                        a.feet = 70;
                        break;
                    }
                    if (a.side == "right")
                    {
                        DrawFloor(mapI[a.index]);
                        a.index=10;
                        PlayerChangePosition(ref a, mapI[a.index]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DrawPlayer(a);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                }
                else
                {
                    DrawFloor(mapO[a.index%60]);
                    a.index++;
                    PlayerChangePosition(ref a, mapO[a.index%60]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    DrawPlayer(a);
                    Console.ForegroundColor = ConsoleColor.White;

                }

                Thread.Sleep(500);

            }
        }

        /// <summary>
        /// 判断脚下的单元格
        /// </summary>
        /// <param name="a"></param>
        /// <param name="mapO"></param>
        /// <param name="mapI"></param>
        static void Judge(ref player a,Floor[] mapO,Floor[] mapI)
        {
            if (a.feet<60)
            {
                switch (mapO[a.index%60].floorSta)
                {
                    case FloorSta.方块:

                        break;
                    case FloorSta.地雷:
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("踩到了");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("地雷!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0}要退后6格", a.id);

                        for (int i = 0; i < 6; i++)
                        {
                            DrawFloor(mapO[a.index%60]);
                            a.index = a.index - 1;
                            a.feet--;
                            if (a.index<0)
                            {
                                a.index = 59;
                            }
                            PlayerChangePosition(ref a, mapO[a.index%60]);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            DrawPlayer(a);
                            Console.ForegroundColor = ConsoleColor.White;

                            Thread.Sleep(500);
                        }
                        break;
                    case FloorSta.时空隧道:
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("{0}进入了时空隧道，前进10格",a.id);
                        a.runPoint = 10;
                        Move(ref a, mapO, mapI);
                        break;
                    case FloorSta.幸运轮盘:
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("{0}获得了幸运轮盘buff，之后每回合可以多走2格,持续3回合",a.id);
                        a.isLuck += 3;
                        break;
                    case FloorSta.暂停:
                        ClearBottomScreen();
                        Console.SetCursorPosition(10, 21);
                        Console.Write("{0}被暂停了，下一个回合不能动",a.id);
                        a.isPause = true;
                        break;
                    default:
                        break;
                }
            }
        }

        static bool isSuccess(player a)
        {
            if (a.feet==70)
            {
                ClearBottomScreen();
                Console.SetCursorPosition(10, 21);
                Console.Write("恭喜{0}赢得了胜利！游戏结束", a.id);
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                return false;
            }
        }







    }
}
