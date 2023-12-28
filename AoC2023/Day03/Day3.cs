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
        public int SumOfPartNumbers(string? overrideInput)
        {
            if (overrideInput == null) overrideInput = ReadInputFromFile();
            var symbols = GetSymbolLocations(overrideInput);
            var gridNumbers = GetGridNumbers(overrideInput);
            var numbersTouchingSymbols = GetGridNumbersTouchingSymbols(symbols, gridNumbers);

            return numbersTouchingSymbols.Sum(number => number.Value);
        }

        public long SumOfGearRatios(string? overrideInput)
        {
            if (overrideInput == null) overrideInput = ReadInputFromFile();
            var symbols = GetSymbolLocations(overrideInput);
            var gridNumbers = GetGridNumbers(overrideInput);
            var gearRatios = GetGearRatios(symbols, gridNumbers);
            return gearRatios.Sum();
        }

        public IEnumerable<Symbol> GetSymbolLocations(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var result = new List<Symbol>();
            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                var chars = line.ToCharArray();
                for (int x = 0; x < chars.Length; x++)
                {
                    var c = chars[x];
                    if (!char.IsNumber(c) && c != '.')
                    {
                        result.Add(new Symbol() { X = x, Y = y, Type = c});
                    }
                }
            }

            return result;
        }

        public IEnumerable<GridNumber> GetGridNumbers(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var result = new List<GridNumber>();
            
            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                var chars = line.ToCharArray();
                for (int x = 0; x < chars.Length; x++)
                {
                    var c = chars[x];
                    if (char.IsNumber(c))
                    {
                        var gridNumber = new GridNumber() { XStart = x, Y = y };
                        var number = new List<char>();
                        while (x < chars.Length && char.IsNumber(chars[x]))
                        {
                            number.Add(chars[x]);
                            x++;
                        }
                        gridNumber.XFinish = x - 1;
                        gridNumber.Value = int.Parse(new string(number.ToArray()));
                        result.Add(gridNumber);
                    }
                }
            }

            return result;
        }

        public IEnumerable<GridNumber> GetGridNumbersTouchingSymbols(IEnumerable<Symbol> symbols, IEnumerable<GridNumber> numbers)
        {
            var result = new List<GridNumber>();
            foreach (var number in numbers)
            {
                if (symbols.Any(symbol => symbol.TouchesNumber(number)))
                {
                    result.Add(number);
                    continue;
                }
            }

            return result;
        }

        public IEnumerable<int> GetGearRatios(IEnumerable<Symbol> symbols, IEnumerable<GridNumber> gridNumbers)
        {
            var result = new List<int>();

            foreach (var symbol in symbols.Where(s => s.Type == '*'))
            {
                int ratio = 1;
                int touching = 0;
                foreach (var number in gridNumbers.Where(num => symbol.TouchesNumber(num)))
                {
                    touching++;
                    ratio *= number.Value;
                }

                if (touching > 1) { result.Add(ratio); }
            }

            return result;
        }

        private string ReadInputFromFile()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day03", "input.txt");
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

    public class GridNumber
    {
        public int XStart { get; set; }
        public int XFinish { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }

    public class Symbol
    {
        public Symbol(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Symbol() {}
        public int X { get; set; }
        public int Y { get; set; }
        public char Type { get; set; }
        public Boolean TouchesNumber(GridNumber number)
        {
            return this.X >= number.XStart - 1 && this.X <= number.XFinish + 1 && number.Y >= this.Y - 1 && number.Y <= this.Y + 1;
        }
    }
}
