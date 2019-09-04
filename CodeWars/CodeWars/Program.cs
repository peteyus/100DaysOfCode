namespace CodeWars
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"06:35 = {CodeWars.Day3.Kata.WhatIsTheTime("05:25")}");
            Console.WriteLine($"11:59 = {CodeWars.Day3.Kata.WhatIsTheTime("12:01")}");
            Console.WriteLine($"11:58 = {CodeWars.Day3.Kata.WhatIsTheTime("12:02")}");
            Console.WriteLine($"12:00 = {CodeWars.Day3.Kata.WhatIsTheTime("12:00")}");
            Console.WriteLine($"02:00 = {CodeWars.Day3.Kata.WhatIsTheTime("10:00")}");
            Debugger.Break();

            Console.WriteLine("This program does nothing.");
        }
    }
}
