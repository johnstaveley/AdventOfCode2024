using AdventOfCode.Day8;
using AdventOfCode.Utility;

public static class Day08
{
    public static void Execute()
    {
        string filePath = "Day08/Input.txt";
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
                                var antiNodeX = i + offsetX;
                                var antiNodeY = j + offsetY;
                                do
                                {
                                    if (!map.IsOffGrid(antiNodeX, antiNodeY))
                                    {
                                        map.Results[antiNodeX, antiNodeY] = "#";
                                    }
                                    antiNodeX += offsetX;
                                    antiNodeY += offsetY;
                                } while (!map.IsOffGrid(antiNodeX, antiNodeY));
                                antiNodeX = i - offsetX;
                                antiNodeY = j - offsetY;
                                do
                                {
                                    if (!map.IsOffGrid(antiNodeX, antiNodeY))
                                    {
                                        map.Results[antiNodeX, antiNodeY] = "#";
                                    }
                                    antiNodeX -= offsetX;
                                    antiNodeY -= offsetY;
                                } while (!map.IsOffGrid(antiNodeX, antiNodeY));

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
        var searchRadius = (map.Grid.GetLength(0)/ 2) + 10;
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