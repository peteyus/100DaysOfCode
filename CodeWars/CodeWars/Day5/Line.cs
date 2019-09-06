using System.Collections;
using System.Collections.Generic;

namespace CodeWars.Day5
{
    public class Line
    {
        public static string WhoIsNext(string[] names, long n)
        {
            var queue = new Queue<string>(names);
            string name = string.Empty;
            for (int i = 0; i < n; i++)
            {
                name = queue.Dequeue();
                queue.Enqueue(name);
                queue.Enqueue(name);
            }

            return name;
        }
    }
}
