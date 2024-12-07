namespace AdventOfCode.Day6
{
    public class Map
    {
        public string[,] Grid { get; set; }
        public Tuple<int, int> GuardLocation()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i, j] == "^")
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }
        public bool IsOffGrid(Tuple<int, int> location)
        {
            return location.Item1 < 0 || location.Item1 >= Grid.GetLength(0) || location.Item2 < 0 || location.Item2 >= Grid.GetLength(1);
        }
    }
}
