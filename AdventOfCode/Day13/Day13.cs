using AdventOfCode.Day13;
using System.Text.RegularExpressions;

public static class Day13
{
    public static void Execute()
    {
        string filePath = "Day13/Test.txt";
        var regex = new Regex(@"[A-Za-z ]{5,8}: X[+=]([0-9]{1,6}), Y[+=]([0-9]{1,6})");
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var machines = new List<Machine>();
            for ( int i = 0; i < lines.Length; i=i+4)
            {
                var machine = new Machine();
                var matchLine1 = regex.Match(lines[i]);
                machine.ButtonA.X = int.Parse(matchLine1.Groups[1].Value);
                machine.ButtonA.Y = int.Parse(matchLine1.Groups[2].Value);
                var matchLine2 = regex.Match(lines[i + 1]);
                machine.ButtonB.X = int.Parse(matchLine2.Groups[1].Value);
                machine.ButtonB.Y = int.Parse(matchLine2.Groups[2].Value);
                var matchLine3 = regex.Match(lines[i + 2]);
                machine.Prize.X = int.Parse(matchLine3.Groups[1].Value);
                machine.Prize.Y = int.Parse(matchLine3.Groups[2].Value);
                machines.Add(machine);
            }
            Console.WriteLine($"{machines.Count} machines");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}