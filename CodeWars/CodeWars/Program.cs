namespace CodeWars
{
    using System;
    using System.Diagnostics;
    using Interval = System.ValueTuple<int, int>;

    class Program
    {
        static void Main(string[] args)
        {
            // var watch = new Stopwatch();
            var result = Day7.Intervals.SumIntervals(new Interval[] { });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (-1, 4), (-5, -3) });
            Console.WriteLine($"7={result}");

            result = Day7.Intervals.SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) });
            Console.WriteLine(result);

            result = Day7.Intervals.SumIntervals(new Interval[] { (-3721, 8920), (-8537, 1857), (-9055, 5016), (-450, 4012), (1217, 1999), (-7083, 3752), (448, 4547), (-3492, 2002), (-1482, 2046), (-719, 6163), (-8913, 9949), (-3994, 9746), (1599, 9079), (-9678, 7409), (-6057, -857), (-2137, 357), (-6829, 6951), (-5348, 2800), (-9494, -9247), (-546, -136), (-3376, 962), (-9958, -7421), (-9892, 3225), (-5324, 7148) });
            Console.WriteLine($"19907={result}");

            /*
             * [(-3721, 8920)], [(-8537, 1857)], [(-9055, 5016)], [(-450, 4012)], [(1217, 1999)], [(-7083, 3752)], [(448, 4547)], [(-3492, 2002)], [(-1482, 2046)], [(-719, 6163)], [(-8913, 9949)], [(-3994, 9746)], [(1599, 9079)], [(-9678, 7409)], [(-6057, -857)], [(-2137, 357)], [(-6829, 6951)], [(-5348, 2800)], [(-9494, -9247)], [(-546, -136)], [(-3376, 962)], [(-9958, -7421)], [(-9892, 3225)], [(-5324, 7148)]
  Expected: 19907
  But was:  35501 */

            Console.WriteLine("This program does nothing.");
        }
    }
}
