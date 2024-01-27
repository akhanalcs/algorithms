namespace Algorithms.Sort;

public static class SelectionSorter
{
    // [3, 2, 1, 5, 4]
    public static void Sort(int[] unSortedData)
    {
        for (var i = 0; i < unSortedData.Length; i++)
        {
            // We start saying that the first item is the smallest
            var smallestIndex = i;
            // And go through the rest of the items by comparing it to the unSortedData[smallestIndex] item
            // If we find a new item that's smaller, we update our index to point to it
            // At the end of this loop, we have smallest item
            for (var j = i + 1; j < unSortedData.Length; j++)
            {
                if (unSortedData[j] < unSortedData[smallestIndex])
                {
                    smallestIndex = j;
                }
            }
            
            // Swap the smallest item with the current item
            (unSortedData[i], unSortedData[smallestIndex]) = (unSortedData[smallestIndex], unSortedData[i]);
            
            // The above thing is same as below:
            // var temp = unSortedData[i];
            // unSortedData[i] = unSortedData[smallestIndex];
            // unSortedData[smallestIndex] = temp;
        }
    }

    // Not being used at the moment
    // [3, 2, 1, 5, 4]
    private static int FindSmallestIndex(int[] unSortedData)
    {
        var smallestIndex = 0;

        for (var i = 1; i < unSortedData.Length; i++)
        {
            if (unSortedData[i] < unSortedData[smallestIndex])
            {
                smallestIndex = i;
            }
        }

        return smallestIndex;
    }
}