using GameLib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameLib
{
    public class Game
    {
        public Player Player { get; private set; }
        public List<Spider> Spiders {  get; private set; }
        public Axe Axe { get; private set; }
        public Wall Wall { get; private set; }
        private Random _random = new Random();

        public Game()
        {
            Player = new Player(1, 1);
            Wall = new Wall(20, 10, 19, 9);
            Spiders = new List<Spider>();

            int X = _random.Next(1, 19);
            int Y = _random.Next(1, 9);
            Axe = new Axe(X, Y);

            int sX1 = _random.Next(1, 19);
            int sY1 = _random.Next(1, 9);
            Spiders.Add(new Spider(sX1, sY1));

            int sX2 = _random.Next(1, 19);
            int sY2 = _random.Next(1, 9);
            Spiders.Add(new Spider(sX2, sY2));
        }

        public void move(int dx, int dy)
        {
            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (IsWall(newX, newY)) return;
            IsAxe(newX, newY);
            Spider_Find(newX, newY);
            if (!Player.IsAlive) return;

            Player.X = newX;
            Player.Y = newY;
        }

        public bool IsWall(int newX, int newY)
        {
            return (newX <= 0 || newY <= 0 || newY >= Wall.EndY || newX >= Wall.EndX) ;
        }

        public void IsAxe(int newX, int newY) 
        {
            if (newX == Axe.X && newY == Axe.Y)
            {
                Player.HasAxe = true;
                Axe.IsAxeOnMap = false;

            }
        }

        public void Spider_Find(int newX, int newY) 
        {
            Spider? spider = Spiders.Find(s => s.X == newX && s.Y == newY);
            if (spider != null)
            {
                if (Player.HasAxe)
                {
                    Spiders.Remove(spider);

                    if (Spiders.Count == 0)
                    {
                        Player.IsWin = true;
                    }
                }
                else
                {
                    Player.IsAlive = false;
                }
            }
        }

        public void MoveSpiders(int dx, int dy)
        {

        }
    }
}
