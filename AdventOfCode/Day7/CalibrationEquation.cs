namespace AdventOfCode.Day7
{
    public class CalibrationEquation
    {
        public Int64 Total { get; set; } = 0;
        public List<Int64> Terms {  get; set; } = [];
        public bool CanBeComputed()
        {
            return Terms.Sum() == Total;
        }
    }
}
