namespace AdventOfCode.Day12
{
    public class Region
    {
        public List<(int, int)> Points { get; set; }
        public string FlowerType { get; set; } = "";
        public int Perimeter { get; set; }
        public Region()
        {
            Points = new List<(int, int)>();
        }
        public int GetSize()
        {
            return Points.Count;
        }
    }
}
