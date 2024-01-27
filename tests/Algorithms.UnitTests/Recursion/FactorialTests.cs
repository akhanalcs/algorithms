using Algorithms.Recursion;

namespace Algorithms.UnitTests.Recursion;

public class FactorialTests
{
    [Test]
    public void Factorial_Calculates_Factorial()
    {
        Assert.That(Factorial.Calculate(5), Is.EqualTo(120));
    }
}