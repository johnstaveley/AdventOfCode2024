using AdventOfCode.Day14;
using AdventOfCode.Model;
using System.Text.RegularExpressions;

public static class Day14
{
    public static void Execute()
    {
        string filePath = "Day14/Input.txt";
        var regex = new Regex(@"p=([0-9]{1,3}),([0-9]{1,3}) v=([\-0-9]{1,3}),([\-0-9]{1,3})");
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var robots = new List<Robot>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    var robot = new Robot
                    {
                        X = int.Parse(match.Groups[1].Value),
                        Y = int.Parse(match.Groups[2].Value),
                        VX = int.Parse(match.Groups[3].Value),
                        VY = int.Parse(match.Groups[4].Value)
                    };
                    robots.Add(robot);
                }
            }
            Console.WriteLine($"Read {robots.Count} robots");
            var map = new Map(103, 101, "0");
            var numberOfTurns = 100;
            for (int i = 0; i < numberOfTurns; i++)
            {
                foreach (var robot in robots)
                {
                    robot.Move();
                    if (map.IsOffGrid(robot.X, robot.Y))
                    {
                        if (robot.X < 0)
                        {
                            robot.X += map.Grid.GetLength(0);
                        }
                        if (robot.X >= map.Grid.GetLength(0))
                        {
                            robot.X -= map.Grid.GetLength(0);
                        }
                        if (robot.Y < 0)
                        {
                            robot.Y += map.Grid.GetLength(1);
                        }
                        if (robot.Y >= map.Grid.GetLength(1))
                        {
                            robot.Y -= map.Grid.GetLength(1);
                        }
                    }
                    //Console.WriteLine($"Robot {robot.X+1}:{robot.Y+1} on turn {i+1}");
                }
            }
            foreach (var robot in robots)
            {
                var currentRobots = int.Parse(map.Grid[robot.X, robot.Y]);
                currentRobots++;
                map.Grid[robot.X, robot.Y] = currentRobots.ToString();
            }
            map.Display();
            var halfWayX = map.Grid.GetLength(0) / 2;
            var halfWayY = map.Grid.GetLength(1) / 2;
            Console.WriteLine($"Halfway point is {halfWayX}:{halfWayY}");
            var quadrantTopLeft = 0;
            var quadrantTopRight = 0;
            var quadrantBottomLeft = 0;
            var quadrantBottomRight = 0;
            foreach (var robot in robots)
            {
                if (robot.X < halfWayX && robot.Y < halfWayY)
                {
                    quadrantTopLeft++;
                }
                if (robot.X > halfWayX && robot.Y < halfWayY)
                {
                    quadrantTopRight++;
                }
                if (robot.X < halfWayX && robot.Y > halfWayY)
                {
                    quadrantBottomLeft++;
                }
                if (robot.X > halfWayX && robot.Y > halfWayY)
                {
                    quadrantBottomRight++;
                }
            }
            Console.WriteLine($"Top left: {quadrantTopLeft}");
            Console.WriteLine($"Top right: {quadrantTopRight}");
            Console.WriteLine($"Bottom left: {quadrantBottomLeft}");
            Console.WriteLine($"Bottom right: {quadrantBottomRight}");
            var safetyFactor = quadrantTopLeft * quadrantTopRight * quadrantBottomLeft * quadrantBottomRight;
            Console.WriteLine($"Safety factor: {safetyFactor}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}