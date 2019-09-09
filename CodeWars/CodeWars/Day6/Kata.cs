namespace CodeWars.Day6
{
    using System.Linq;

    public class Kata
    {
        public static int[] MoveZeroes(int[] arr)
        {
            int zeroCount = arr.Count(i => i == 0);
            var result = arr.Where(i => i != 0).ToList();

            for (int i = 0; i < zeroCount; i++)
            {
                result.Add(0);
            }

            return result.ToArray();
        }
    }
}
