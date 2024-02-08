namespace AoC2023.Day05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Day5
    {
        private string ReadInputFromFile()
        {
            string expectedInputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Day05", "input.txt");
            if (!File.Exists(expectedInputFile))
            {
                throw new Exception("Could not find input file.");
            }

            using (var reader = new StreamReader(expectedInputFile))
            {
                return reader.ReadToEnd();
            }
        }

        public long GetNearestSoilLocation(string? overrideInput)
        {
            if (overrideInput == null) overrideInput = ReadInputFromFile();

            var seeds = GetMappedSeeds(overrideInput);
            seeds = this.PopulateMapValues(overrideInput, seeds, "seed-to-soil", nameof(MappedSeed.SeedId), nameof(MappedSeed.SoilId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "soil-to-fertilizer", nameof(MappedSeed.SoilId), nameof(MappedSeed.FertilizerId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "fertilizer-to-water", nameof(MappedSeed.FertilizerId), nameof(MappedSeed.WaterId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "water-to-light", nameof(MappedSeed.WaterId), nameof(MappedSeed.LightId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "light-to-temperature", nameof(MappedSeed.LightId), nameof(MappedSeed.TemperatureId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "temperature-to-humidity", nameof(MappedSeed.TemperatureId), nameof(MappedSeed.HumidityId));
            seeds = this.PopulateMapValues(overrideInput, seeds, "humidity-to-location", nameof(MappedSeed.HumidityId), nameof(MappedSeed.LocationId));

            return seeds.Min(s => s.LocationId);
        }

        public IEnumerable<MappedSeed> GetMappedSeeds(string input)
        {
            var result = new List<MappedSeed>();

            // assume seeds on line 1
            var seedsString = input.Split(Environment.NewLine)[0].Split(':')[1].Trim();
            var seedsArray = seedsString.Split(' ');
            foreach (string seedString in seedsArray)
            {
                result.Add(new MappedSeed { SeedId = long.Parse(seedString) });
            }

            return result;
        }

        public IEnumerable<MappedSeed> PopulateMapValues(string input, IEnumerable<MappedSeed> seeds, string mapName, string sourcePropertyName, string destinationPropertyName)
        {
            if (!input.Contains(mapName))
            {
                throw new Exception("Unknown map requested.");
            }

            int startingPosition = input.IndexOf(mapName, 0);
            int endingPosition = input.IndexOf($"{Environment.NewLine}{Environment.NewLine}", startingPosition);
            if (endingPosition == -1)
            {
                endingPosition = input.Length;
            }

            string mapSection = input.Substring(startingPosition, endingPosition - startingPosition);
            var mapRows = mapSection.Split(Environment.NewLine);
            foreach (var row in mapRows.Skip(1))
            {
                var rowValues = row.Split(' ');
                var destinationStart = long.Parse(rowValues[0]);
                var sourceStart = long.Parse(rowValues[1]);
                var length = long.Parse(rowValues[2]);

                foreach (var seed in seeds)
                {
                    var sourceValue = (long)(typeof(MappedSeed).GetProperty(sourcePropertyName)?.GetValue(seed) ?? -1);
                    if (sourceValue >= sourceStart && sourceValue <= sourceStart + (length - 1))
                    {
                        var offset = sourceValue - sourceStart;
                        typeof(MappedSeed).GetProperty(destinationPropertyName)?.SetValue(seed, destinationStart + offset);
                    }
                }
            }

            foreach (var seed in seeds)
            {
                var destinationValue = (long)(typeof(MappedSeed).GetProperty(destinationPropertyName)?.GetValue(seed) ?? -1);
                var sourceValue = (long)(typeof(MappedSeed).GetProperty(sourcePropertyName)?.GetValue(seed) ?? -1);

                if (destinationValue == 0)
                {
                    typeof(MappedSeed).GetProperty(destinationPropertyName)?.SetValue(seed, sourceValue);
                }
            }

            return seeds;
        }
    }

    [DebuggerDisplay("Seed {SeedId}, Soil {SoilId}, Fert {FertilizerId}, Water {WaterId}, Light {LightId}, Temp {TemperatureId}, Hum {HumidityId}, Loc {LocationId}")]
    public class MappedSeed
    {
        public long SeedId { get; set; }
        public long SoilId { get; set; }
        public long FertilizerId { get; set; }
        public long WaterId { get; set; }
        public long LightId { get; set; }
        public long TemperatureId { get; set; }
        public long HumidityId { get; set; }
        public long LocationId { get; set; }
    }
}
