namespace CodeWars
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            int n = 1;

            watch.Start();
            string result = Day5.Line.WhoIsNext(names, n);
            watch.Stop();
            Console.WriteLine($"Got '{result}' in {watch.ElapsedMilliseconds}");
            watch.Reset();

            names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            n = 6;
            watch.Start();
            result = Day5.Line.WhoIsNext(names, n);
            watch.Stop();
            Console.WriteLine($"Got '{result}' in {watch.ElapsedMilliseconds}");
            watch.Reset();

            names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            n = 1000000000;
            watch.Start();
            result = Day5.Line.WhoIsNext(names, n);
            watch.Stop();
            Console.WriteLine($"Got '{result}' in {watch.ElapsedMilliseconds}");
            watch.Reset();

            names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            n = 1000000000;
            watch.Start();
            result = Day5.Line.WhoIsNextPretty(names, n);
            watch.Stop();
            Console.WriteLine($"Got '{result}' in {watch.ElapsedMilliseconds}");
            watch.Reset();

            Debugger.Break();

            Console.WriteLine("This program does nothing.");
        }
    }
}
