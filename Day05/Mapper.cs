namespace Day05
{
    public class Mapper
    {
        // Key = Source Range Start, Value = (Destination Range Start, Range Length)
        private readonly SortedDictionary<long, (long, long)> ranges = [];

        public void AddRange(long dstStart, long srcStart, long length)
        {
            ranges[srcStart] = (dstStart, length);
        }

        public long Map(long source)
        {
            if (ranges.Count == 0 || source < ranges.First().Key)
                return source;

            foreach (var (src, (dst, len)) in ranges)
            {
                if (source >= src && source - src < len)
                {
                    return dst + source - src;
                }
            }

            return source;
        }
    }
}
