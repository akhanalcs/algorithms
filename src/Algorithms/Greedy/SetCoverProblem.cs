namespace Algorithms.Greedy;

public static class SetCoverProblem
{
    // Given a set of elements {1, 2, …, n} (called the universe) and a collection 'S' of 'm' subsets
    // whose union equals the universe, the "set cover problem" is to identify the smallest sub-collection
    // of 'S' whose union equals the universe.
    // For eg: U = {1, 2, 3, 4, 5} and S = { {1, 2, 3}, {2, 4}, {3, 4}, {4, 5} }
    // Clearly the union of S is U. However, we can cover all elements with only two sets: { {1, 2, 3}, {4, 5} }.
    // Therefore, the solution to the set cover problem has size 2.
    public static HashSet<string> Cover(HashSet<string> universe, Dictionary<string, HashSet<string>> subsets)
    {
        var statesNeeded = new HashSet<string> { "mt", "wa", "or", "id", "nv", "ut", "ca", "az" };
        var stations = new Dictionary<string, HashSet<string>>
        {
            { "kone", ["id", "nv", "ut"] },
            { "ktwo", ["wa", "id", "mt"] },
            { "kthree", ["or", "nv", "ca"] },
            { "kfour", ["nv", "ut"] },
            { "kfive", ["ca", "az"] }
        };

        var finalStations = new HashSet<string>();

        while (statesNeeded.Count > 0)
        {
            var bestStation = "";
            var statesCovered = new HashSet<string>();

            foreach (var station in stations)
            {
                var covered = new HashSet<string>(station.Value.Intersect(statesNeeded));
                if (covered.Count > statesCovered.Count)
                {
                    bestStation = station.Key;
                    statesCovered = covered;
                }
            }

            finalStations.Add(bestStation);
            statesNeeded.ExceptWith(statesCovered);
        }

        return finalStations;
    }
}