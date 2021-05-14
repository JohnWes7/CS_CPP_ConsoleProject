using System;
using System.Threading;

namespace SnackGame
{
    class Program
    {
        //static bool isGameOver;
        //static Vector dir;

        static void Main(string[] args)
        {
            GameCotrol gameCotrol;

            PrintfUI();

            //初始话选择地图
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("请选择地图：1.默认  2.自定义");
            char input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case '1':
                    gameCotrol = new GameCotrol();
                    break;
                case '2':
                    //选择自定义自定义宽Y
                    ClearMainScreen();
                    Console.SetCursorPosition(20, 10);
                    Console.Write("请输入宽度 (8至25)：");
                    int x = int.Parse(Console.ReadLine());
                    //自定义高Y
                    ClearMainScreen();
                    Console.SetCursorPosition(20, 10);
                    Console.Write("请输入长度 (8至20)：");
                    int y = int.Parse(Console.ReadLine());
                    //定义生成障碍物
                    ClearMainScreen();
                    Console.SetCursorPosition(20, 10);
                    Console.Write("请选择是否随机生成障碍物：1.生成  2.不生成：");
                    char randomInput = Console.ReadKey(true).KeyChar;
                    bool isRandom=true;
                    switch (randomInput)
                    {
                        case '1':
                            isRandom = true;
                            break;
                        case '2':
                            isRandom = false;
                            break;
                        default:
                            break;
                    }
                    //定义难度
                    ClearMainScreen();
                    Console.SetCursorPosition(20, 10);
                    Console.Write("请选择难度：1.简单 2.普通 3.困难：");
                    randomInput = Console.ReadKey(true).KeyChar;
                    int speed=500;
                    switch (randomInput)
                    {
                        case '1':
                            speed = 800;
                            break;
                        case '2':
                            speed = 500;
                            break;
                        case '3':
                            speed = 300;
                            break;
                            
                        default:
                            break;
                    }
                    gameCotrol = new GameCotrol(x, y, speed, isRandom);
                    break;

                default:
                    gameCotrol = new GameCotrol();
                    break;
            }
            //开始游戏
            gameCotrol.RunGame();

            //游戏结束
            ClearMainScreen();
            Console.SetCursorPosition(20, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("游 戏 结 束");

            Console.SetCursorPosition(20, 11);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("分数：{0}", gameCotrol.snake.grade);

            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("速度：{0}ms/格", gameCotrol.GameSpeed);

            Console.SetCursorPosition(20, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("长度：{0}", gameCotrol.snake.body.Count+1);

            gameCotrol.snake.head.position.x = 0;

            #region Control之前
            //Thread thread = new Thread(Input);
            //Map map = new Map(new Vector(5, 3), new Vector(25, 20), ConsoleColor.DarkYellow, "□");
            //Snake snake = new Snake(map, ConsoleColor.Yellow);
            //isGameOver = false;
            //dir = new Vector(0, 0);
            //int gameSpeed = 400;

            //PrintfUI();
            //map.CreatMap();
            //map.DrawMap();

            //map.CreatMap();
            //map.DrawMap();
            //map.CreatFood();

            //thread.Start();
            //while (snake.isDead == false)
            //{
            //    //绘制
            //    snake.Draw();

            //    //停一下
            //    Thread.Sleep(gameSpeed);

            //    //移动
            //    //Input();
            //    snake.Move(dir);

            //    //判断
            //    snake.EventJudge(map);
            //    if (snake.isDead)
            //    {
            //        isGameOver = true;
            //    }



            // }
            //Console.SetCursorPosition(0, 20);
            //Console.WriteLine("游戏结束");

            //Console.SetCursorPosition(0, 20); 
            #endregion
        }



        //static void Input()
        //{

        //    while (isGameOver == false)
        //    {
        //        ConsoleKey input = Console.ReadKey(true).Key;
        //        switch (input)
        //        {
        //            case ConsoleKey.W:
        //                if (dir != new Vector(0, 1))
        //                {
        //                    dir = new Vector(0, -1);
        //                }
        //                break;
        //            case ConsoleKey.A:
        //                if (dir != new Vector(1, 0))
        //                {
        //                    dir = new Vector(-1, 0);
        //                }
        //                break;
        //            case ConsoleKey.S:
        //                if (dir != new Vector(0, -1))
        //                {
        //                    dir = new Vector(0, 1);
        //                }
        //                break;
        //            case ConsoleKey.D:
        //                if (dir != new Vector(-1, 0))
        //                {
        //                    dir = new Vector(1, 0);
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //}
        static void PrintfUI()
        {
            int width2 = 65;
            int width = 90;
            int length = 20;
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
        /// 清理主屏幕
        /// </summary>
        static void ClearMainScreen()
        {
            for (int i = 1; i <= 65; i++)
            {
                for (int j = 3; j <= 22; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

    }
}
