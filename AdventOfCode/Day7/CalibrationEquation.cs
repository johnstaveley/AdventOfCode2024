namespace AdventOfCode.Day7
{
    public class CalibrationEquation
    {
        public Int64 Total { get; set; } = 0;
        public List<Int64> Terms { get; set; } = [];
        public List<string> Operators { get; set; } = [];
        public bool CanBeComputed()
        {
            var possibleOperators = new string[] { "+", "*" };
            Operators = Terms.Select(a => "+").ToList();
            foreach (var op in possibleOperators)
            {
                var operatorIndex = 0;
                var total = Terms.First();
                Operators[operatorIndex] = op;
                foreach (var term in Terms.Skip(1))
                {
                    total = Operators[operatorIndex] == "+" ? total + term : total * term;
                }
                if (total == Total)
                {
                    return true;
                }
                operatorIndex++;
            }
            return false;
        }
    }
}
