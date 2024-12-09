using AdventOfCode.Day09;
using AdventOfCode.Utility;

public static class Day09
{
    public static void Execute()
    {
        string filePath = "Day09/Test.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            var diskmap = lines[0].ToCharArray().Select(a => int.Parse(a.ToString())).ToList();
            var currentId = 0;
            var isBlock = true;
            var blocks = new List<int?>();
            var indices = new List<FileIndex>();
            foreach (var sizeOnDisk in diskmap)
            {
                if (isBlock)
                {
                    indices.Add(new FileIndex { Id = currentId, Index = blocks.Count + 1, IsBlock = true, Size = sizeOnDisk });
                    blocks.AddRange(Enumerable.Repeat((int?)currentId, sizeOnDisk));
                    currentId++;
                }
                else
                {
                    indices.Add(new FileIndex { Id = null, Index = blocks.Count + 1, IsBlock = false, Size = sizeOnDisk });
                    blocks.AddRange(Enumerable.Repeat((int?)null, sizeOnDisk));
                }
                isBlock = !isBlock;
            }
            PrintBlocks(blocks);
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                var currentBlock = blocks[i];
                if (currentBlock.HasValue)
                {
                    var locationOfFirstNull = blocks.IndexOf(null);
                    if (locationOfFirstNull < i)
                    {
                        blocks.Swap(i, locationOfFirstNull);
                        PrintBlocks(blocks);
                    }
                }
            }
            /*            for (int index = indices.Count - 1; index >= 0; index--)
                        {
                            var currentIndex = indices[index];
                            if (currentIndex.IsBlock) {
                                var indexToMoveTo = indices.FirstOrDefault(a => !a.IsBlock && a.Size >= currentIndex.Size);
                                if (indexToMoveTo != null && index > indexToMoveTo.Index)
                                {
                                    // Swap index
                                    indices.Swap(index, indexToMoveTo.Index);
                                    // SWap values on disk
                                    for (int j = 0; j < currentIndex.Size; j++)
                                    {
                                        blocks.Swap(currentIndex.Index + j - 1, indexToMoveTo.Index + j - 1);
                                    }
                                    PrintBlocks(blocks);
                                }
                            }
                        }
                        PrintBlocks(blocks);*/
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