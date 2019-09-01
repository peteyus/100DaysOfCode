using System;
using System.Diagnostics;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };
            string[] result = DirectionsReduction.DirReduction.dirReduc(a);

            Debugger.Break();

            a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            result = DirectionsReduction.DirReduction.dirReduc(a);

            Debugger.Break();

            Console.WriteLine("This program does nothing.");
        }
    }
}
