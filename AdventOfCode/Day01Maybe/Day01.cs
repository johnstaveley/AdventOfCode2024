// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day01;

public static class Day1Maybe
{
    public static void Execute()
    {
        string filePath = "Day1/Input.txt";
        var elves = new List<Elf>();
        var index = 1;
        var elf = new Elf() { Id = index++ };
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Print each line to the console
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    elves.Add(elf);
                    elf = new Elf() { Id = index++ };
                    continue;
                } else
                {
                    elf.CaloriesCollected.Add(int.Parse(line));
                }
            }
            foreach (var e in elves)
            {
                Console.WriteLine($"Elf {e.Id} collected {e.TotalCalories} Calories");
            }
            var elvesSortedByCalories = elves.OrderByDescending(e => e.TotalCalories);
            var maxCalories = elves.Max(e => e.TotalCalories);
            var totalOfTopThree = elvesSortedByCalories.Take(3).Sum(e => e.TotalCalories);
            var elfWithMaxCalories = elves.First(e => e.TotalCalories == maxCalories);
            Console.WriteLine($"Elf {elfWithMaxCalories.Id} collected the most calories: {maxCalories}");
            Console.WriteLine($"The total of the top three elves is {totalOfTopThree}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}