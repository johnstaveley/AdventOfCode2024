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
            for (int j = 0; j < Results.GetLength(1); j++)
            {
                for (int i = 0; i < Results.GetLength(0); i++)
                {
                    if (Results[i, j] == "#")
                    {
                        resultCount++;
                        //Console.WriteLine($"Antinode found at {i + 1}:{j + 1}");
                        Console.Write("#");
                    } else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Result count: {resultCount}");
        }
    }
}
