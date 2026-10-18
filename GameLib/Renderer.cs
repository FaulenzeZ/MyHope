namespace GameLib
{
    public class Renderer
    {
        public void Draw(Game game)
        {
            for (int y = 0; y < game.Wall.StartY; y++)
            {
                for (int x = 0; x < game.Wall.StartX; x++)
                {
                    if (x == 0 || y == 0 || x == game.Wall.EndX || y == game.Wall.EndY)
                        Console.Write("#");
                    else if (x == game.Player.X && y == game.Player.Y)
                        Console.Write("&");
                    else if (game.Axe.IsAxeOnMap && x == game.Axe.X && y == game.Axe.Y)
                        Console.Write("A");
                    else if (game.Spiders.Exists(s => s.X == x && s.Y == y))
                        Console.Write("S");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine(game.Player.HasAxe ? "топор: V" : "топор: X");
        }
    }
}
