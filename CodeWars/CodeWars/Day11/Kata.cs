namespace CodeWars.Day11
{
    using System;

    public class Kata
    {
        public static int Triangular(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            return (n * (n + 1)) / 2;
        }
    }
}
