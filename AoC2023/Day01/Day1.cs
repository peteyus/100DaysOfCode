namespace AoC2023.Day1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class Day1
    {
        private static Dictionary<string, char> numberTable = new Dictionary<string, char>{
        {"zero",'0'},{"one",'1'},{"two",'2'},{"three",'3'},{"four",'4'},{"five",'5'},{"six",'6'},
        {"seven",'7'},{"eight",'8'},{"nine",'9'} };

        public int ProcessPartOneInput()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day01", "input.txt");
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

        public int ProcessPartTwoInput(string? inputOverride)
        {
            int totalValue = 0;

            if (inputOverride != null)
            {
                var lines = inputOverride.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    totalValue += ProcessLinePartTwo(line);
                }

                return totalValue;
            }

            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day01", "input.txt");
            if (!File.Exists(expectedInputFile))
            {
                throw new Exception("Could not find input file.");
            }


            using (var reader = new StreamReader(expectedInputFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine() ?? string.Empty;
                    var currentValue = ProcessLinePartTwo(line);
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

        public int ProcessLinePartTwo(string line)
        {
            var array = line.ToCharArray();

            int firstDigitIndex = -1;
            int secondDigitIndex = -1;
            char? firstDigit = null;
            char? secondDigit = null;

            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (!char.IsNumber(array[i]))
                {
                    continue;
                }

                firstDigit = array[i];
                firstDigitIndex = i;
                break;
            }

            for (int i = array.Length - 1; i >= (firstDigitIndex == -1 ? 0 : firstDigitIndex) ; i--)
            {
                if (!char.IsNumber(array[i]))
                {
                    continue;
                }

                secondDigit = array[i];
                secondDigitIndex = i;
                break;
            }

            foreach (var numberString in numberTable.Keys)
            {
                if (numberString is null) continue;

                int firstPos = line.IndexOf(numberString, 0);
                if (firstPos == -1) { continue;  }

                if (line.IndexOf(numberString, 0) < (firstDigitIndex == -1 ? array.Length : firstDigitIndex))
                {
                    firstDigitIndex = line.IndexOf(numberString, 0);
                    firstDigit = numberTable[numberString];
                }

                if (line.LastIndexOf(numberString, line.Length) > secondDigitIndex)
                {
                    secondDigitIndex = line.LastIndexOf(numberString, line.Length);
                    secondDigit = numberTable[numberString];
                }
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
