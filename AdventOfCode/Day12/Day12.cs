using AdventOfCode.Day10;
using AdventOfCode.Day12;
using AdventOfCode.Model;
using System.IO;

public static class Day12
{
    public static void Execute()
    {
        string filePath = "Day12/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map(lines);
            var regions = GetRegions(map);
            Console.WriteLine($"There are {regions.Count} regions");
            foreach (var region in regions)
            {
                Console.WriteLine($"Region with flower type {region.FlowerType} has {region.Points.Count} points");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static List<Region> GetRegions(Map map)
    {
        var regions = new List<Region>();
        for (int i = 0; i < map.Grid.GetLength(0); i++)
        {
            for (int j = 0; j < map.Grid.GetLength(1); j++)
            {
                if (map.Results[i, j] == "")
                {
                    var region = new Region()
                    {
                        FlowerType = map.Grid[i, j],
                        Points = new List<(int, int)> { (i, j) }
                    };
                    GetRegion(map, i, j, region);
                    regions.Add(region);
                }
            }
        }
        return regions;
    }
    public static void GetRegion(Map map, int i, int j, Region region)
    {
        var searchLocations = new List<Location>
        {
            new Location { X = i - 1, Y = j },
            new Location { X = i + 1, Y = j },
            new Location { X = i, Y = j - 1 },
            new Location { X = i, Y = j + 1 }
        };
        map.Results[i, j] = "#";
        var searchCharacter = map.Grid[i, j];
        foreach (var searchLocation in searchLocations)
        {
            if (map.IsOffGrid(searchLocation.X, searchLocation.Y) || 
                map.Grid[searchLocation.X, searchLocation.Y] != searchCharacter || map.Results[searchLocation.X, searchLocation.Y] != "")
            {
                continue;
            }
            region.Points.Add((searchLocation.X, searchLocation.Y));
            GetRegion(map, searchLocation.X, searchLocation.Y, region);
        }
    }
}