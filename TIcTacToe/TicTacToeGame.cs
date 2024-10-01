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
        public Player CurrentPlayer;

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
            CurrentPlayer = playerX;
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

            _board[row, col] = CurrentPlayer.Symbol;
            CurrentPlayer = CurrentPlayer == _playerX ? _playerO : _playerX;
            return true;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 0] != ' ') ||
                    (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i] && _board[0, i] != ' '))
                {
                    CurrentPlayer = CurrentPlayer == _playerX ? _playerO : _playerX;
                    return true;
                }
            }

            if ((_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != ' ') ||
                (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != ' '))
            {
                CurrentPlayer = CurrentPlayer == _playerX ? _playerO : _playerX;
                return true;
            }

            return false;
        }

        public bool CheckDraw()
        {
            foreach (var cell in _board)
            {
                if (cell == ' ')
                {
                    return false;
                }
            }
            return !CheckWin();
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----");
            }
            Console.WriteLine();
        }
    }
}
