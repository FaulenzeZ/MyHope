using Hope;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hope
{
    public class Game
    {
        public Player Player;
        private List<Spider> spiders;
        private int axeX = 3;
        private int axeY = 1;
        private bool axeOnMap = true;

        public Game()
        {
            Player = new Player(3, 3);

            spiders = new List<Spider>();
            spiders.Add(new Spider(1, 1));
            spiders.Add(new Spider(1, 3));

        }

        public void draw()
        {
            int sizeY = 10;
            int sizeX = 10;
            int endX = sizeX - 1;
            int endY = sizeY - 1;

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (x == 0 || y == 0 || x == endX || y == endY)
                    {
                        Console.Write("#");
                    }
                    else if (x == Player.X && y == Player.Y)
                    {
                        Console.Write("&");
                    }
                    else if (axeOnMap && x == axeX && y == axeY)
                    {
                        Console.Write("P");
                    }
                    else if (spiders.Exists( s => s.X == x && s.Y == y))
                    {
                        Console.Write("S");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    }
                Console.WriteLine();
            }
            Console.WriteLine(Player.HasAxe ? "Axe - yes" : "Axe - no");
        }

        public void move(int dx, int dy)
        {
            if(!Player.IsAlive) return;

            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (newX <= 0 || newY <= 0 || newY >= 9 || newX >= 9)
            {
                return;
            }
            
            if (newX == axeX && newY == axeY)
            {
                Player.HasAxe = true;
                axeOnMap = false;
                
            }

            Spider? spider = spiders.Find(s => s.X == newX && s.Y == newY);
            if (spider != null)
            {
                if (Player.HasAxe)
                {
                    spiders.Remove(spider);
                }
                else
                {
                    Player.IsAlive = false;
                }
            }

            Player.X = newX;
            Player.Y = newY;
        }
    }
}
