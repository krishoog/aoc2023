namespace Day05
{
    public class Mapper
    {
        // Key = Source Range Start, Value = Destination Range
        private readonly SortedDictionary<long, Range> ranges = [];

        public void AddRange(long dstStart, long srcStart, long length)
        {
            ranges[srcStart] = new Range(dstStart, length);
        }

        public long Map(long source)
        {
            return FindDestinationRange(new Range(source, 1)).Start;
        }

        public IEnumerable<Range> Map(Range source)
        {
            while (source.Length > 0)
            {
                var range = FindDestinationRange(source);
                range = range with { Length = Math.Min(source.Length, range.Length) };
                source = source.Advance(range.Length);
                yield return range;
            }
        }

        public IEnumerable<Range> Map(IEnumerable<Range> sources)
        {
            foreach (var source in sources)
            {
                foreach (var range in Map(source))
                {
                    yield return range;
                }
            }
        }

        private Range FindDestinationRange(Range source)
        {
            if (ranges.Count == 0 || source.Start < ranges.First().Key)
            {
                return source with { Length = ranges.Count == 0 ? source.Length : ranges.First().Key - source.Start };
            }

            foreach (var (src, dstRange) in ranges)
            {
                if (source.Start >= src && source.Start - src < dstRange.Length)
                {
                    return dstRange.Advance(source.Start - src);
                }
            }

            return source;
        }
    }
}
