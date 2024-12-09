using AdventOfCode.Day07;

public static class Day07
{
    public static void Execute()
    {
        string filePath = "Day07/Test2.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var equations = new List<CalibrationEquation>();
            var totalEquationsCalculated = 0;
            Int64 totalCalibrationResult = 0;
            foreach (var line in lines)
            {
                var equation = new CalibrationEquation();
                var terms = line.Split(':');
                equation.Total = Int64.Parse(terms[0]);
                equation.Terms = terms[1].Split(' ').Where(a => !string.IsNullOrEmpty(a)).Select(b => Int64.Parse(b.Trim(' '))).ToList();
                equations.Add(equation);
                var canBeComputed = equation.CanBeComputed();
                if (canBeComputed)
                {
                    totalEquationsCalculated += 1;
                    totalCalibrationResult += equation.Total;
                }

            }
            foreach (var equation in equations)
            {
                Console.WriteLine($"Equation: {equation.Total} = {equation.CanBeComputed()}");
            }
            Console.WriteLine($"Total Equations which can be calculated: {totalEquationsCalculated} out of {equations.Count} with calibration result: {totalCalibrationResult}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}