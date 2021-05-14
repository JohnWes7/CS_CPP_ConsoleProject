using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnackGame
{
    class GameCotrol
    {
        Map map;
        public Snake snake;
        Thread thread;
        int gameSpeed;
       

        static bool isGameOver;
        static Vector dir;

        public int GameSpeed { get => gameSpeed; set => gameSpeed = value; }

        public GameCotrol()
        {
            thread = new Thread(Input);
            map = new Map(new Vector(5, 3), new Vector(20, 20), ConsoleColor.White, "□",true);
            map.CreatMap();
            snake = new Snake(map, ConsoleColor.Yellow);
            isGameOver = false;
            dir = new Vector(0, 0);
            GameSpeed = 400;
            
        }
        public GameCotrol(int sizeX,int sizeY,int speed,bool isRandom)
        {
            sizeX = sizeX < 8 ? 8 : sizeX;
            sizeX = sizeX > 25 ? 25 : sizeX;
            sizeY = sizeY < 8 ? 8 : sizeY;
            sizeY = sizeY > 20 ? 20 : sizeY;

            thread = new Thread(Input);
            map = new Map(new Vector(5, 3), new Vector(sizeX, sizeY), ConsoleColor.White, "□",isRandom);
            map.CreatMap();
            snake = new Snake(map, ConsoleColor.Yellow);
            isGameOver = false;
            dir = new Vector(0, 0);
            GameSpeed = speed;
            
        }

        public void RunGame()
        {
            ClearMainScreen();

            //初始化
            int instancSpeed = 200;

            map.CreatFood(snake);
            map.DrawMap();

            
            thread.Start();
            while (isGameOver==false)
             {
                //绘制
                snake.Draw();
                ShowGrade(snake.grade);
                ShowSpeed(GameSpeed);
                ShowLength(snake.body.Count + 1);


                //停一下
                //Console.ReadKey();
                
                Thread.Sleep(GameSpeed);

                //移动
                snake.Move(dir);

                //判断
                snake.EventJudge(map,GameSpeed);
                if (snake.isDead)
                {
                    isGameOver = true;
                }
                //加速
                if (instancSpeed > 0)
                {
                    GameSpeed--;
                    instancSpeed--;
                }

            }

        }
        static void Input()
        {

            while (isGameOver == false)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.W:
                        if (dir != new Vector(0, 1))
                        {
                            dir = new Vector(0, -1);
                        }
                        break;
                    case ConsoleKey.A:
                        if (dir != new Vector(1, 0))
                        {
                            dir = new Vector(-1, 0);
                        }
                        break;
                    case ConsoleKey.S:
                        if (dir != new Vector(0, -1))
                        {
                            dir = new Vector(0, 1);
                        }
                        break;
                    case ConsoleKey.D:
                        if (dir != new Vector(-1, 0))
                        {
                            dir = new Vector(1, 0);
                        }
                        break;
                    default:
                        break;
                }
            }

        }
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
        static void ShowGrade(int grade)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(20, 1);
            Console.Write("当前分数：{0}",grade);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ShowSpeed(int speed)
        {
            Console.SetCursorPosition(70, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("当前速度：{0}ms/格",speed);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ShowLength(int count)
        {
            Console.SetCursorPosition(70, 12);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("当前长度：{0}", count);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
