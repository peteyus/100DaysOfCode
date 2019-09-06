using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeWars.Day5
{
    public class Line
    {
        public static string WhoIsNext(string[] names, long n)
        {
            //var queue = new Queue<string>(names);
            //string name = string.Empty;
            //for (int i = 0; i < n; i++)
            //{
            //    name = queue.Dequeue();
            //    queue.Enqueue(name);
            //    queue.Enqueue(name);
            //}

            int nameCount = names.Length;
            long someNumber = n / nameCount;
            long expanded = (someNumber + 1) / 2;
            long iteration = (long)Math.Floor(Math.Log(expanded, 2));
            long eliminatedPositions = EliminateRecords(nameCount, iteration);
            long newPosition = n - eliminatedPositions;
            long person = iteration > 0 ? (long)Math.Floor(newPosition / Math.Pow(nameCount, iteration)) : (long)Math.Floor(newPosition / (double)nameCount);
            person += newPosition % nameCount;
            return names[person - 1];
        }

        private static long EliminateRecords(int nameCount, long iteration)
        {
            long result = 0;
            for (long i = 0; i < iteration; i++)
            {
                result += (nameCount * i) * (long)Math.Pow(2, i);
            }

            return result;
        }
    }
}
