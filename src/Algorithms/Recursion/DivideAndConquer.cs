namespace Algorithms.Recursion;

public static class DivideAndConquer
{
    //[1,2,3,4]
    public static int Sum(int[] numbers)
    {
        if (numbers.Length == 0) return 0;

        var firstItem = numbers[0];
        // Range operator to slice the array. Allocates new array
        // numbers[1..] creates a slice of the array starting from element in position 1 until the end
        var remainingItems = numbers[1..];
        return firstItem + Sum(remainingItems);
    }

    public static int Count(int[] numbers)
    {
        if (numbers.Length == 0) return 0;
        return 1 + Count(numbers[1..]);
    }
    
    // 1. Max([2,4,3,1]) // First call
    // 2. Inside first call, maxNumber1 = Max([4,3,1]) // Second call
    // 3. Inside the second call, maxNumber2 = Max([3,1]) // Third call
    // 4. In the third call, it returns the maximum between 3 and 1 which is 3
    // 5. Back in second call, it will compare the first element of [4,3,1] (i.e., 4) with maxNumber2 (i.e., 3), 4 > 3 so it returns 4
    // 6. Now we are back in the first call, it compares the first element of [2,4,3,1] (i.e., 2) with maxNumber1 (i.e., 4), as 2 is not greater than 4, it returns 4
    public static int Max(int[] numbers)
    {
        if (numbers.Length == 2)
        {
            return numbers[0] > numbers[1] ? numbers[0] : numbers[1];
        }
        
        var possibleMax = Max(numbers[1..]);
        return numbers[0] > possibleMax ? numbers[0] : possibleMax;
    }
}