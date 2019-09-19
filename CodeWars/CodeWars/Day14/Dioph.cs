/*
 * In mathematics, a Diophantine equation is a polynomial equation, usually with two or more unknowns, such that only the integer solutions are sought or studied.
 *
 * In this kata we want to find all integers x, y (x >= 0, y >= 0) solutions of a diophantine equation of the form:
 * x2 - 4 * y2 = n
 * (where the unknowns are x and y, and n is a given positive number) in decreasing order of the positive xi.
 * If there is no solution return [] or "[]" or "". (See "RUN SAMPLE TESTS" for examples of returns).
 *
 * Examples:
 * solEquaStr(90005) --> "[[45003, 22501], [9003, 4499], [981, 467], [309, 37]]"
 * solEquaStr(90002) --> "[]"
 * Hint:
 * x2 - 4 * y2 = (x - 2*y) * (x + 2*y)
 */
namespace CodeWars.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Dioph
    {
        public static string solEquaStr(long n)
        {
            List<(int, int)> validPairs = new List<(int, int)>();

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if ((long) Math.Pow(x, 2) - (4 * (long) Math.Pow(y, 2)) == n)
                    {
                        validPairs.Add((x, y));
                    }
                }
            }

            string pairs = $"{string.Join(", ", validPairs.Select(pair => $"[{pair.Item1}, {pair.Item2}]"))}";
            return $"[{pairs}]";
        }
    }
}
