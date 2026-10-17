using GameLib;

namespace Hope
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();
            Renderer renderer = new Renderer();

            
            while (game.Player.IsAlive)
            {
                Console.Clear();
                renderer.Draw(game);

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.W) game.move(0, -1);
                else if (key.Key == ConsoleKey.S) game.move(0, 1);
                else if (key.Key == ConsoleKey.D) game.move(1, 0);
                else if (key.Key == ConsoleKey.A) game.move(-1, 0);
                else if (key.Key == ConsoleKey.Q) break;
                
            }

            Console.Clear();
            renderer.Draw(game);
            Console.WriteLine("Game over");
            Console.ReadKey(true);
        }
    }
}