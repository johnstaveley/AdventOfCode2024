using AdventOfCode.Utility;

public static class Day09
{
    public static void Execute()
    {
        string filePath = "Day09/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var diskmap = lines[0].ToCharArray().Select(a => int.Parse(a.ToString())).ToList();
            var currentId = 0;
            var isBlock = true;
            var blocks = new List<int?>();
            foreach(var item in diskmap)
            {
                if (isBlock)
                {
                    blocks.AddRange(Enumerable.Repeat((int?) currentId, item));
                    currentId++;
                }
                else
                {
                    blocks.AddRange(Enumerable.Repeat((int?) null, item));
                }
                //if (currentId == 10) currentId = 0;
                isBlock = !isBlock;
            }
            //PrintBlocks(blocks);
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                var currentBlock = blocks[i];
                if (currentBlock.HasValue)
                {
                    var locationOfFirstNull = blocks.IndexOf(null);
                    if (locationOfFirstNull < i) {
                        blocks.Swap(i, locationOfFirstNull);
                        //PrintBlocks(blocks);
                    }
                }
            }
            //PrintBlocks(blocks);
            Console.WriteLine($"Checksum: {GetChecksum(blocks)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void PrintBlocks(List<int?> blocks)
    {
        foreach (var block in blocks)
        {
            Console.Write(block?.ToString() ?? ".");
        }
        Console.WriteLine();
    }
    private static Int64 GetChecksum(List<int?> blocks)
    {
        Int64 checkSum = 0;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].HasValue)
            {
                checkSum += i * blocks[i].Value;
            }
        }
        return checkSum;
    }
}