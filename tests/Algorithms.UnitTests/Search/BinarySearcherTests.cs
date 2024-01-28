using Algorithms.Search;
namespace Algorithms.UnitTests.Search;

public class BinarySearcherTests
{
    [Test]
    public void BinarySearcher_Finds_Item_Using_Loop()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var myListItem = myList[3];
        var searchedItemIndex = BinarySearcher.FindIndexUsingLoop(myList, myListItem);
        Assert.That(searchedItemIndex, Is.EqualTo(3));
    }

    [Test]
    public void BinarySearcher_Doesnt_Find_Item_Using_Loop()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var searchedItemIndex = BinarySearcher.FindIndexUsingLoop(myList, 10);
        Assert.That(searchedItemIndex, Is.EqualTo(-1));
    }
    
    [Test]
    public void BinarySearcher_Finds_Item_Using_DAndC()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var myListItem = myList[3];
        var searchedItemIndex = BinarySearcher.FindIndexUsingRecursion(myList, myListItem);
        Assert.That(searchedItemIndex, Is.EqualTo(3));
    }

    [Test]
    public void BinarySearcher_Doesnt_Find_Item_Using_DAndC()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var searchedItemIndex = BinarySearcher.FindIndexUsingRecursion(myList, 10);
        Assert.That(searchedItemIndex, Is.EqualTo(-1));
    }
}