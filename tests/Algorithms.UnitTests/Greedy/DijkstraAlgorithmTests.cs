using Algorithms.Greedy;

namespace Algorithms.UnitTests.Greedy;

public class DijkstraAlgorithmTests
{
    [Test]
    public void DijkstraAlgorithm_Finds_Shortest_Path()
    {
        // Arrange
        var costs = new Dictionary<string, int>
        {
            // Costs from "start" to:
            { "A", 6 },
            { "B", 2 },
            { "Finish", int.MaxValue }
        };

        // Store the neighbors and the cost for getting to that neighbor
        var graph = new Dictionary<string, Dictionary<string, int>>
        {
            ["Start"] = new() { { "A", 6 }, { "B", 2 } }, // For eg: Going from Start to A and B
            ["A"] = new() { { "Finish", 1 } },
            ["B"] = new() { { "A", 3 }, { "Finish", 5 } },
            ["Finish"] = new()
        };

        // Store the parents
        var parents = new Dictionary<string, string?>
        {
            { "A", "Start" },
            { "B", "Start" },
            { "Finish", null }
        };
        
        // Act
        DijkstraAlgorithm.FindShortestPath(graph, costs, parents);
        var finalRoute = DijkstraAlgorithm.ConstructFinalRoute(parents);
        
        // Assert
        Assert.That(costs["Finish"], Is.EqualTo(6));
        Assert.That(parents["A"], Is.EqualTo("B"));
        Assert.That(parents["B"], Is.EqualTo("Start"));
        Assert.That(parents["Finish"], Is.EqualTo("A"));
        Assert.That(finalRoute, Is.EqualTo("Start=>B=>A=>Finish"));
    }
}