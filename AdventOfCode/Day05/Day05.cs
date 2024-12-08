using AdventOfCode.Day5;

public static class Day05
{
    public static void Execute()
    {
        string filePath = "Day05/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var pageOrderingRules = new List<PageOrderingRule>();
            string line = "";
            var i = 0;
            for (i = 0; i < lines.Length; i++)
            {
                line = lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    var orderingRule = line.Split("|");
                    pageOrderingRules.Add(new PageOrderingRule(int.Parse(orderingRule[0]), int.Parse(orderingRule[1])));
                } else
                {
                    break;
                }
            }
            Console.WriteLine($"{pageOrderingRules.Count} page ordering rules received");
            var updateIndexStart = i + 1;
            var updates = new List<Update>();
            for (i = updateIndexStart; i < lines.Length; i++)
            {
                line = lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    var pagesForUpdate = line.Split(",");
                    var update = new Update { Pages = pagesForUpdate.Select(a => int.Parse(a)).ToList() };
                    updates.Add(update);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"{updates.Count} updates received");
            foreach (var update in updates)
            {
                var applicableRules = pageOrderingRules.Where(a => update.Pages.Contains(a.LeftPage) && update.Pages.Contains(a.RightPage)).ToList();
                if (applicableRules.Count() > 0)
                {
                    foreach (var rule in applicableRules)
                    {
                        var isRuleValid = rule.ArePagesValid(update.Pages);
                        if (!isRuleValid) update.IsCorrectlyOrdered = false;
                    }
                }
            }
            var areValid = updates.Count(a => a.IsCorrectlyOrdered);
            Console.WriteLine($"{areValid} of {updates.Count} are valid");
            var middlePageCount = 0;
            foreach (var update in updates.Where(a => a.IsCorrectlyOrdered).ToList())
            {
                var middlePageIndex = ((int) update.Pages.Count / 2);
                middlePageCount += update.Pages[middlePageIndex];
            }
            Console.WriteLine($"Total middle page count of correctly ordered is {middlePageCount}");
            middlePageCount = 0;
            foreach (var update in updates.Where(a => !a.IsCorrectlyOrdered).ToList())
            {
                var applicableRules = pageOrderingRules.Where(a => update.Pages.Contains(a.LeftPage) && update.Pages.Contains(a.RightPage)).ToList();
                if (applicableRules.Count() > 0)
                {
                    var newList = update.Pages;
                    foreach (var rule in applicableRules)
                    {
                        newList = rule.ApplyRule(newList);
                    }
                    foreach (var rule in applicableRules)
                    {
                        newList = rule.ApplyRule(newList);
                    }
                    foreach (var rule in applicableRules)
                    {
                        newList = rule.ApplyRule(newList);
                    }
                    foreach (var rule in applicableRules)
                    {
                        newList = rule.ApplyRule(newList);
                    }
                    foreach (var rule in applicableRules)
                    {
                        newList = rule.ApplyRule(newList);
                    }
                    update.Pages = newList;
                }
                var middlePageIndex = ((int)update.Pages.Count / 2);
                middlePageCount += update.Pages[middlePageIndex];
            }
            Console.WriteLine($"Total middle page count of incorrectly ordered is {middlePageCount}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}