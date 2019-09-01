using CodeWars.Day2;
using System;
using System.Diagnostics;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = { { 3, 0, 1 },
                             { 3, 0, 1 },
                             { 0, 2, 1 },
                             { 0, 2, 0 } };
            int[,] attacks = { { 2, 1 }, { 2, 2 }, { 3, 2 }, { 3, 3 } };
            var result = Kata.damagedOrSunk(board, attacks);

            Debugger.Break();

            Console.WriteLine("This program does nothing.");
        }
    }
}
