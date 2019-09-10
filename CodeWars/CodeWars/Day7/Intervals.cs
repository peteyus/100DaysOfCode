namespace CodeWars.Day7
{
    using System;
    using System.Linq;
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            var orderedIntervals = intervals.OrderBy(x => x.Item1).ToArray();
            int sum = 0;
            int count = orderedIntervals.Count();

            for (int i = 0; i < count; i++)
            {
                int start = orderedIntervals[i].Item1;
                int end = orderedIntervals[i].Item2;
                if (i < count - 1)
                {
                    while (i < count - 1 && orderedIntervals[i + 1].Item1 < end)
                    {
                        i++;
                        end = Math.Max(orderedIntervals[i].Item2, end);
                    }
                }
                
                sum += end - start;
            }

            return sum;
        }
    }
}
