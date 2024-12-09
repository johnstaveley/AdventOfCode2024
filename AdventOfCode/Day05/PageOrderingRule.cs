using AdventOfCode.Utility;

namespace AdventOfCode.Day05
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
        public List<int> ApplyRule(List<int> pages)
        {
            if (ArePagesValid(pages)) return pages;
            var newList = pages;
            do
            {
                var indexOfRightPage = pages.IndexOf(RightPage);
                newList.Swap(indexOfRightPage, indexOfRightPage + 1);
            }
            while (!ArePagesValid(newList));
            return newList;
        }

    }
}
