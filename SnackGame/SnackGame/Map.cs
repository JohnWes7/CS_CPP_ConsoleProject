using System;
using System.Collections.Generic;
using System.Text;

namespace SnackGame
{
    class Map
    {
        public Vector position;
        public Vector size;
        ConsoleColor color;
        string icon;
        public GameObject food;
        public GameObject toxicFood;
        bool isRandom;

        public List<GameObject> map;

        public Map(Vector position, Vector size, ConsoleColor color, string icon, bool isRandom)
        {
            this.position = position;
            this.size = size;
            this.color = color;
            this.icon = icon;
            this.isRandom = isRandom;

            map = new List<GameObject>();
            CreatMap();
        }

        public void CreatMap()
        {
            GameObject start = new GameObject(this.position, new Vector(1, 1), ConsoleColor.White, icon);
            map.Add(start);

            //左边
            for (int i = 0; i < this.size.y - 1; i++)
            {
                map.Add(new GameObject(map[map.Count - 1].position.x, map[map.Count - 1].position.y + 1, 1, 1, color, this.icon));
            }
            //下边
            for (int i = 0; i < this.size.x - 1; i++)
            {
                map.Add(new GameObject(map[map.Count - 1].position.x + 1, map[map.Count - 1].position.y, 1, 1, color, this.icon));
            }
            //右边
            for (int i = 0; i < size.y - 1; i++)
            {
                map.Add(new GameObject(map[map.Count - 1].position.x, map[map.Count - 1].position.y - 1, 1, 1, color, this.icon));
            }
            //上边
            for (int i = 0; i < this.size.x - 2; i++)
            {
                map.Add(new GameObject(map[map.Count - 1].position.x - 1, map[map.Count - 1].position.y, 1, 1, color, this.icon));
            }

            if (isRandom)
            {
                int i = size.x / 2;
                while (i > 0)
                {
                    //生成随机障碍
                    bool isRight = true;
                    Random r = new Random();
                    Vector newposition = new Vector(r.Next(position.x + 1, position.x + size.x - 1), r.Next(position.y + 1, position.y + size.y - 1));
                    for (int j = 0; j < map.Count; j++)//判断重复
                    {
                        if (map[j].position == newposition)
                        {
                            isRight = false;
                        }
                    }
                    if (isRight)
                    {
                        map.Add(new GameObject(newposition, new Vector(1, 1), this.color, this.icon));
                        i--;
                    }

                }
            }
        }
        public void DrawMap()
        {
            for (int i = 0; i < map.Count; i++)
            {
                map[i].Draw();
            }
        }
        public void CreatFood(Snake snake)
        {
            Random r = new Random();

            int maxX = position.x + size.x - 2;
            int minX = position.x + 1;
            int maxY = position.y + size.y - 2;
            int minY = position.y + 1;
            
            //food = new GameObject(r.Next(minX, maxX + 1), r.Next(minY, maxY + 1), 1, 1, ConsoleColor.Red, "●");
            while (true)
            {
                Vector nposition = new Vector(r.Next(minX, maxX + 1), r.Next(minY, maxY + 1));
                bool isRight = true;
                //判断会不会和墙重合
                for (int i = 0; i < map.Count; i++)
                {
                    if (map[i].position == nposition)
                    {
                        isRight = false;
                    }
                }
                //判断会不会和蛇身重合
                for (int i = 0; i < snake.body.Count; i++)
                {
                    if (snake.body[i].position == nposition)
                    {
                        isRight = false;
                    }
                }
                //判断会不会和蛇头重合
                if (snake.head.position == nposition)
                {
                    isRight = false;
                }
                //如果都不重合就赋值并且跳出循环
                if (isRight)
                {
                    food = new GameObject(nposition, new Vector(1, 1), ConsoleColor.Red, "●");
                    break;
                }

            }

            //有50%的几率生成毒苹果
            int isToxic = r.Next(1, 101);
            if (isToxic<=50)
            {
                
                //生成毒苹果
                while (true)
                {
                    Vector nposition = new Vector(r.Next(minX, maxX + 1), r.Next(minY, maxY + 1));
                    bool isRight = true;
                    //判断会不会和墙重合
                    for (int i = 0; i < map.Count; i++)
                    {
                        if (map[i].position == nposition)
                        {
                            isRight = false;
                        }
                    }
                    //判断会不会和蛇身重合
                    for (int i = 0; i < snake.body.Count; i++)
                    {
                        if (snake.body[i].position == nposition)
                        {
                            isRight = false;
                        }
                    }
                    //判断会不会和蛇头重合
                    if (snake.head.position == nposition)
                    {
                        isRight = false;
                    }
                    //判断会不会和食物重合
                    if (nposition == food.position)
                    {
                        isRight = false;
                    }
                    //如果都不重合就赋值并且跳出循环
                    if (isRight)
                    {
                        toxicFood = new GameObject(nposition, new Vector(1, 1), ConsoleColor.Green, "●");
                        toxicFood.Draw();
                        break;
                    }

                }
            }
            else
            {
                toxicFood = null;
            }

            food.Draw();
        }




    }
}
