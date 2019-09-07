using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeWars.Day5
{
    public class Line
    {
        public static string WhoIsNext(string[] names, long n)
        {
            int l = names.Length;
            long previousIteration = 0;
            long totalIteration = l;
            int i = 1;

            while (n > totalIteration)
            {
                previousIteration = totalIteration;
                totalIteration += l * (long)Math.Pow(2, i);
                i++;
            }

            n -= previousIteration;
            int placeInLine = (int)(n / Math.Pow(2, i));
            return names[placeInLine];
        }

        public static string WhoIsNextPretty(string[] names, long n)
        {
            var l = names.Length;
            return n <= l ? names[n - 1] : WhoIsNext(names, (n - l + 1) / 2);
        }
    }
}
