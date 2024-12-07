namespace AdventOfCode.Day5
{
    public class PageOrderingRule
    {
        public int LeftPage { get; set; }
        public int RightPage { get; set; }
        public PageOrderingRule(int leftRule, int rightRule)
        {
            LeftPage = leftRule;
            RightPage = rightRule;
        }
        public bool ArePagesValid(List<int> pages)
        {
            if (!pages.Contains(LeftPage)) return true;
            if (!pages.Contains(RightPage)) return true;
            return pages.IndexOf(LeftPage) < pages.IndexOf(RightPage);
        }
    }
}
