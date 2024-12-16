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
            var robotLocation = map.Find("S");
            var exitLocation = map.Find("E");
            Console.WriteLine($"Robot is at {robotLocation.Item1+1}:{robotLocation.Item2+1}");
            Console.WriteLine($"Exit is at {exitLocation.Item1+1}:{exitLocation.Item2+1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}