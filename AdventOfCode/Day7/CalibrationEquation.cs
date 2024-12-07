namespace AdventOfCode.Day7
{
    public class CalibrationEquation
    {
        private string[] _possibleOperators = ["+", "*"];

        public Int64 Total { get; set; } = 0;
        public List<Int64> Terms { get; set; } = [];
        public List<string> Operators { get; set; } = [];
        public bool CanBeComputed()
        {
            var currentIndexOfOperator = 0;
            Operators = Terms.Select(a => "+").ToList();
            if (CanBeComputed(Operators, currentIndexOfOperator))
            {
                return true;
            }
            return false;
        }
        private bool CanBeComputed(List<string> operators, int currentIndexOfOperator)
        {
            var total = Terms.First();
            var localOperators = operators.GetRange(0, operators.Count);
            foreach (var op in _possibleOperators)
            {
                localOperators[currentIndexOfOperator] = op;
                for (var i = 1; i < Terms.Count; i++)
                {
                    total = localOperators[i - 1] == "+" ? total + Terms[i] : total * Terms[i];
                }
                if (total == Total)
                {
                    return true;
                }
                if (currentIndexOfOperator < operators.Count - 1)
                {
                    if (CanBeComputed(localOperators, currentIndexOfOperator + 1))
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
