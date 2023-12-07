namespace Day05
{
    public class Almanac
    {
        private readonly List<Range> seedRanges = [];
        private readonly Mapper seedToSoil = new();
        private readonly Mapper soilToFertilizer = new();
        private readonly Mapper fertilizerToWater = new();
        private readonly Mapper waterToLight = new();
        private readonly Mapper lightToTemperature = new();
        private readonly Mapper temperatureToHumidity = new();
        private readonly Mapper humidityToLocation = new();

        public Almanac(IEnumerable<string> lines)
        {
            foreach (var chunk in SplitNumbers(lines.First().Split(": ")[1]).Chunk(2))
            {
                seedRanges.Add(new Range(chunk[0], chunk[1]));
            }

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

        public IEnumerable<Range> GetLocations()
        {
            foreach (var locationRange in humidityToLocation.Map(
                    temperatureToHumidity.Map(
                        lightToTemperature.Map(
                            waterToLight.Map(
                                fertilizerToWater.Map(
                                    soilToFertilizer.Map(
                                        seedToSoil.Map(
                                            seedRanges))))))))
            {
                yield return locationRange;
            }
        }

        public long GetLowestLocation()
        {
            return GetLocations().Select(x => x.Start).Min();
        }

        private static IEnumerable<long> SplitNumbers(string numbers)
        {
            return numbers.Split(" ").Where(x => x.Length > 0).Select(long.Parse);
        }
    }
}
