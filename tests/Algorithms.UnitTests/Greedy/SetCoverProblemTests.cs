using Algorithms.Greedy;

namespace Algorithms.UnitTests.Greedy;

public class SetCoverProblemTests
{
    [Test]
    public void Find_Least_No_Of_Stations_To_Reach_All_Needed_States()
    {
        // Arrange
        var statesNeeded = new HashSet<string> { "mt", "wa", "or", "id", "nv", "ut", "ca", "az" };
        var stations = new Dictionary<string, HashSet<string>>
        {
            { "kone", ["id", "nv", "ut"] },
            { "ktwo", ["wa", "id", "mt"] },
            { "kthree", ["or", "nv", "ca"] },
            { "kfour", ["nv", "ut"] },
            { "kfive", ["ca", "az"] }
        };
        
        var finalStations = SetCoverProblem.Cover(statesNeeded, stations);
        Assert.That(finalStations.Count(), Is.EqualTo(4));
    }
}