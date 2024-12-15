using AdventOfCode.Model;

namespace AdventOfCode.Day15
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void FindInitialLocation(string[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == "@")
                    {
                        X = i;
                        Y = j;
                        return;
                    }
                }
            }
        }
        public void Move(string movement, Map map)
        {
            var dx = 0;
            var dy = 0;
            var grid = map.Grid;
            Console.WriteLine($"Moving {movement}");
            switch (movement)
            {
                case "^":
                    dy--;
                    break;
                case "v":
                    dy++;
                    break;
                case "<":
                    dx--;
                    break;
                case ">":
                    dx++;
                    break;
            }
            var nextLocation = grid[X + dx, Y + dy];
            if (nextLocation == "#")
            {
                Console.WriteLine($"Can't move to {X + dx + 1}, {Y + dy + 1}");
                return;
            }
            if (nextLocation == ".")
            {
                grid[X, Y] = ".";
                X += dx;
                Y += dy;
                grid[X, Y] = "@";
                Console.WriteLine($"Moved to {X + 1}, {Y + 1}");
                return;
            }
            var maxPush = Math.Max(grid.GetLength(0), grid.GetLength(1));
            // Find the next empty space
            var push = 0;
            for (int i = 1; i <= maxPush; i++)
            {
                var nextX = X + dx * i;
                var nextY = Y + dy * i;
                if (map.IsOffGrid(nextX, nextY))
                {
                    break;
                }
                if (grid[nextX, nextY] == "#")
                {
                    break;
                }
                if (grid[nextX, nextY] == ".")
                {
                    push = i;
                    break;
                }
            }
            if (push > 0)
            {
                for (int i = 1; i <= push; i++)
                {
                    var nextX = X + dx * i;
                    var nextY = Y + dy * i;
                    grid[X + dx * i, Y + dy * i] = "O";
                }
                grid[X, Y] = ".";
                X += dx;
                Y += dy;
                grid[X, Y] = "@";
                Console.WriteLine($"Pushed at {X + 1}, {Y + 1}");
            } else
            {
                Console.WriteLine($"Can't move");
            }
        }
    }
}
