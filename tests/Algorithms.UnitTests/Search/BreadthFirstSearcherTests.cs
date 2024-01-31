using Algorithms.Search;

namespace Algorithms.UnitTests.Search;

public class BreadthFirstSearcherTests
{
    [Test]
    public void BFS_Finds_Mango_Seller()
    {
        // Arrange
        var graph = new Dictionary<string, string[]>
        {
            // node, [neighbors]
            { "you", ["bob", "claire", "alice"] },
            { "bob", ["anuj", "peggy"] },
            { "alice", ["peggy"] },
            { "claire", ["jonny", "thom"] },
            { "anuj", [] },
            { "peggy", [] },
            { "jonny", [] },
            { "thom", [] }
        };
        
        bool IsMangoSeller(string person) => person.EndsWith('m');
        void ShowMangoSeller(string person) => Console.WriteLine($"{person} is a mango seller!");

        // Act
        var searchResult = BreadthFirstSearcher.Search(graph, "you", IsMangoSeller, ShowMangoSeller);

        // Assert
        Assert.That(searchResult, Is.EqualTo(true));
    }
}