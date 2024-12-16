using AdventOfCode.Model;

public static class Day16
{
    public static void Execute()
    {
        string filePath = "Day16/test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map(lines);
            map.Display();
            map.InitialiseResultsGrid();
            var startLocation = map.FindFirst("S");
            var exitLocation = map.FindFirst("E");
            Console.WriteLine($"Robot is at {startLocation.Item1+1}:{startLocation.Item2+1}");
            Console.WriteLine($"Exit is at {exitLocation.Item1+1}:{exitLocation.Item2+1}");
            FindPaths(map, 10, startLocation);
            map.DisplayResults("** ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void FindPaths(Map map, int currentDistance, (int, int) location)
    {
        map.GetSearchLocations(location.Item1, location.Item2).ForEach(l =>
        {
            if (map.Grid[l.X, l.Y] == "#" || map.Grid[l.X, l.Y] == "S")
            {
                return;
            }
            if (!string.IsNullOrEmpty(map.Results[l.X, l.Y]))
            {
                var currentResult = int.Parse(map.Results[l.X, l.Y]);
                if (currentResult > 0 && currentResult <= currentDistance)
                {
                    return;
                }
            }
            map.Results[l.X, l.Y] = currentDistance.ToString();
            if (map.Grid[l.X, l.Y] == "E")
            {
                Console.WriteLine($"Exit found at {l.X + 1}:{l.Y + 1} after {currentDistance + 1} steps");
                return;
            }
            FindPaths(map, currentDistance + 1, (l.X, l.Y));
        });
    }
}