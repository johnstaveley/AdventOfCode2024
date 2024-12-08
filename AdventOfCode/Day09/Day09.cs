public static class Day09
{
    public static void Execute()
    {
        string filePath = "Day09/Input.txt";
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