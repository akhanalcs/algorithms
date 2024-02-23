namespace Algorithms.UnitTests.Search;

public class InvertedIndexTests
{
    [Test]
    public void Inverted_Index_Maps_Content_To_Webpages()
    {
        //Arrange
        var invertedIndex = new Dictionary<string, string[]>
        {
            { "hi", ["a.com", "b.com"] },
            { "there", ["a.com", "c.com"] },
            { "adit", ["b.com"] },
            { "we", ["c.com"] },
            { "go", ["c.com"] },
        };
        
        // Act
        // Let's say user searches for "adit", and we want to show which webpages it appears on.
        const string searchTerm = "adit";
        var webpages = invertedIndex.TryGetValue(searchTerm, out var value) ? value : [];

        // Assert
        CollectionAssert.AreEqual(new[] { "b.com" }, webpages);
    }
}