using AdventOfCode.Day6;
using AdventOfCode.Utility;

public static class Day6
{
    public static void Execute()
    {
        string filePath = "Day6/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var map = new Map();
            map.Grid = ArrayExtensions.GetGrid(lines);
            var guard = new Guard();
            var initialGuardLocation = map.GuardLocation();
            guard.LocationX = initialGuardLocation.Item1;
            guard.LocationY = initialGuardLocation.Item2;
            Console.WriteLine($"Guard location is {guard.LocationX}:{guard.LocationY}");
            var distinctPositions = 1;
            var gameIsOn = true;
            do
            {
                var nextLocation = guard.NextSquare();
                gameIsOn = !map.IsOffGrid(nextLocation);
                if (gameIsOn)
                {
                    var nextLocationType = map.Grid[nextLocation.Item1, nextLocation.Item2];
                    switch (nextLocationType)
                    {
                        case "#":
                            guard.TurnsRight();
                            break;
                        default:
                            guard.MovesForward();
                            distinctPositions++;
                            break;
                    }
                }
            } while (gameIsOn);
            Console.WriteLine($"Distinct positions {distinctPositions}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}