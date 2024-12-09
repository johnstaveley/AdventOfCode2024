namespace AdventOfCode.Day06
{
    public class Position
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int IndexVisited { get; set; }
        public Position(int locationX, int locationY, int index)
        {
            LocationX = locationX;
            LocationY = locationY;
            IndexVisited = index;
        }
    }
}
