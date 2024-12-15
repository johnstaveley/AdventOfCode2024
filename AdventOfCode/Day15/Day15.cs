using AdventOfCode.Model;

public static class Day15
{
    public static void Execute()
    {
        string filePath = "Day15/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var emptyLine = lines.First(a => string.IsNullOrWhiteSpace(a));
            var mapLines = lines.TakeWhile(a => !string.IsNullOrEmpty(a)).ToArray();
            var map = new Map(mapLines);
            map.Display();
            var movementLines = string.Join("", lines.Where(a => a.Contains("<") || a.Contains(">")).ToArray());
            var movements = movementLines.ToArray().ToList();
            Console.WriteLine(movements.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}