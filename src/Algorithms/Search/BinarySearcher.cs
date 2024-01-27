namespace Algorithms.Search;

public static class BinarySearcher
{
    // Binary search needs log n operations to check a list of size n
    // So, Time complexity: O(log n)
    // Big O notation tells you the number of operations an algorithm will make
    public static int FindIndex(int[] sortedData,  int item)
    {
        // Low and high keep track of which part of the list you’ll search in.
        var leftIndex = 0;
        var rightIndex = sortedData.Length - 1;

        // While you haven’t narrowed it down to one element
        while (leftIndex <= rightIndex)
        {
            // Check the middle element
            var midIndex = (leftIndex + rightIndex) / 2;
            var guess = sortedData[midIndex];
            
            if (guess == item)
            {
                return midIndex;
            }

            // The guess was too high
            if (guess > item)
            {
                rightIndex = midIndex - 1;
            }
            // The guess was too low
            else
            {
                leftIndex = midIndex + 1;
            }
        }
        
        return -1; // The item does not exist.
    }
}