public static class Day4
{
    public static void Execute()
    {
        string filePath = "Day4/Input.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"Read {lines.Length} lines from {filePath}");
            int xmasFound = 0;
            int crossFound = 0;
            var grid = GetGrid(lines);
            var columns = grid.GetLength(0);
            var rows = grid.GetLength(1);
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var currentCharacter = grid[x, y];
                    if (currentCharacter == "X")
                    {
                        var canCheckRight = x < columns - 3;
                        var canCheckLeft = x > 2;
                        var canCheckDown = y < rows - 3;
                        var canCheckUp = y > 2;

                        // Horizontal Right
                        if (canCheckRight && grid[x+1, y] == "M" && grid[x + 2, y] == "A" && grid[x + 3, y] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Horizontal Right at {i},{j}");
                            xmasFound++;
                        }
                        // Horizontal Left
                        if (canCheckLeft && grid[x - 1, y] == "M" && grid[x - 2, y] == "A" && grid[x - 3, y] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Horizontal Left at {i},{j}");
                            xmasFound++;
                        }
                        // Vertical Down
                        if (canCheckDown && grid[x, y + 1] == "M" && grid[x, y + 2] == "A" && grid[x, y + 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Vertical Down at {i},{j}");
                            xmasFound++;
                        }
                        // Vertical Up
                        if (canCheckUp && grid[x, y - 1] == "M" && grid[x, y - 2] == "A" && grid[x, y - 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Vertical Down at {i},{j}");
                            xmasFound++;
                        }
                        // Diagonal Right Down
                        if (canCheckRight && canCheckDown && grid[x + 1, y + 1] == "M" && grid[x + 2, y + 2] == "A" && grid[x + 3, y + 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Diagonal Down Right at {i},{j}");
                            xmasFound++;
                        }
                        // Diagonal Right Up
                        if (canCheckRight && canCheckUp && grid[x + 1, y - 1] == "M" && grid[x + 2, y - 2] == "A" && grid[x + 3, y - 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Diagonal Up Right at {i},{j}");
                            xmasFound++;
                        }
                        // Diagonal Left Down
                        if (canCheckLeft && canCheckDown && grid[x - 1, y + 1] == "M" && grid[x - 2, y + 2] == "A" && grid[x - 3, y + 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Diagonal Down Left at {i},{j}");
                            xmasFound++;
                        }
                        // Diagonal Left Up
                        if (canCheckLeft && canCheckUp && grid[x - 1, y - 1] == "M" && grid[x - 2, y - 2] == "A" && grid[x - 3, y - 3] == "S")
                        {
                            //Console.WriteLine($"Found XMAS Diagonal Up Left at {i},{j}");
                            xmasFound++;
                        }
                    }
                    if (currentCharacter == "A" )
                    {
                        var canCheckLeft = x > 0;
                        var canCheckUp = y > 0;
                        var canCheckRight = x < columns - 1;
                        var canCheckDown = y < rows - 1;
                        if (canCheckRight && canCheckDown && canCheckLeft && canCheckUp) { 
                            var topLeftToBottomRight = grid[x-1, y-1] + currentCharacter + grid[x + 1, y + 1];
                            var topRightToBottomLeft = grid[x + 1, y - 1] + currentCharacter + grid[x - 1, y + 1];
                            if ((topLeftToBottomRight == "SAM" || topLeftToBottomRight == "MAS") && (topRightToBottomLeft == "SAM" || topRightToBottomLeft == "MAS"))
                                {
                                Console.WriteLine($"Found X-MAS Diagonal Down Right at {x+1},{y+1}");
                                crossFound++;
                            }
                        }
                    }                   
                }
            }
            Console.WriteLine($"Part 1 Found {xmasFound} XMAS matches");
            Console.WriteLine($"Part 2 Found {crossFound} X-MAS matches");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    public static string[,] GetGrid(string[] lines)
    {
        var rows = lines.Length;
        var cols = lines.Max(l => l.Length);
        string[,] grid = new string[rows, cols];

        // Populate the 2D grid
        for (int y = 0; y < rows; y++)
        {
            char[] elements = lines[y].ToCharArray();
            for (int x = 0; x < cols; x++)
            {
                grid[x, y] = elements[x].ToString();
            }
        }
        return grid;
    }
}