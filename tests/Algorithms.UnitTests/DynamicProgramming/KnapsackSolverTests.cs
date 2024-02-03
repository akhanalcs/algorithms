using Algorithms.DynamicProgramming;

namespace Algorithms.UnitTests.DynamicProgramming;

public class KnapsackSolverTests
{
    [Test]
    public void KnapsackSolver_Finds_Optimal_Set_Of_Items()
    {
        // Arrange
        var maxCapacity = 6;
        Item[] items =
        [
            new Item("Water", 3, 10),
            new Item("Book", 1, 3),
            new Item("Food", 2, 9),
            new Item("Jacket", 2, 5),
            new Item("Camera", 1, 6)
        ];
        
        // Act
        var grid = KnapsackSolver.Solve(items, maxCapacity);
        
        var optimalItems = grid[items.Length - 1, maxCapacity].Items.Select(i => i.Name);
        var optimalValue = grid[items.Length - 1, maxCapacity].Value;
        
        // Assert
        CollectionAssert.AreEquivalent(new[] {"Food", "Water", "Camera"}, optimalItems);
        Assert.That(optimalValue, Is.EqualTo(25));
    }
}