public class DijkstraAlgorithm
{
    private Dictionary<string, Dictionary<string, double>> graph;

    public DijkstraAlgorithm()
    {
        graph = new Dictionary<string, Dictionary<string, double>>();
    }

    public void AddEdge(string source, string destination, double weight)
    {
        if (!graph.ContainsKey(source))
        {
            graph[source] = new Dictionary<string, double>();
        }

        if (!graph.ContainsKey(destination))
        {
            graph[destination] = new Dictionary<string, double>();
        }

        graph[source][destination] = weight;
        graph[destination][source] = weight;
    }

    public List<List<string>> FindAllPaths(string source, string destination)
    {
        List<List<string>> paths = new List<List<string>>();
        List<string> visited = new List<string>();

        FindPaths(source, destination, visited, paths);

        return paths;
    }

    private void FindPaths(string current, string destination, List<string> visited, List<List<string>> paths)
    {
        visited.Add(current);

        if (current == destination)
        {
            paths.Add(new List<string>(visited));
        }
        else
        {
            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor.Key))
                {
                    FindPaths(neighbor.Key, destination, visited, paths);
                }
            }
        }

        visited.Remove(current);
    }

    public double CalculateDistance(List<string> path)
    {
        double distance = 0;

        for (int i = 0; i < path.Count - 1; i++)
        {
            string source = path[i];
            string destination = path[i + 1];

            distance += graph[source][destination];
        }

        return distance;
    }
}