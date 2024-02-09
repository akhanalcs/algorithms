using Algorithms.Trees;

namespace Algorithms.UnitTests.Trees;

public class BinarySearchTreeTests
{
    [Test]
    public void BST_Can_Add_And_Retrieve_Items()
    {
        // Arrange
        var bst = new BinarySearchTree<int>(5);
        
        // Act
        bst.Add(7);
        bst.Add(3);
        bst.Add(6);
        var allElements = bst.GetAllElements();

        // Assert
        CollectionAssert.AreEqual(allElements, new[] { 3, 5, 6, 7 });
    }
    
    [Test]
    public void BST_Can_Find_Item()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        
        // Act
        bst.Add(5);
        bst.Add(7);
        bst.Add(3);
        bst.Add(6);
        var searchedItem = bst.Find(3)!;

        // Assert
        Assert.That(searchedItem.Value, Is.EqualTo(3));
    }
}