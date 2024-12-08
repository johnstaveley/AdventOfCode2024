namespace AdventOfCode.Model
{
    public class Map
    {
        public string[,] Grid { get; set; }
        public string[,] Results { get; set; }

        public Map(string[,] grid)
        {
            Grid = grid;
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
    }
}
