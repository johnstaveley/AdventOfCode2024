using AdventOfCode.Day6;

namespace AdventOfCode.Day8
{
    public class Map
    {
        public string[,] Grid { get; set; }
        public string[,] Results { get; set; }
        public bool IsOffGrid(int locationX, int locationY)
        {
            return locationX < 0 || locationX >= Grid.GetLength(0) || locationY < 0 || locationY >= Grid.GetLength(1);
        }
        public void InitialiseResultsGrid()
        {
            Results = new string[Grid.GetLength(0), Grid.GetLength(1)];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Results[i, j] = "";
                }
            }
        }
        public void CountResults()
        {
            var resultCount = 0;
            for (int i = 0; i < Results.GetLength(0); i++)
            {
                for (int j = 0; j < Results.GetLength(1); j++)
                {
                    resultCount += Results[i, j] == "#" ? 1 : 0;
                }
            }
            Console.WriteLine($"Result count: {resultCount}");
        }
    }
}
