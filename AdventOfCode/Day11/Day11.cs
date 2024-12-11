public static class Day11
{
    public static void Execute()
    {
        string filePath = "Day11/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var numbers = lines[0].Split(' ').Select(Int64.Parse).ToList();
            var numberOfIterations = 25;
            Console.WriteLine($"Numbers {string.Join(", ", numbers)} after 0 iterations with {numbers.Count} stones");
            for (Int64 i = 0; i < numberOfIterations; i++)
            {
                numbers = Process(numbers);
                Console.WriteLine($"Result: {string.Join(", ", numbers)} after {i + 1} iterations with {numbers.Count} stones");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static List<Int64> Process(List<Int64> numbers)
    {
        var newList = new List<Int64>();
        foreach (var number in numbers)
        {
            var length = number.ToString().Length;
            if (number == 0)
            {
                newList.Add(1);
            }
            else if (length % 2 == 0)
            {
                var half = length / 2;
                var first = number.ToString().Substring(0, half);
                var second = number.ToString().Substring(half);
                newList.Add(Int64.Parse(first));
                newList.Add(Int64.Parse(second));
            }
            else
            {
                newList.Add(number * 2024);
            }
        }
        return newList;
    }
}