﻿public static class Day01
{
    public static void Execute()
    {
        string filePath = "Day01/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var leftList = new List<int>();
            var rightList = new List<int>();
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var terms = line.Split(" ").Where(a => !string.IsNullOrWhiteSpace(a)).ToList();
                    leftList.Add(int.Parse(terms[0].Trim(' ')));
                    rightList.Add(int.Parse(terms[1].Trim(' ')));
                }
            }
            var sortedLeftList = leftList.OrderBy(a => a).ToList();
            var sortedRightList = rightList.OrderBy(a => a).ToList();
            var differences = new List<int>();
            for (int i = 0; i < sortedLeftList.Count; i++)
            {
                differences.Add(Math.Abs(sortedRightList[i] - sortedLeftList[i]));
            }
            Console.WriteLine($"Total of differences is {differences.Sum()}");
            var totalSimilarityScore = 0;
            foreach(var item in sortedLeftList)
            {
                totalSimilarityScore += sortedRightList.Count(a => a == item) * item;
            }
            Console.WriteLine($"Total similarity score is {totalSimilarityScore}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}