using System.Text.RegularExpressions;

public static class Day03
{
    public static void Execute()
    {
        string filePath = "Day03/Input.txt";
        try
        {
            // Read all lines from the file
            string text = File.ReadAllText(filePath);

            //string pattern = @"mul\((?<firstNumber>[0-9]{1,3}),(?<secondNumber>[0-9]{1,3})\)";
            string pattern = @"do\(\)|don't\(\)|mul\((?<firstNumber>[0-9]{1,3}),(?<secondNumber>[0-9]{1,3})\)";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);
            int runningTotal = 0;
            bool isMultiplicationActive = true;
            foreach (Match match in matches)
            {
                if (match.Value == "do()")
                {
                    isMultiplicationActive = true;
                    continue;
                }
                if (match.Value == "don't()")
                {
                    isMultiplicationActive = false;
                    continue;
                }
                if (!isMultiplicationActive) continue;
                var firstNumber = int.Parse(match.Groups["firstNumber"].Value);
                var secondNumber = int.Parse(match.Groups["secondNumber"].Value);
                runningTotal += firstNumber * secondNumber;
            }
            Console.WriteLine($"The running total is: {runningTotal} from {matches.Count} matches");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}