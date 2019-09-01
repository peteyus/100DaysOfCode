namespace CodeWars.Day2
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    class Kata
    {
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            var ones = new Collection<int>();
            var twos = new Collection<int>();
            var threes = new Collection<int>();

            // initialize board
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    switch (board[y, x])
                    {
                        case 1:
                            ones.Add(1);
                            break;
                        case 2:
                            twos.Add(2);
                            break;
                        case 3:
                            threes.Add(3);
                            break;
                    }
                }
            }

            bool hasOnes = ones.Count > 0;
            bool hasTwos = twos.Count > 0;
            bool hasThrees = threes.Count > 0;

            bool hitOne = false;
            bool hitTwo = false;
            bool hitThree = false;

            int topRow = board.GetLength(0);

            for (int y = 0; y < attacks.GetLength(0); y++)
            {
                int targetX = attacks[y, 0] - 1;
                int targetY = topRow - attacks[y, 1];

                switch(board[targetY, targetX])
                {
                    case 1:
                        ones.Remove(ones.First());
                        hitOne = true;
                        break;
                    case 2:
                        twos.Remove(twos.First());
                        hitTwo = true;
                        break;
                    case 3:
                        threes.Remove(threes.First());
                        hitThree = true;
                        break;
                }
            }

            var result = new Dictionary<string, double>();
            double sunk = 0;
            sunk += (ones.Count == 0 && hasOnes) ? 1 : 0;
            sunk += (twos.Count == 0 && hasTwos) ? 1 : 0;
            sunk += (threes.Count == 0 && hasThrees) ? 1 : 0;

            double hit = 0;
            hit += (hitOne && ones.Count > 0) ? 1 : 0;
            hit += (hitTwo && twos.Count > 0) ? 1 : 0;
            hit += (hitThree && threes.Count > 0) ? 1 : 0;

            double undamaged = 0;
            undamaged += (!hitOne && hasOnes) ? 1 : 0;
            undamaged += (!hitTwo && hasTwos) ? 1 : 0;
            undamaged += (!hitThree && hasThrees) ? 1 : 0;

            result.Add("sunk", sunk);
            result.Add("damaged", hit);
            result.Add("notTouched", undamaged);
            result.Add("points", sunk + (0.5d * hit) - undamaged);

            return result;
        }
    }
}
