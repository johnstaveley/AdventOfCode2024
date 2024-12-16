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
            Console.WriteLine($"Robot is at {startLocation.Item1+1}:{startLocation.Item2+1}");
            map.Results[startLocation.Item1, startLocation.Item2] = "00";
            FindPaths(map, startLocation, 1, 0, DirectionEnum.East);
            map.DisplayResults("** ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void FindPaths(Map map, (int, int) location, int currentDistance, int numberOfTurns, DirectionEnum currentlyFacing)
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
                var finalScore = numberOfTurns * 1000 + currentDistance;
                Console.WriteLine($"Exit found at {l.X + 1}:{l.Y + 1} after {currentDistance} steps {numberOfTurns} turns and with a score of {finalScore}");
                return;
            }
            var nextDirection = DirectionEnum.North;
            if (l.Y < location.Item2)
            {
                nextDirection = DirectionEnum.North;
            }
            if (l.Y > location.Item2)
            {
                nextDirection = DirectionEnum.South;
            }
            if (l.X < location.Item1)
            {
                nextDirection = DirectionEnum.West;
            }
            if (l.X > location.Item1)
            {
                nextDirection = DirectionEnum.East;
            }
            // If you have to turn then add 1000 to score
            if (currentlyFacing != nextDirection)
            {
                numberOfTurns ++;
                currentlyFacing = nextDirection;
                Console.WriteLine($"Turned to face {nextDirection} at {l.X}:{l.Y} after {currentDistance} steps {numberOfTurns} turns");
            }
            FindPaths(map, (l.X, l.Y), currentDistance + 1, numberOfTurns, currentlyFacing);
        });
    }
}