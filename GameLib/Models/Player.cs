namespace GameLib.Models
{
   public class Player : Entity
   {
        public bool HasAxe { get; set; }
        public bool IsAlive { get; set; }
        public bool IsWin {  get; set; }

        public Player(int x, int y) : base(x,y)
        {
            HasAxe = false;
            IsAlive = true;
            IsWin = false;
        }
    }
}
