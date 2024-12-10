using AdventOfCode.Model;

public static class Day10
{
    public static void Execute()
    {
        string filePath = "Day10/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map(lines);
            // Find all starting points
            var paths = new List<Location>();
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(1); j++)
                {
                    if (map.Grid[i, j] == "0")
                    {
                        paths.Add(new Location { X = i, Y = j });
                    }
                }
            }
            int score = 0;
            ProcessNextSteps(map, paths, ref score);
            Console.WriteLine($"Found {paths.Count} starting points with score {score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void ProcessNextSteps(Map map, List<Location> paths, ref int score)
    {
        foreach (var path in paths)
        {
            var currentValue = map.Grid[path.X, path.Y];
            var searchValue = (int.Parse(currentValue) + 1).ToString();
            for (int i = path.X -1; i <= path.X+1; i++)
            {
                for (int j = path.Y-1; j <= path.Y+1; j++)
                {
                    if (!map.IsOffGrid(i,j) && map.Grid[i, j] == searchValue)
                    {
                        path.NextSteps.Add(new Location { X = i, Y = j });
                        Console.WriteLine($"Found {searchValue} at {i},{j}");
                    }
                }
            }
            if (searchValue == "9")
            {
                score++;
            }
            else
            {
                ProcessNextSteps(map, path.NextSteps, ref score);
            }
        }

    }
}