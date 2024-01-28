using Algorithms.Sort;

namespace Algorithms.UnitTests.Sort;

public class QuickSorterTests
{
    [Test]
    public void QuickSorter_Sorts_Items()
    {
        // Arrange
        int[] unSortedData = [3, 2, 1, 5, 4];
        int[] sortedItems = [1, 2, 3, 4, 5];
        // Act
        var result = QuickSorter.Sort(unSortedData);
        // Assert
        Assert.That(result, Is.EqualTo(sortedItems));
    }
}