namespace AdventOfCode.Utility
{
    public static class ArrayExtensions
    {
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
}
