using System;
using System.Collections.Generic;
using System.Text;

namespace 继承
{
    class GameObject
    {
        public Vector position;
        Vector size;
        ConsoleColor color;

        public GameObject(int x,int y,int width,int heigth,ConsoleColor color)
        {
            position.x = x;
            position.y = y;

            size.x = width;
            size.y = heigth;

            this.color = color;

        }
        
        public void Draw()
        {
            
            Console.ForegroundColor = color;
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    Console.SetCursorPosition((position.x + j) * 2, position.y + i);
                    Console.Write("■");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Remove()
        {
            Console.SetCursorPosition(position.x * 2, position.y);
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    Console.SetCursorPosition((position.x + j) * 2, position.y + i);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        public void Move(int x,int y)
        {
            Remove();
            position.x += x;
            position.y += y;

            if (position.x<0)
            {
                position.x = 0;
            }
            else if (position.x>50-size.x)
            {
                position.x = 50 - size.x;
            }
            position.y = position.y < 0 ? 0 : position.y;
            position.y = position.y > 50 - size.y ? 50 - size.y : position.y;
            
            Draw();
        }
            
    }

    struct Vector
    {
       public int x;
       public int y;

    }
}
