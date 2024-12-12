using AdventOfCode.Day12;
using AdventOfCode.Model;
using System.Linq;

public static class Day12
{
    public static void Execute()
    {
        string filePath = "Day12/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map(lines);
            var regions = GetRegions(map);
            Console.WriteLine($"There are {regions.Count} regions");
            foreach (var region in regions)
            {
                region.Perimeter = GetPerimeter(map, region);
                Console.WriteLine($"Region with flower type {region.FlowerType} has area {region.GetSize()} and perimeter {region.Perimeter}");
            }
            var totalPrice = regions.Sum(s => s.GetSize() * s.Perimeter);
            Console.WriteLine($"The total price is {totalPrice}");
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
        map.Results[i, j] = "#";
        var searchCharacter = map.Grid[i, j];
        foreach (var searchLocation in map.GetSearchLocations(i,j))
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
    public static int GetPerimeter(Map map, Region region)
    {
        var totalPerimeter = 0;
        List<(int, int)> pointsSearched = new List<(int, int)>();
        foreach (var point in region.Points)
        {
            pointsSearched.Add(point);
            foreach (var searchLocation in map.GetSearchLocations(point.Item1, point.Item2)) {
                if (pointsSearched.Any(a => a.Item1 == searchLocation.X && a.Item2 == searchLocation.Y))
                {
                    continue;
                }
                if (map.IsOffGrid(searchLocation.X, searchLocation.Y)) {
                    totalPerimeter++;
                    continue;
                }
                if (map.Grid[searchLocation.X, searchLocation.Y] != region.FlowerType)
                {
                    totalPerimeter++;
                }
            }
        }
        return totalPerimeter;
    }
}