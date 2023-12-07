namespace Day05
{
    public class Almanac
    {
        private readonly List<long> seeds = [];
        private readonly Mapper seedToSoil = new();
        private readonly Mapper soilToFertilizer = new();
        private readonly Mapper fertilizerToWater = new();
        private readonly Mapper waterToLight = new();
        private readonly Mapper lightToTemperature = new();
        private readonly Mapper temperatureToHumidity = new();
        private readonly Mapper humidityToLocation = new();

        public Almanac(IEnumerable<string> lines)
        {
            seeds = SplitNumbers(lines.First().Split(": ")[1]).ToList();
            Mapper? mapper = null;
            foreach (var line in lines)
            {
                switch (line)
                {
                    case var x when x.Length == 0: continue;
                    case "seed-to-soil map:": mapper = seedToSoil; break;
                    case "soil-to-fertilizer map:": mapper = soilToFertilizer; break;
                    case "fertilizer-to-water map:": mapper = fertilizerToWater; break;
                    case "water-to-light map:": mapper = waterToLight; break;
                    case "light-to-temperature map:": mapper = lightToTemperature; break;
                    case "temperature-to-humidity map:": mapper = temperatureToHumidity; break;
                    case "humidity-to-location map:": mapper = humidityToLocation; break;
                    default:
                        if (mapper != null)
                        {
                            var data = SplitNumbers(line).ToArray();
                            mapper.AddRange(data[0], data[1], data[2]);
                        }
                        break;
                }
            }
        }

        public IEnumerable<long> GetLocations()
        {
            foreach (var seed in seeds)
            {
                yield return humidityToLocation.Map(
                    temperatureToHumidity.Map(
                        lightToTemperature.Map(
                            waterToLight.Map(
                                fertilizerToWater.Map(
                                    soilToFertilizer.Map(
                                        seedToSoil.Map(
                                            seed)))))));
            }
        }

        private static IEnumerable<long> SplitNumbers(string numbers)
        {
            return numbers.Split(" ").Where(x => x.Length > 0).Select(long.Parse);
        }
    }
}
