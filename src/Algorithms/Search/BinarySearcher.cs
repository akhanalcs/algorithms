namespace Algorithms.Search;

public static class BinarySearcher
{
    // Binary search needs log n operations to check a list of size n
    // So, Time complexity: O(log n)
    // Big O notation tells you the number of operations an algorithm will make
    public static int FindIndexUsingLoop(int[] sortedData, int item)
    {
        // leftIndex and rightIndex keep track of which part of the array you’ll search in.
        var leftIndex = 0;
        var rightIndex = sortedData.Length - 1;

        // While you haven’t narrowed it down to one element
        while (leftIndex <= rightIndex)
        {
            // Check the middle element
            var midIndex = (leftIndex + rightIndex) / 2;
            var guess = sortedData[midIndex];
            
            if (guess == item) return midIndex;

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

    //[1, 3, 5, 7, 9]
    public static int FindIndexUsingRecursion(int[] sortedItems, int item)
    {
        // Base case
        if (sortedItems.Length == 0) return -1;
        
        var midIndex = sortedItems.Length / 2;
        var guess = sortedItems[midIndex];

        if (guess == item)
        {
            return midIndex;
        }
        
        // Recursive cases
        // 1. Throw away the right half and search again
        if (guess > item)
        {
            var leftHalf = sortedItems[..midIndex]; // Upper index is not included, so it has elements from start to midIndex - 1
            return FindIndexUsingRecursion(leftHalf, item);
        }
        
        // 2. Throw away the left half and search again
        var rightHalf = sortedItems[(midIndex + 1)..];
        var result = FindIndexUsingRecursion(rightHalf, item);
        // The returned index should be offset by midIndex + 1 for right half search
        return result == -1 ? -1 : midIndex + 1 + result;
    }
}