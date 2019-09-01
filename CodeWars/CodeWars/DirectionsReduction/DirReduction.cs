namespace CodeWars.DirectionsReduction
{
    using System.Collections.Generic;
    using System.Linq;

    public class DirReduction
    {
        static Direction North = new Direction { Value = "NORTH" };
        static Direction South = new Direction { Value = "SOUTH" };
        static Direction East = new Direction { Value = "EAST" };
        static Direction West = new Direction { Value = "WEST" };

        static Direction[] Directions = new[] {North, East, South, West };

        public static string[] dirReduc(string[] directions)
        {
            North.Opposite = South;
            South.Opposite = North;
            East.Opposite = West;
            West.Opposite = East;

            var directionsCopy = directions.ToArray();
            var reducedDirections = new List<string>();

            bool hasOpposite = false;
            do
            {
                hasOpposite = false;
                reducedDirections.Clear();
                for (int i = 0; i < directionsCopy.Length; i++)
                {
                    bool immediateOpposite = false;
                    var direction = Directions.First(dir => dir.Value == directionsCopy[i]);
                    if (i + 1 < directionsCopy.Length)
                    {
                        if (directionsCopy[i + 1] == direction.Opposite.Value)
                        {
                            i++;
                            hasOpposite = true;
                            immediateOpposite = true;
                        }
                    }

                    if (!immediateOpposite)
                    {
                        reducedDirections.Add(directionsCopy[i]);
                    }
                }

                directionsCopy = reducedDirections.ToArray();
            } while (hasOpposite);

            return reducedDirections.ToArray();
        }

        private class Direction
        {
            public string Value { get; set; }
            public Direction Opposite { get; set; }
        }
    }
}
