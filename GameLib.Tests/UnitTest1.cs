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

            game.Player.X = 5;
            game.Player.Y = 1;
            int startX = game.Player.X;
            int startY = game.Player.Y;

            game.move(0, -1);

            Assert.That(game.Player.X, Is.EqualTo(startX));
            Assert.That(game.Player.Y, Is.EqualTo(startY));
        }

        [Test]
        public void Move_OnAxe_PickUp_Axe()
        {
            Game game = new Game();
            game.Player.X = 3;
            game.Player.Y = 2;
            game.Player.HasAxe = false;

            game.move(0, -1);

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
        public void Move_OnSpiderWithAxe_KillsSpider()
        {
            Game game = new Game();
            game.Player.X = 1;
            game.Player.Y = 2;
            game.Player.HasAxe = true;

            int spiderBefore = game.Spiders.Count;

            game.move(0, -1);

            Assert.That(game.Spiders.Count, Is.EqualTo(spiderBefore - 1));
            Assert.That(game.Player.HasAxe, Is.True);
        }

        [Test]
        public void Move_OnSpiderWithoutAxe_AndDie()
        {
            Game game = new Game();
            game.Player.X = 1;
            game.Player.Y = 2;
            game.Player.HasAxe = false;

            game.move(0, -1);

            Assert.That(game.Player.IsAlive, Is.False);
        }

    }
}
