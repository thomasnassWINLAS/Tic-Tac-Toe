using TicTacToe;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void GameBoard_ShouldBeInitializedCorrectly()
        {
            // Arrange
            var playerX = new Player("Player X",'X');
            var playerO = new Player("Player O",'O');
            var game = new TicTacToeGame(playerX,playerO);

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

        [Fact]
        public void Player_ShouldBeAbleToMakeMove()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            var moveResult = game.MakeMove(0, 0);
            var board = game.GetBoard();

            // Assert
            Assert.True(moveResult);
            Assert.Equal('X', board[0, 0]);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(4, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 4)]
        public void Game_ShouldNotAllowMoveOutsideBoardBoundaries(int row,int col)
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            var moveResult = game.MakeMove(row, col);

            // Assert
            Assert.False(moveResult);
        }

        [Fact]
        public void Game_ShouldNotAllowMoveInAlreadyOccupiedCell()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            var moveResult = game.MakeMove(0, 0);

            // Assert
            Assert.False(moveResult);
        }

        [Fact]
        public void Game_ShouldDetectWinConditionInARow()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(1, 0);
            game.MakeMove(0, 1);
            game.MakeMove(1, 1);
            game.MakeMove(0, 2);

            // Assert
            Assert.True(game.CheckWin());
            Assert.Equal(playerX, game.CurrentPlayer);
        }


        [Fact]
        public void Game_ShouldDetectWinConditionInAColumn()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(1, 0);
            game.MakeMove(1, 1);
            game.MakeMove(2, 0);

            // Assert
            Assert.True(game.CheckWin());
            Assert.Equal(playerX, game.CurrentPlayer);
        }

        [Fact]
        public void Game_ShouldDetectWinConditionInADiagonal()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(1, 1);
            game.MakeMove(1, 0);
            game.MakeMove(2, 2);

            // Assert
            Assert.True(game.CheckWin());
            Assert.Equal(playerX, game.CurrentPlayer);
        }

        [Fact]
        public void ThreeInARowOffDifferentSymbols_ShouldNotBeAWinCondition()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(0, 2);

            // Assert
            Assert.False(game.CheckWin());
        }

        [Fact]
        public void ThreeInAColumnOffDifferentSymbols_ShouldNotBeAWinCondition()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(1, 0);
            game.MakeMove(2, 0);

            // Assert
            Assert.False(game.CheckWin());
        }

        [Fact]
        public void ThreeInADiagonalOffDifferentSymbols_ShouldNotBeAWinCondition()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0);
            game.MakeMove(1, 1);
            game.MakeMove(2, 2);

            // Assert
            Assert.False(game.CheckWin());
        }

        [Fact]
        public void ShouldDetectDrawCondition()
        {
            // Arrange
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);

            // Act
            game.MakeMove(0, 0); 
            game.MakeMove(0, 1); 
            game.MakeMove(0, 2); 
            game.MakeMove(1, 1); 
            game.MakeMove(1, 0); 
            game.MakeMove(1, 2); 
            game.MakeMove(2, 2); 
            game.MakeMove(2, 0); 
            game.MakeMove(2, 1); 

            // Assert
            Assert.True(game.CheckDraw());
        }
    }
}