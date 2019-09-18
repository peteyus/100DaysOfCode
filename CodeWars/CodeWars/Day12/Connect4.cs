/* https://www.codewars.com/kata/586c0909c1923fdb89002031/train/csharp
 * Introduction
 * We all love to play games especially as children. I have fond memories playing Connect 4 with my brother so decided to create this Kata based on
 * the classic game. Connect 4 is known as several names such as “Four in a Row” and “Captain’s Mistress" but was made popular by Hasbro MB Games
 *
 * Connect 4
 * Task
 * The game consists of a grid (7 columns and 6 rows) and two players that take turns to drop their discs. The pieces fall straight down, occupying
 * the next available space within the column. The objective of the game is to be the first to form a horizontal, vertical, or diagonal line of four
 * of one's own discs.
 * Your task is to create a Class called Connect4 that has a method called play which takes one argument for the column where the player is going to place their disc.
 *
 * Rules
 * If a player successfully has 4 discs horizontally, vertically or diagonally then you should return "Player n wins!” where n is the current player either 1 or 2.
 * If a player attempts to place a disc in a column that is full then you should return ”Column full!” and the next move must be taken by the same player.
 * If the game has been won by a player, any following moves should return ”Game has finished!”.
 * Any other move should return ”Player n has a turn” where n is the current player either 1 or 2.
 * Player 1 starts the game every time and alternates with player 2.
 * The columns are numbered 0-6 left to right.
 */

using System.Runtime.InteropServices;

namespace CodeWars.Day12
{

    using System.Collections.Generic;
    using System.Linq;

    public class Connect4
    {
        private int currentPlayer = 1;
        private readonly List<List<int>> gameBoard;
        private bool gameOver = false;

        public Connect4()
        {
            this.gameBoard = new List<List<int>>(7);
            for (int i = 0; i < 7; i++)
            {
                this.gameBoard.Add(new List<int> {0, 0,0,0,0,0});
            }
        }

        public string play(int col)
        {
            if (gameOver)
            {
                return "Game has finished!";
            }

            var column = this.gameBoard[col];
            int openSlots = column.Count(v => v == 0);
            if (openSlots == 0)
            {
                return "Column full!";
            }

            column[openSlots - 1] = currentPlayer;

            if (HasPlayerWon(currentPlayer, col, openSlots - 1))
            {
                gameOver = true;
                return $"Player {currentPlayer} wins!";
            }

            if (gameBoard.SelectMany(group => group.Select(v => v)).All(v => v > 0))
            {
                gameOver = true;
            }

            string output = $"Player {currentPlayer} has a turn";
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            return output;
        }

        private bool HasPlayerWon(int player, int col, int row)
        {
            int count = 0;
            for (int i = 0; i < this.gameBoard[col].Count && count < 4; i++)
            {
                if (this.gameBoard[col][i] == player)
                {
                    count++;
                    continue;
                }

                count = 0;
            }

            if (count >= 4)
            {
                return true;
            }

            count = 0;

            for (int i = 0; i < this.gameBoard.Count && count < 4; i++)
            {
                if (this.gameBoard[i][row] == player)
                {
                    count++;
                    continue;
                }

                count = 0;
            }

            if (count >= 4)
            {
                return true;
            }

            count = 0;

            for (int i = -6; i < 7; i++)
            {
                if (col + i < 0 || col + i > 6)
                {
                    continue;
                }

                if (row + i < 0 || row + i > 5)
                {
                    continue;
                }

                if (this.gameBoard[col + i][row + i] == player)
                {
                    count++;
                    continue;
                }

                count = 0;
            }


            if (count >= 4)
            {
                return true;
            }

            return false;
        }
    }
}
