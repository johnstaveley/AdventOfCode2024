using AdventOfCode.Day10;
using AdventOfCode.Utility;

namespace AdventOfCode.Model
{
    public class Map
    {
        public List<Location> GetSearchLocations(int i, int j)
        {
            return new List<Location>
                {
                    new Location { X = i - 1, Y = j },
                    new Location { X = i + 1, Y = j },
                    new Location { X = i, Y = j - 1 },
                    new Location { X = i, Y = j + 1 }
                };
        }
        public string[,] Grid { get; set; }
        public string[,] Results { get; set; }

        public Map(int rows, int cols, string initialString = "")
        {
            Grid = new string[cols, rows];
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Grid[x, y] = initialString;
                }
            }
            Results = new string[Grid.GetLength(0), Grid.GetLength(1)];
        }
        public Map(string[] lines)
        {
            Grid = ArrayExtensions.GetGrid(lines);
            Results = new string[Grid.GetLength(0), Grid.GetLength(1)];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Results[i, j] = "";
                }
            }
        }
        public bool IsOffGrid(int locationX, int locationY)
        {
            return locationX < 0 || locationX >= Grid.GetLength(0) || locationY < 0 || locationY >= Grid.GetLength(1);
        }
        public void Display()
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                for (int i = 0; i < Grid.GetLength(0); i++)
                {
                    Console.Write(Grid[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void DisplayResults(string blank)
        {
            for (int j = 0; j < Results.GetLength(1); j++)
            {
                for (int i = 0; i < Results.GetLength(0); i++)
                {
                    if (Results[i, j] == "")
                    {
                        Console.Write(blank);
                    }
                    else
                    {
                        Console.Write(int.Parse(Results[i, j]).ToString("D2") + " ");
                    }                    
                }
                Console.WriteLine();
            }
        }
        public (int,int) FindFirst(string target)
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i, j] == target)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }
        public void InitialiseResultsGrid(string initial = "")
        {
            Results = new string[Grid.GetLength(0), Grid.GetLength(1)];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Results[i, j] = initial;
                }
            }
        }
    }
}
