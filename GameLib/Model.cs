namespace GameLib
{
   public class Player
   {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasAxe { get; set; }
        public bool IsAlive { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            HasAxe = false;
            IsAlive = true;
        }
    }

    public class Spider
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Spider(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Wall
    {
        public int StartX { get; private set;}
        public int StartY { get; private set;}
        public int EndX { get; set;}
        public int EndY { get; set;}
        public Wall (int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
    }

    public class Axe
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAxeOnMap { get; set; }
        public Axe(int x, int y, bool isAxeOnMap)
        {
            X = x;
            Y = y;
            IsAxeOnMap = isAxeOnMap;
        }
    }
}
