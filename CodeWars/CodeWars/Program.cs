namespace CodeWars
{
    using System;
    using Day8;

    class Program
    {
        static void Main(string[] args)
        {
            var result = Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1));
            result = Kata.TreeByLevels(null);
            Console.WriteLine("This program does nothing.");
        }
    }
}
