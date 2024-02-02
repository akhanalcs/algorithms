using Algorithms.Greedy;

namespace Algorithms.UnitTests.Greedy;

public class SetCoverProblemTests
{
    [Test]
    public void Find_Least_No_Of_Stations_To_Reach_All_Needed_States()
    {
        // Act
        var finalStations = SetCoverProblem.Cover().ToArray();
        // Assert
        Assert.That(finalStations.Count, Is.EqualTo(4));
    }
}