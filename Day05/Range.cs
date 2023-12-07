namespace Day05
{
    public readonly record struct Range(long Start, long Length)
    {
        public Range Advance(long steps)
        {
            return this with { Start = Start + steps, Length = Length - steps };
        }
    }
}
