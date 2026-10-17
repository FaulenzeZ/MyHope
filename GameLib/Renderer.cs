
namespace GameLib
{
    public class Renderer
    {
        public void Draw(Game game)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (x == 0 || y == 0 || x == 4 || y == 4)
                        Console.Write("#");
                    else if (x == game.Player.X && y == game.Player.Y)
                        Console.Write("&");
                    else if (game.IsAxeOnMap && x == game.AxeX && y == game.AxeY)
                        Console.Write("A");
                    else if (game.Spiders.Exists(s => s.X == x && s.Y == y))
                        Console.Write("S");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine(game.Player.HasAxe ? "У вас есть топор!" : "Топора нет.");
        }
    }
}
