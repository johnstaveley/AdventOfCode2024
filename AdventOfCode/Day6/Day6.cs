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
            var loopCount = 0;
            map.Grid = ArrayExtensions.GetGrid(lines);
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(0); j++)
                {
                    map.Grid = ArrayExtensions.GetGrid(lines);
                    var guardLocation = map.GuardLocation();
                    if (guardLocation.Item1 == i && guardLocation.Item2 == j) continue;
                    Console.Write($"Placing obstacle at {i:000}:{j:000} ");
                    map.Grid[i, j] = "#";
                    loopCount += ExecuteGuardPath(map) ? 1 : 0;
                }
            }
            Console.WriteLine($"Loop count: {loopCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static bool ExecuteGuardPath(Map map)
    {
        var guard = new Guard();
        var initialGuardLocation = map.GuardLocation();
        guard.LocationX = initialGuardLocation.Item1;
        guard.LocationY = initialGuardLocation.Item2;
        var gameIsOn = true;
        var index = 0;
        var loopDetected = false;
        do
        {
            var nextLocation = guard.NextSquare();
            loopDetected = guard.IsInLoop(index);
            gameIsOn = !map.IsOffGrid(nextLocation) && !loopDetected;
            if (gameIsOn)
            {
                var nextLocationType = map.Grid[nextLocation.Item1, nextLocation.Item2];
                var previousDistinctPositions = guard.DistinctPositions.Count;
                switch (nextLocationType)
                {
                    case "#":
                        guard.TurnsRight();
                        break;
                    default:
                        guard.MovesForward(index++);
                        break;
                }
            }
        } while (gameIsOn);
        Console.WriteLine($"Distinct positions {guard.DistinctPositions.Count + 1}, Loop detected: {loopDetected}");
        return loopDetected;
    }
}