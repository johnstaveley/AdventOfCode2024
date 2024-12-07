using AdventOfCode.Day7;

public static class Day7
{
    public static void Execute()
    {
        string filePath = "Day7/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var equations = new List<CalibrationEquation>();
            var totalEquationsCalculated = 0;
            foreach (var line in lines)
            {
                var equation = new CalibrationEquation();
                var terms = line.Split(':');
                equation.Total = Int64.Parse(terms[0]);
                equation.Terms = terms[1].Split(' ').Where(a => !string.IsNullOrEmpty(a)).Select(b => Int64.Parse(b.Trim(' '))).ToList();
                equations.Add(equation);
                totalEquationsCalculated += equation.CanBeComputed() ? 1 : 0;
            }
            foreach (var equation in equations)
            {
                Console.WriteLine($"Equation: {equation.Total} = {equation.CanBeComputed()}");
            }
            Console.WriteLine($"Total Equations which can be calculated: {totalEquationsCalculated} out of {equations.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}