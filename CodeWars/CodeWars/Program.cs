namespace CodeWars
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            int n = 1;
            Console.WriteLine(Day5.Line.WhoIsNext(names, n));


            names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            n = 6;
            Console.WriteLine(Day5.Line.WhoIsNext(names, n));


            Debugger.Break();

            Console.WriteLine("This program does nothing.");
        }
    }
}
