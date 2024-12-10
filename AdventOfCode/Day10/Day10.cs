using AdventOfCode.Day10;
using AdventOfCode.Model;
using System.IO;

public static class Day10
{
    public static void Execute()
    {
        string filePath = "Day10/Test4.txt";
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
            ProcessNextSteps(map, paths);
            var walkingPaths = new List<WPath>();
            foreach (var path in paths)
            {
                var wPath = new WPath { Start = path };
                wPath.Ends.AddRange(FindTrailEnds(map, path.NextSteps));
                walkingPaths.Add(wPath);
            }
            var allPaths = walkingPaths.SelectMany(
                path => path.Ends, 
                (start, end) => new DistinctPath { 
                    Start = new Location { X = start.Start.X, Y = start.Start.Y },
                    End = new Location { X = end.X, Y = end.Y }
                    }
                ).ToList();
            var distinctPaths = allPaths.DistinctBy(a => new { s1 = a.Start.X, s2 = a.Start.Y, e1 = a.End.X, e2 = a.End.Y } ).ToList();
            
            foreach(var distinctPath in distinctPaths.OrderBy(a => a.Start.Y).ThenBy(b => b.Start.X).ToList())
            {
                Console.WriteLine($"Found distinct path from {distinctPath.Start.X+1},{distinctPath.Start.Y + 1} to {distinctPath.End.X + 1},{distinctPath.End.Y + 1}");
            }
            Console.WriteLine($"Found {paths.Count} starting points with trail count {distinctPaths.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void ProcessNextSteps(Map map, List<Location> paths)
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
                        //Console.WriteLine($"Found {searchValue} at {i},{j}");
                    }
                }
            }
            if (searchValue != "9")
            {
                ProcessNextSteps(map, path.NextSteps);
            }
        }
    }
    public static List<Location> FindTrailEnds(Map map, List<Location> paths)
    {
        var foundEndings = new List<Location>();
        foreach (var path in paths)
        {
            var currentValue = map.Grid[path.X, path.Y];
            if (currentValue == "9")
            {
                foundEndings.Add(path);
            } else {
                foundEndings.AddRange(FindTrailEnds(map, path.NextSteps));
            }
        }
        return foundEndings;
    }
}