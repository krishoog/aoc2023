namespace Day02
{
    public readonly record struct CubeSet(int Red, int Green, int Blue)
    {
        public int Power { get => Red * Green * Blue; }
    }
}
