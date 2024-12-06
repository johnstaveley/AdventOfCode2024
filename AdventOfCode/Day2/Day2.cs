using AdventOfCode.Day2;

public static class Day2
{
    public static void Execute()
    {
        string filePath = "Day2/Input.txt";
        var reports = new List<Report>();
        var index = 1;
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var report = new Report() { Id = index++ };
                report.Items = line.Split(' ').Select(int.Parse).ToList();
                reports.Add(report);
            }
            var numberOfSafeReports = reports.Count(r => r.IsSafe());
            Console.WriteLine($"Read {reports.Count} reports of which {numberOfSafeReports} are safe");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}