namespace AdventOfCode.Day12
{
    public class Region
    {
        public List<(int, int)> Points { get; set; }
        public string FlowerType { get; set; } = "";
        public Region()
        {
            Points = new List<(int, int)>();
        }
        public int GetSize()
        {
            return Points.Count;
        }
        public int GetPerimeter()
        {
            return 0;
        }
    }
}
