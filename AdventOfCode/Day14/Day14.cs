using AdventOfCode.Day14;
using System.Text.RegularExpressions;

public static class Day14
{
    public static void Execute()
    {
        string filePath = "Day14/Test.txt";
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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}