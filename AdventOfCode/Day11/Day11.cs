using AdventOfCode.Day10;
using AdventOfCode.Model;

public static class Day11
{
    public static void Execute()
    {
        string filePath = "Day11/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
   
}