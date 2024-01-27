using Algorithms.Search;
namespace Algorithms.UnitTests.Search;

public class BinarySearcherTests
{
    [Test]
    public void BinarySearcher_Finds_Item()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var myListItem = myList[3];
        var searchedItemIndex = BinarySearcher.FindIndex(myList, myListItem);
        Assert.That(searchedItemIndex, Is.EqualTo(3));
    }

    [Test]
    public void BinarySearcher_Doesnt_Find_Item()
    {
        int[] myList = [1, 3, 5, 7, 9];
        var searchedItemIndex = BinarySearcher.FindIndex(myList, 10);
        Assert.That(searchedItemIndex, Is.EqualTo(-1));
    }
}