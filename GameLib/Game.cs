using GameLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameLib
{
    public class Game
    {
        public Player Player { get; private set; }
        public List<Spider> Spiders {  get; set; }
        public Axe Axe { get; private set; }
        public Wall Wall { get; private set; }

        private Random _random = new Random();
        public Game()
        {
            Player = new Player(3, 3);

            int X = _random.Next(1, 19);
            int Y = _random.Next(1, 9);

            int sX1 = _random.Next(1, 19);
            int sY1 = _random.Next(1, 9);

            int sX2 = _random.Next(1, 19);
            int sY2 = _random.Next(1, 9);

            Wall = new Wall(20, 10, 19, 9);
            Spiders = new List<Spider>();
            Axe = new Axe(X, Y, true);

            Spiders.Add(new Spider(sX1, sY1));
            Spiders.Add(new Spider(sX2, sY2));

        }

        public void move(int dx, int dy)
        {
            if(!Player.IsAlive) return;

            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (newX <= 0 || newY <= 0 || newY >= Wall.EndY || newX >= Wall.EndX)
            {
                return;
            }



            if (newX == Axe.X && newY == Axe.Y)
            {
                Player.HasAxe = true;
                Axe.IsAxeOnMap = false;
                
            }

            Spider? spider = Spiders.Find(s => s.X == newX && s.Y == newY);
            if (spider != null)
            {
                if (Player.HasAxe)
                {
                    Spiders.Remove(spider);

                    if (Spiders.Count == 0)
                    {
                        Player.IsAlive = false;
                    }
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
