using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameLib
{
    public class Game
    {
        public Player Player { get; private set; }
        public List<Spider> Spiders {  get; private set; }
        public int AxeX {  get; private set; }
        public int AxeY { get; private set; }
        public bool IsAxeOnMap {  get; private set; }

        public Game()
        {
            Player = new Player(3, 3);

            Spiders = new List<Spider>();
            Spiders.Add(new Spider(1, 1));
            Spiders.Add(new Spider(2, 3));

            AxeX = 3;
            AxeY = 1;
            IsAxeOnMap = true;
        }

        public void move(int dx, int dy)
        {
            if(!Player.IsAlive) return;

            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (newX <= 0 || newY <= 0 || newY >= 4 || newX >= 4)
            {
                return;
            }
            
            if (newX == AxeX && newY == AxeY)
            {
                Player.HasAxe = true;
                IsAxeOnMap = false;
                
            }

            Spider? spider = Spiders.Find(s => s.X == newX && s.Y == newY);
            if (spider != null)
            {
                if (Player.HasAxe)
                {
                    Spiders.Remove(spider);
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
