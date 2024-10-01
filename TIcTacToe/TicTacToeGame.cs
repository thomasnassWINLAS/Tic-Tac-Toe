using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly char[,] _board;
        private readonly Player _playerX;
        private readonly Player _playerO;
        private Player _currentPlayer;

        public TicTacToeGame(Player playerX, Player playerO)
        {
            _board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = ' ';
                }
            }
            _playerX = playerX;
            _playerO = playerO;
            _currentPlayer = playerX;
        }


        public char[,] GetBoard()
        {
            return _board;
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || _board[row, col] != ' ')
            {
                return false;
            }

            _board[row, col] = _currentPlayer.Symbol;
            _currentPlayer = _currentPlayer == _playerX ? _playerO : _playerX;
            return true;
        }

        public bool CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if ((_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 0] != ' ') ||
                    (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i] && _board[0, i] != ' '))
                {
                    return true;
                }
            }

            // Check diagonals
            if ((_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != ' ') ||
                (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != ' '))
            {
                return true;
            }

            return false;
        }
    }
}
