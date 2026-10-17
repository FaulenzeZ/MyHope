using System;
using System.Collections.Generic;
using System.Text;

namespace Hope
{
    public class Player
    {
        public int X { get; set;}
        public int Y { get; set;}

        public Player (int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Game
    {
        private Player player;

        public Game()
        {
            player = new Player(3, 3);
        }


        public void draw()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (x == 0 || y == 0 || x == 4 || y == 4)
                    {
                        Console.Write("#");
                    }
                    else if (x == player.X && y == player.Y)
                    {
                        Console.Write("&");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }

        public void move(int dx, int dy)
        {
            int newX = player.X + dx;
            int newY = player.Y + dy;

            if (newX > 0 && newY > 0 && newY < 4 && newX < 4)
            {
                player.X = newX;
                player.Y = newY;
            }
        }
    }
}

