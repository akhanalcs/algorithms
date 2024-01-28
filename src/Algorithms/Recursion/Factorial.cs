namespace Algorithms.Recursion;

public static class Factorial
{
    // If your input is n, the function will make n calls before reaching the base case.
    // Each call does a constant amount of work (one multiplication), so the total time complexity
    // is proportional to the number of calls.
    // Therefore, the time complexity is O(n).
    public static int Calculate(int number)
    {
        // Base case: when the function doesn't call itself again
        if (number == 1)
        {
            return 1;
        }
        // Recursive case: when the function calls itself
        else
        {
            return number * Calculate(number - 1);
        }
    }
}