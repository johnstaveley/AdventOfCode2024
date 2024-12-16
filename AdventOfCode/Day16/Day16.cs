using AdventOfCode.Day16;
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
            var pathTravelled = new List<Location>()
            {
                new Location { X = startLocation.Item1, Y = startLocation.Item2 }
            };
            FindPaths(map, startLocation, 0, 0, DirectionEnum.East, pathTravelled);
            map.DisplayResults("** ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void FindPaths(Map map, (int, int) location, int numberOfSteps, int numberOfTurns, DirectionEnum currentlyFacing,
        List<Location> pathTravelled)
    {
        map.GetSearchLocations(location.Item1, location.Item2).ForEach(l =>
        {
            if (map.Grid[l.X, l.Y] == "#" || map.Grid[l.X, l.Y] == "S")
            {
                // Hit a wall or the start location
                return;
            }
            if (pathTravelled.Any(a => a.X == l.X && a.Y == l.Y))
            {
                // Already been here
                return;
            }
            map.Results[l.X, l.Y] = numberOfSteps.ToString();
            pathTravelled.Add(new Location { X = l.X, Y = l.Y });
            numberOfSteps++;
            if (map.Grid[l.X, l.Y] == "E")
            {
                var finalScore = numberOfTurns * 1000 + numberOfSteps;
                Console.WriteLine($"Exit found at {l.X + 1}:{l.Y + 1} after {numberOfSteps} steps {numberOfTurns} turns and with a score of {finalScore}");
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
            if (currentlyFacing != nextDirection)
            {
                numberOfTurns++;
                currentlyFacing = nextDirection;
                //Console.WriteLine($"Turned to face {nextDirection} at {l.X}:{l.Y} after {currentDistance} steps {numberOfTurns} turns");
            }
            var newPathTravelled = new List<Location>(pathTravelled).ToList();
            FindPaths(map, (l.X, l.Y), numberOfSteps, numberOfTurns, currentlyFacing, newPathTravelled);
        });
    }
}