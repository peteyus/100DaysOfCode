namespace AoC2023.Day1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Day1
    {
        public int ProcessPartOneInput()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day1", "input.txt");
            if (!File.Exists(expectedInputFile))
            {
                throw new Exception("Could not find input file.");
            }

            int totalValue = 0;

            using (var reader = new StreamReader(expectedInputFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine() ?? string.Empty;
                    var currentValue = ProcessLine(line);
                    totalValue += currentValue;
                }
            }

            return totalValue;
        }

        public int ProcessLine(string line)
        {
            var array = line.ToCharArray();

            int firstDigitIndex = 0; 
            int secondDigitIndex = array.Length - 1;
            char? firstDigit = null;
            char? secondDigit = null ;

            for (int i = 0; i <= secondDigitIndex; i++)
            {
                if (!char.IsNumber(array[i]))
                {
                    continue;
                }

                firstDigit = array[i];
                firstDigitIndex = i;
                break;
            }

            for (int i = secondDigitIndex; i >= firstDigitIndex; i--) 
            {
                if (!char.IsNumber(array[i]))
                {
                    continue;
                }

                secondDigit = array[i];
                secondDigitIndex = i;
                break;
            }

            if (firstDigit is null || secondDigit is null)
            {
                return 0;
            }

            char[] chars = { (char)firstDigit, (char)secondDigit }; 
            return int.Parse(new string(chars));
        }
    }
}
