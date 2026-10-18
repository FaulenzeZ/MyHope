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

            for (int i = 0; i < 3; i++) SpawnSpider();
        }

        public void move(int dx, int dy)
        {
            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (IsWall(newX, newY)) return;

            Player.X = newX;
            Player.Y = newY;

            IsAxe(newX, newY);
            Spider_Find(newX, newY);

            if (!Player.IsAlive) return;
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
        
        private void SpawnSpider()
        {
            int x, y;
            bool occupied;

            do
            {
                x = _random.Next(1, 19);
                y = _random.Next(1, 9);

                occupied = (x == Player.X && y == Player.Y) 
                        || (x == Axe.X && y == Axe.Y) 
                        || Spiders.Exists(s => s.X == x && s.Y == y);
            } while (occupied);

            Spiders.Add(new Spider(x, y));
        }
    }
}
