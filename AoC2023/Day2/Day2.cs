namespace AoC2023.Day2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Day2
    {
        public int SumOfPossibleGames(string? overrideInput, int red, int green, int blue)
        {
            if (overrideInput == null)
            {
                overrideInput = this.ReadInputFromFile();
            }

            int runningTotal = 0;

            foreach (string line in overrideInput.Split(Environment.NewLine))
            {
                var result = GetIdOfPossibleGame(line, red, green, blue);
                if (result.Possible) { runningTotal += result.Id; }
            }

            return runningTotal;
        }

        public long PowerOfPossibleGames(string? overrideInput, int red, int green, int blue)
        {
            if (overrideInput == null)
            {
                overrideInput = this.ReadInputFromFile();
            }

            long runningTotal = 0;

            foreach (string line in overrideInput.Split(Environment.NewLine))
            {
                var result = GetIdOfPossibleGame(line, red, green, blue);
                runningTotal += result.GamePower;
            }

            return runningTotal;
        }

        public GameResult GetIdOfPossibleGame(string line, int red, int green, int blue)
        {
            var result = new GameResult();
            var rawArray = line.Split(" ");
            if (rawArray.Length == 1) { return result; }
            string idString = rawArray[1];
            int id = int.Parse(idString.TrimEnd(':'));
            result.Id = id;

            bool possible = true;
            var gamesArray = line.Split(";");
            foreach (var game in gamesArray)
            {
                string[] tokenizedGame = game.Split(" ");
                var redPosition = Array.FindIndex(tokenizedGame, token => token.StartsWith("red"));
                var greenPosition = Array.FindIndex(tokenizedGame, token => token.StartsWith("green"));
                var bluePosition = Array.FindIndex(tokenizedGame, token => token.StartsWith("blue"));

                if (redPosition > 0)
                {
                    var testRed = int.Parse(tokenizedGame[redPosition - 1]);
                    possible &= testRed <= red;
                    result.MaxRed = testRed > result.MaxRed ? testRed : result.MaxRed;
                }

                if (greenPosition > 0)
                {
                    var testGreen = int.Parse(tokenizedGame[greenPosition - 1]);
                    possible &= testGreen <= green;
                    result.MaxGreen = testGreen > result.MaxGreen ? testGreen : result.MaxGreen;
                }

                if (bluePosition > 0)
                {
                    var testBlue = int.Parse(tokenizedGame[bluePosition - 1]);
                    possible &= testBlue <= blue;
                    result.MaxBlue = testBlue > result.MaxBlue ? testBlue : result.MaxBlue;
                }
            }

            result.Possible = possible;
            return result;
        }

        private string ReadInputFromFile()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day2", "input.txt");
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

    public class GameResult
    {
        public int Id { get; set; }
        public bool Possible { get; set; }
        public int MaxRed { get; set; }
        public int MaxGreen { get; set; }
        public int MaxBlue { get; set; }

        public int GamePower => Id == 0 ? 0 : (MaxRed > 0 ? MaxRed : 1) * (MaxGreen > 0 ? MaxGreen : 1) * (MaxBlue > 0 ? MaxBlue : 1);
    }
}
