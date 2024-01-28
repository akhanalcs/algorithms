namespace Algorithms.Sort;

public static class QuickSorter
{
    public static int[] Sort(int[] unSortedData)
    {
        if (unSortedData.Length <= 1) return unSortedData;

        var pivot = unSortedData[0];
        var smaller = unSortedData.Skip(1).Where(x => x <= pivot).ToArray();
        var greater = unSortedData.Skip(1).Where(x => x > pivot).ToArray();

        return Sort(smaller)
            .Concat(new[] { pivot })
            .Concat(Sort(greater))
            .ToArray();
    }
}