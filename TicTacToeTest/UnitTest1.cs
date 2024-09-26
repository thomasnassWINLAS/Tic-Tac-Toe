using TicTacToe;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void GameBoard_ShouldBeInitializedCorrectly()
        {
            // Arrange
            var game = new TicTacToeGame();

            // Act
            var board = game.GetBoard();

            // Assert
            Assert.Equal(3, board.GetLength(0));
            Assert.Equal(3, board.GetLength(1));
            foreach (var cell in board)
            {
                Assert.Equal(' ', cell);
            }
        }
    }
}