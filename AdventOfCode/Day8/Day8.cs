using AdventOfCode.Day8;
using AdventOfCode.Utility;

public static class Day8
{
    public static void Execute()
    {
        string filePath = "Day8/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map
            {
                Grid = ArrayExtensions.GetGrid(lines)
            };
            map.InitialiseResultsGrid();
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(1); j++)
                {
                    var currentLocation = map.Grid[i, j];
                    if (currentLocation != ".")
                    {
                        var found = FindNearestIn(ref map, currentLocation, i, j);
                        if (found.Count > 0)
                        {
                            foreach (var item in found)
                            {
                                var offsetX = item.LocationX - i;
                                var offsetY = item.LocationY - j;
                                var firstAntiNodeX = i + offsetX;
                                var firstAntiNodeY = j + offsetY;
                                if (!map.IsOffGrid(firstAntiNodeX, firstAntiNodeY) && map.Grid[firstAntiNodeX, firstAntiNodeY] != currentLocation )
                                {
                                    map.Results[firstAntiNodeX, firstAntiNodeY] = "#";
                                    Console.WriteLine($"Antinode found at {firstAntiNodeX+1}:{firstAntiNodeY+1}");
                                }
                                var secondAntiNodeX = i - offsetX;
                                var secondAntiNodeY = j - offsetY;
                                if (!map.IsOffGrid(secondAntiNodeX, secondAntiNodeY) && map.Grid[secondAntiNodeX, secondAntiNodeY] != currentLocation)
                                {
                                    map.Results[secondAntiNodeX, secondAntiNodeY] = "#";
                                    Console.WriteLine($"Antinode found at {secondAntiNodeX+1}:{secondAntiNodeY+1}");
                                }
                            }
                        }
                    }
                }
            }
            map.CountResults();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static List<Position> FindNearestIn(ref Map map, string searchingFor, int startX, int startY)
    {
        var searchRadius = 5;
        var found = new List<Position>();
        for (int i = startX - searchRadius; i < startX + searchRadius; i++)
        {
            for (int j = startY - searchRadius; j < startY + searchRadius; j++)
            {
                if (i == startX && j == startY) continue;
                if (map.IsOffGrid(i, j)) continue;
                if (map.Grid[i,j] == searchingFor)
                {
                    found.Add(new Position(i, j));
                }
            }
        }
        return found;
    }
}