namespace AdventOfCode.Day6
{
    public class Guard
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public DirectionEnum Direction { get; set; } = DirectionEnum.North;

        public Tuple<int, int> NextSquare()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    return Tuple.Create(LocationX, LocationY - 1);
                case DirectionEnum.East:
                    return Tuple.Create(LocationX + 1, LocationY);
                case DirectionEnum.South:
                    return Tuple.Create(LocationX, LocationY + 1);
                case DirectionEnum.West:
                    return Tuple.Create(LocationX - 1, LocationY);
                default:
                    throw new NotImplementedException();
            }
        }
        public void MovesForward()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    LocationY = LocationY - 1;
                    break;
                case DirectionEnum.East:
                    LocationX = LocationX + 1;
                    break;
                case DirectionEnum.South:
                    LocationY = LocationY + 1;
                    break;
                case DirectionEnum.West:
                    LocationX = LocationX - 1;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public void TurnsRight()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    Direction = DirectionEnum.East;
                    break;
                case DirectionEnum.East:
                    Direction = DirectionEnum.South;
                    break;
                case DirectionEnum.South:
                    Direction = DirectionEnum.West;
                    break;
                case DirectionEnum.West:
                    Direction = DirectionEnum.North;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
