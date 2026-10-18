using GameLib;

namespace GameLib.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Move_IntoWall_DoesNotMove()
        {
            Game game = new Game();

            game.Player.X = 1;
            game.Player.Y = 1;
            int newX = game.Player.X;
            int newY = game.Player.Y;

            game.move(0, -1);

            Assert.That(game.Player.X, Is.EqualTo(newX));
            Assert.That(game.Player.Y, Is.EqualTo(newY));
        }

        [Test]
        public void Move_OnAxe_PickUp_Axe()
        {
            Game game = new Game();
            game.Player.X = 3;
            game.Player.Y = 2;
            game.Player.HasAxe = false;
           
            game.Axe.X = 2;
            game.Axe.X = 2;


            game.move(-1, 0);

            Assert.That(game.Player.HasAxe, Is.True);
        }

        [Test]
        public void Move_OnSpiderWithoutAxe()
        {
            Game game = new Game();
            game.Player.X = 1;
            game.Player.Y = 2;
            game.Player.HasAxe = false;

            game.move(0, -1);

            Assert.That(game.Player.HasAxe, Is.False);
        }

        [Test]
        public void Move_OnSpiderWithAxe_KillSpider()
        {
            Game game = new Game();

            game.Player.X = 5;
            game.Player.Y = 5;
            game.Player.HasAxe = true;

            game.Spiders.Clear();
            game.Spiders.Add(new Models.Spider(5, 4));
            game.Spiders.Add(new Models.Spider(9, 4));

            int spiders_count = game.Spiders.Count;

            game.move(0, -1);
            
            Assert.That(game.Spiders.Count, Is.EqualTo(spiders_count -1));
        }

        [Test]
        public void Move_OnSpiderWithoutAxe_AndDie()
        {
            Game game = new Game();
            game.Player.X = 1;
            game.Player.Y = 2;
            game.Player.HasAxe = false;

            game.Spiders.Clear();
            game.Spiders.Add(new Models.Spider(1, 1));
            game.Spiders.Exists(s => s.X == 1 && s.Y == 1);

            game.move(0, -1);

            Assert.That(game.Player.IsAlive, Is.False);
        }

        [Test]
        public void Spiders_Counts_IsNull_WIN()
        {
            Game game = new Game();

            game.Player.X = 1;
            game.Player.Y = 2;
            game.Player.HasAxe = true;

            game.Spiders.Clear();
            game.Spiders.Add(new Models.Spider(1, 1));

            game.move(0, -1);

            Assert.That(game.Player.IsAlive, Is.False);
        }
    }
}
