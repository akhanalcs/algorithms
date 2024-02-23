namespace Algorithms.UnitTests.Trees;

// Built in min-heap implementation in .NET: PriorityQueue<TElement,TPriority> Class
public class BinaryHeapTests
{
    [Test]
    public void BinaryMinHeap_Returns_Items_In_Ascending_Order()
    {
        // Arrange
        var pq = new PriorityQueue<string, int>();
        pq.Enqueue("internet", 5);
        pq.Enqueue("food", 9);
        pq.Enqueue("water", 10);
        
        // Act
        var lowestPriorityItem = pq.Dequeue();
        
        // Assert
        Assert.That(lowestPriorityItem, Is.EqualTo("internet"));
    }
    
    [Test]
    public void BinaryMaxHeap_Returns_Items_In_Descending_Order()
    {
        // Arrange
        // Descending Sort, Integer: "(x, y) => y - x" OR "(x, y) => y.CompareTo(x)" are same custom comparer
        var pq = new PriorityQueue<string, int>(Comparer<int>.Create((x, y) => y - x));
        pq.Enqueue("internet", 5);
        pq.Enqueue("food", 9);
        pq.Enqueue("water", 10);
        
        // Act
        var highestPriorityItem = pq.Dequeue();

        // Assert
        Assert.That(highestPriorityItem, Is.EqualTo("water"));
    }
}