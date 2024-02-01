namespace Algorithms.Greedy;

public static class DijkstraAlgorithm
{
    public static void FindShortestPath(Dictionary<string, Dictionary<string, int>> graph,
        Dictionary<string, int> costs,
        Dictionary<string, string?> parents)
    {
        // Store the visited nodes
        var visited = new HashSet<string>();

        var lowestCostUnvisitedNode = FindLowestCostUnvisitedNode(costs, visited);
        while (lowestCostUnvisitedNode != null)
        {
            var cost = costs[lowestCostUnvisitedNode];
            var neighbors = graph[lowestCostUnvisitedNode];

            foreach (var neighbor in neighbors)
            {
                // New cost to get to the neighbor of lowestCostUnvisitedNode
                var newCost = cost + neighbor.Value;
                if (newCost < costs[neighbor.Key])
                {
                    costs[neighbor.Key] = newCost;
                    parents[neighbor.Key] = lowestCostUnvisitedNode;
                }
            }

            visited.Add(lowestCostUnvisitedNode);
            lowestCostUnvisitedNode = FindLowestCostUnvisitedNode(costs, visited);
        }
    }
    
    private static string? FindLowestCostUnvisitedNode(Dictionary<string, int> costs, HashSet<string> visited)
    {
        return costs
            .Where(node => !visited.Contains(node.Key))
            .OrderBy(node => node.Value)
            // When .Where above returns empty collection, this will give default KeyValuePair: { Key = null, Value = 0 }
            .FirstOrDefault()
            .Key;
    }
    
    // Not needed for the algorithm though
    public static string ConstructFinalRoute(Dictionary<string, string?> parents)
    {
        var route = new List<string>();
        var currentNode = "Finish";

        // The loop will exit when currentNode becomes "Start". "Start" has no parent, so currentNode gets null
        while (currentNode != null)
        {
            route.Add(currentNode);
            currentNode = parents.GetValueOrDefault(currentNode);
        }

        route.Reverse();
        return string.Join("=>", route);
    }
}