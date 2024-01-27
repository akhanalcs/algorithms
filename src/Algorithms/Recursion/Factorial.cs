namespace Algorithms.Recursion;

public static class Factorial
{
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