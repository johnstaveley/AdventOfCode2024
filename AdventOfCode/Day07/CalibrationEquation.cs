namespace AdventOfCode.Day07
{
    public class CalibrationEquation
    {
        private string[] _possibleOperators = ["+", "*", "||"];

        public Int64 Total { get; set; } = 0;
        public List<Int64> Terms { get; set; } = [];
        public List<string> Operators { get; set; } = [];
        public bool CanBeComputed()
        {
            var currentIndexOfOperator = 0;
            Operators = Terms.Skip(1).Select(a => "+").ToList();
            if (CanBeComputed(Terms, Operators, currentIndexOfOperator))
            {
                return true;
            }
            return false;
        }
        private bool CanBeComputed(List<Int64> terms, List<string> operators, int currentIndexOfOperator)
        {
            var localTerms = terms.GetRange(0, terms.Count);
            var localOperators = operators.GetRange(0, operators.Count);
            for (var i = 0; i < localOperators.Count; i++)
            {
                if (localOperators[i] == "||")
                {
                    var nextTerm = localTerms[i + 1];
                    localTerms[i] = Int64.Parse(localTerms[i].ToString() + nextTerm.ToString());
                    localTerms.RemoveAt(i + 1);
                    localOperators.RemoveAt(i);
                }
            }
            var total = terms.First();
            foreach (var op in _possibleOperators)
            {
                localOperators[currentIndexOfOperator] = op;
                for (var i = 1; i < localTerms.Count; i++)
                {
                    switch (localOperators[i - 1])
                    {
                        case "+":
                            total += localTerms[i];
                            break;
                        case "*":
                            total *= localTerms[i];
                            break;
                    }
                }
                if (total == Total)
                {
                    return true;
                }
                if (currentIndexOfOperator < operators.Count - 1)
                {
                    if (CanBeComputed(localTerms, localOperators, currentIndexOfOperator + 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
