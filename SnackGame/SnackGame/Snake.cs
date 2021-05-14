using System;
using System.Collections.Generic;
using System.Text;

namespace SnackGame
{
    class Snake
    {
        public GameObject head;
        public List<GameObject> body;
        public bool isDead;
        ConsoleColor color;
        public int grade;

        public Snake(Map map, ConsoleColor color)
        {
            Random random = new Random();
            Vector nposition;

            grade = 0;
            this.color = color;
            isDead = false;
            body = new List<GameObject>();
            //生成蛇头
            while (true)
            {
                //避免蛇头刷在障碍物上
                bool isRight = true;
                nposition = new Vector(random.Next(map.position.x + 1, map.position.x + map.size.x - 1), random.Next(map.position.y + 1, map.position.y + map.size.y - 1));
                for (int i = 0; i < map.map.Count; i++)
                {
                    if (map.map[i].position==nposition)
                    {
                        isRight = false;
                    }
                }
                if (isRight)
                {
                    head = new GameObject(nposition, new Vector(1, 1), this.color, "◇");
                    break;
                }

            }

        }

        public void EventJudge(Map map,int speed)
        {
            //判断撞墙
            for (int i = 0; i < map.map.Count; i++)
            {
                if (map.map[i].position == head.position)
                {
                    isDead = true;
                }
            }
            //判断撞到绳子
            for (int i = 0; i < body.Count; i++)
            {
                if (head.position==body[i].position)
                {
                    isDead = true;
                }
            }
            //判断吃到食物
            if (head.position == map.food.position)
            {
                //把两个食物都擦掉
                if (map.toxicFood!=null)
                {
                    map.toxicFood.Remove();
                }
                map.food.Remove();

                //生成食物
                map.CreatFood(this);
                //加分
                grade +=800-speed ;
                //长身体
                GrowBody();
            }
            //判断迟到坏食物
            if (map.toxicFood!=null &&head.position==map.toxicFood.position)
            {
                isDead = true;
            }
        }
        public void Move(Vector dir)
        {
            //获得蛇头的上一个位置
            Vector newposition = head.position;
            Vector oldposition = head.position;
            head.Move(dir);
            
            //蛇身移动
            for (int i = 0; i < body.Count; i++)
            {
                body[i].Remove();//变化位置之前擦除
                oldposition = body[i].position;//记录身子之前的位置
                body[i].position = newposition;//将蛇头位置或者上一个的位置给下一个
                newposition = oldposition;//把newposition变成应该传给下一个的位置
            }
        }
        public void Draw()
        {
            //蛇头绘制
            head.Draw();
            //蛇身绘制
            for (int i = 0; i < body.Count; i++)
            {
                body[i].Draw();
            }
        }
        public void Remove()
        {
            head.Remove();
            for (int i = 0; i < body.Count; i++)
            {
                body[i].Remove();
            }
        }
        public void GrowBody()
        {
            //长身体
            if (body.Count == 0)//如果没有身体
            {
                GameObject newbody = new GameObject(head.position, head.size, head.color, head.icon);
                body.Add(newbody);
            }
            else//如果有身体
            {
                GameObject lastbody = body[body.Count - 1];
                GameObject newbody = new GameObject(lastbody.position, lastbody.size, lastbody.color, lastbody.icon);
                body.Add(newbody);
            }



        }






    }

}
