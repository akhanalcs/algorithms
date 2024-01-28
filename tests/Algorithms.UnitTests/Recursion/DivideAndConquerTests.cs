using Algorithms.Recursion;

namespace Algorithms.UnitTests.Recursion;

public class DivideAndConquerTests
{
    [Test]
    public void Sum_Using_DAndC()
    {
        // Arrange
        int[] items = [1, 2, 3, 4, 5];
        // Act
        var sum = DivideAndConquer.Sum(items);
        // Assert
        Assert.That(sum, Is.EqualTo(15));
    }

    [Test]
    public void Count_Using_DAndC()
    {
        // Arrange
        int[] items = [1, 2, 3, 4, 5];
        // Act
        var count = DivideAndConquer.Count(items);
        // Assert
        Assert.That(count, Is.EqualTo(5));
    }
    
    [Test]
    public void Max_Using_DAndC()
    {
        // Arrange
        int[] items = [5, 1, 3, 2, 4];
        // Act
        var max = DivideAndConquer.Max(items);
        // Assert
        Assert.That(max, Is.EqualTo(5));
    }
    
    [Test]
    public void BinarySearcher_Finds_Item_Using_DAndC()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var myListItem = myList[3];
        var searchedItemIndex = DivideAndConquer.BinarySearcher(myList, myListItem);
        Assert.That(searchedItemIndex, Is.EqualTo(3));
    }

    [Test]
    public void BinarySearcher_Doesnt_Find_Item_Using_DAndC()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var searchedItemIndex = DivideAndConquer.BinarySearcher(myList, 10);
        Assert.That(searchedItemIndex, Is.EqualTo(-1));
    }
}