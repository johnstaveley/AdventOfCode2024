namespace AdventOfCode.Day02
{
    internal class Report
    {
        public int Id { get; set; }
        public List<int> Items { get; set; } = new List<int>();
        public bool IsSafe()
        {
            var isSafe = IsSafe(Items);
            if (isSafe) return true;
            for (int i = 0; i < Items.Count; i++)
            {
                List<int> newItems = Items.GetRange(0, Items.Count);
                newItems.RemoveAt(i);
                isSafe = IsSafe(newItems);
                if (isSafe) return true;
            }
            return false;
        }
        private bool IsSafe(List<int> items)
        {
            var differences = new List<int>();
            var previousValue = items.First();
            foreach (var item in items.Skip(1))
            {
                differences.Add(item - previousValue);
                previousValue = item;
            }
            var rule2 = differences.Select(Math.Abs).All(d => d > 0 && d < 4);
            var rule1 = differences.All(a => a > 0) || differences.All(a => a < 0);
            return rule1 && rule2;
        }
    }
}
