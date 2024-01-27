using Algorithms.Sort;

namespace Algorithms.UnitTests.Sort;

public class SelectionSorterTests
{
    [Test]
    public void SelectionSorter_Sorts_Items()
    {
        // Arrange
        int[] unSortedItems = [3, 2, 1, 5, 4];
        int[] sortedItems = [1, 2, 3, 4, 5];
        
        // Act
        SelectionSorter.Sort(unSortedItems);
        
        // Assert
        Assert.That(unSortedItems, Is.EqualTo(sortedItems));
    }
}