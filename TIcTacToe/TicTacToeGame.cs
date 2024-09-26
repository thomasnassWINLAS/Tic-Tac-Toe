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
        private char[,] _board;
        private Player _playerX;
        private Player _playerO;

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
        }


        public char[,] GetBoard()
        {
            return _board;
        }
    }
}
