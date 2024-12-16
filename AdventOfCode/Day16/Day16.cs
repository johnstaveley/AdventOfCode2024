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
            FindPaths(map, startLocation, 11);
            map.DisplayResults("** ");
            FindScore(map, startLocation, 10, 0, DirectionEnum.East);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static int FindScore(Map map, (int, int) location, int currentDistance, int currentScore, DirectionEnum currentlyFacing)
    {
        map.GetSearchLocations(location.Item1, location.Item2).ForEach(l =>
        {
            if (map.Grid[l.X, l.Y] == "#" || map.Grid[l.X, l.Y] == "S")
            {
                return;
            }
            if (string.IsNullOrEmpty(map.Results[l.X, l.Y]))
            {
                return;                
            }
            if (map.Grid[l.X, l.Y] == "E")
            {
                Console.WriteLine($"Exit found at {l.X + 1}:{l.Y + 1} after {currentDistance + 1} steps with a score of {currentScore}");
                return;
            }
            var nextResult = int.Parse(map.Results[l.X, l.Y]);
            if (nextResult == currentDistance + 1)
            {
                // Found next result
                var nextDirectionIsNorth = l.Y < location.Item2;
                var nextDirectionIsSouth = l.Y > location.Item2;
                var nextDirectionIsWest = l.X < location.Item1;
                var nextDirectionIsEast = l.X > location.Item1;
                currentScore++;
                // If you have to turn then add 1000 to score
                if (currentlyFacing == DirectionEnum.North && !nextDirectionIsNorth || currentlyFacing == DirectionEnum.South && !nextDirectionIsSouth ||
                    currentlyFacing == DirectionEnum.East && nextDirectionIsEast || currentlyFacing == DirectionEnum.West && nextDirectionIsWest)
                {
                    currentScore += 1000;                    
                }
                if (nextDirectionIsEast) currentlyFacing = DirectionEnum.East;
                if (nextDirectionIsNorth) currentlyFacing = DirectionEnum.North;
                if (nextDirectionIsSouth) currentlyFacing = DirectionEnum.South;
                if (nextDirectionIsWest) currentlyFacing = DirectionEnum.West;
                FindScore(map, (l.X, l.Y), currentDistance + 1, currentScore, currentlyFacing);
            }
        });
        return currentScore;
    }
    public static void FindPaths(Map map, (int, int) location, int currentDistance)
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
            FindPaths(map, (l.X, l.Y), currentDistance + 1);
        });
    }
}