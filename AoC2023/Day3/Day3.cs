namespace AoC2023.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Day3
    {

        private string ReadInputFromFile()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day02", "input.txt");
            if (!File.Exists(expectedInputFile))
            {
                throw new Exception("Could not find input file.");
            }

            using (var reader = new StreamReader(expectedInputFile))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
