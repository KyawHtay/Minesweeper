using NUnit.Framework;

namespace Minesweeper.Tests
{
    public class MinesweeperGameTests
    {
        [Test]
        public void TestPlaceMines()
        {
            MinesweeperGame game = new MinesweeperGame();
            game.PlaceMines();

            int numMines = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (game.board[i, j] == 'X')
                    {
                        numMines++;
                    }
                }
            }

            Assert.AreEqual(3, numMines);
        }

        [Test]
        public void TestMovePlayerHitMine()
        {
            MinesweeperGame game = new MinesweeperGame();
            game.PlaceMines();
            game.playerPos = new int[] { 1, 1 };

            bool continueGame = game.MovePlayer("right");

            Assert.IsTrue(continueGame);
            Assert.AreEqual(2, game.lives);
        }

        [Test]
        public void TestMovePlayerReachOtherSide()
        {
            MinesweeperGame game = new MinesweeperGame();
            game.PlaceMines();
            game.playerPos = new int[] { 0, 0 };

            bool continueGame = game.MovePlayer("down");

            Assert.IsTrue(continueGame);
            Assert.AreEqual(1, game.moves);
        }
    }
}
