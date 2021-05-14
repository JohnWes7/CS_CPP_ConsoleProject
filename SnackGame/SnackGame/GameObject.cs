using System;
using System.Collections.Generic;
using System.Text;

namespace SnackGame
{
    class GameObject
    {
        public Vector position;
        public Vector size;
        public ConsoleColor color;
        public string icon;

        public GameObject(int x, int y, int width, int heigth, ConsoleColor color,string icon)
        {
            position.x = x;
            position.y = y;

            size.x = width;
            size.y = heigth;

            this.color = color;
            this.icon = icon;

        }
        public GameObject(Vector position,Vector size ,ConsoleColor color,string icon)
        {
            this.position = position;
            this.size = size;
            this.color = color;
            this.icon = icon;
        }

        public void Draw()
        {

            Console.ForegroundColor = color;
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    Console.SetCursorPosition((position.x + j) * 2, position.y + i);
                    Console.Write(icon);
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
        public void Move(int x, int y)
        {
            Remove();
            position.x += x;
            position.y += y;

            if (position.x < 0)
            {
                position.x = 0;
            }
            else if (position.x > 50 - size.x)
            {
                position.x = 50 - size.x;
            }
            position.y = position.y < 0 ? 0 : position.y;
            position.y = position.y > 50 - size.y ? 50 - size.y : position.y;

            Draw();
        }
        public void Move(Vector dir)
        {
            Move(dir.x, dir.y);
        }
        

    }

    struct Vector
    {
        public int x;
        public int y;

        public Vector(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static bool operator == (Vector a,Vector b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Vector a,Vector b)
        {
            return !(a == b);
        }

    }
}
