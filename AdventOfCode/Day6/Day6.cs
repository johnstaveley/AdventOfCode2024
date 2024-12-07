﻿using AdventOfCode.Day6;
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
            var gameIsOn = true;
            var index = 0;
            do
            {
                var nextLocation = guard.NextSquare();
                gameIsOn = !map.IsOffGrid(nextLocation) && !guard.IsInLoop(index);
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
            Console.WriteLine($"Distinct positions {guard.DistinctPositions.Count + 1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}