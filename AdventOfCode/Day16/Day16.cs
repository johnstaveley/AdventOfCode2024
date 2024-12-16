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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static void FindPaths(Map map, (int, int) location, int numberOfSteps, int numberOfTurns, DirectionEnum currentlyFacing,
        List<Location> pathTravelled)
    {
        map.GetSearchLocations(location.Item1, location.Item2).ForEach(nextStep =>
        {
            if (map.Grid[nextStep.X, nextStep.Y] == "#" || map.Grid[nextStep.X, nextStep.Y] == "S")
            {
                // Hit a wall or the start location
                return;
            }
            if (pathTravelled.Any(a => a.X == nextStep.X && a.Y == nextStep.Y))
            {
                // Already been here
                return;
            }
            pathTravelled.Add(new Location { X = nextStep.X, Y = nextStep.Y });
            numberOfSteps++;
            if (map.Grid[nextStep.X, nextStep.Y] == "E")
            {
                // Found exit
                var finalScore = numberOfTurns * 1000 + numberOfSteps;
                Console.WriteLine($"Exit found at {nextStep.X + 1}:{nextStep.Y + 1} after {numberOfSteps} steps {numberOfTurns} turns and with a score of {finalScore}");
                return;
            }
            var nextDirection = DirectionEnum.North;
            if (nextStep.Y < location.Item2)
            {
                nextDirection = DirectionEnum.North;
            }
            if (nextStep.Y > location.Item2)
            {
                nextDirection = DirectionEnum.South;
            }
            if (nextStep.X < location.Item1)
            {
                nextDirection = DirectionEnum.West;
            }
            if (nextStep.X > location.Item1)
            {
                nextDirection = DirectionEnum.East; 
            }
            if (currentlyFacing != nextDirection)
            {
                numberOfTurns++;
                currentlyFacing = nextDirection;
                //Console.WriteLine($"Turned to face {nextDirection} at {l.X}:{l.Y} after {currentDistance} steps {numberOfTurns} turns");
            }
            var newPathTravelled = new List<Location>();
            foreach (var item in pathTravelled)
            {
                newPathTravelled.Add(new Location { X = item.X, Y = item.Y });
            }
            FindPaths(map, (nextStep.X, nextStep.Y), numberOfSteps, numberOfTurns, currentlyFacing, newPathTravelled);
        });
    }
}