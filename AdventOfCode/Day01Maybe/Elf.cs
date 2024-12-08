namespace AdventOfCode.Day1
{
    public class Elf
    {
        public int Id { get; set; }
        public List<int> CaloriesCollected { get; set; } = [];
        public int TotalCalories => CaloriesCollected.Sum();
    }
}
