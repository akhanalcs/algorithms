namespace Algorithms.Search;

public static class BreadthFirstSearcher
{
    // check is a delegate that takes a string and returns a bool. It defines what's your basis for the search.
    // action is a delegate that take a string but doesn't return anything. It defines what you want to do when you find something.
    public static bool Search(Dictionary<string, string[]> graph,
        string startVertex,
        Func<string, bool> check,
        Action<string> action)
    {
        // Create a queue and initialize it with the neighbors of the startVertex
        var queue = new Queue<string>(graph[startVertex]);
        
        // Array supports O(1) lookup time by index.
        // HashSet supports O(1) lookup time to find a value.
        var visited = new HashSet<string>();

        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();
            if (visited.Contains(currentVertex)) continue;
            
            // Check if it's the vertex you were looking for
            if (check(currentVertex))
            {
                action(currentVertex);
                return true;
            }

            // If you didn't find what you were looking for in the currentVertex, add its neighbors to the queue
            foreach (var vertex in graph[currentVertex]) queue.Enqueue(vertex);

            visited.Add(currentVertex);
        }

        return false;
    }
}