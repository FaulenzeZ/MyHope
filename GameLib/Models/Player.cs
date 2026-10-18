namespace GameLib.Models
{
   public class Player
   {
        public int X { get; private set; }
        public int Y { get; private set; }
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
}
