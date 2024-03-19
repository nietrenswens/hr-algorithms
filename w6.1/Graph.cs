namespace Solution;

public class Graph
{
    public double[,] AdjacencyMatrix { get; set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }  //Number of nodes in the graph

    public Graph(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new System.ArgumentException("The adjacency matrix must be a square matrix");
        AdjacencyMatrix = matrix;
    }

    //Breadth First Traversal
    public string BFT(int root)
    {
        string output = "";
        // create empty queue and enqueue the root
        Queue<int> queue = new();
        queue.Enqueue(root);
        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] visited = new bool[Count];
        visited[root] = true;
        // Loop until queue is empty
        while (queue.Count > 0)
        {
            // dequeue a node
            int current = queue.Dequeue();

            // add the current node (followed by a space) to the string
            output += current + " ";

            // find neighbors of current
            List<int> neighbours = Neighbors(current);
            foreach (int node in neighbours)
            {
                if (!visited[node])
                {
                    queue.Enqueue(node);
                    visited[node] = true;
                }
            }
            // enqueue all neighbors which are not visited yet and set them to visited
        }
        return output;
    }

    //Nodes adjacent to a given node
    public List<int> Neighbors(int node)
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        return neighbors;
    }

    //Nodes (adjacent to a given node) to be visited in reversed order
    public List<int> NeighborsReversed(int node)
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        neighbors.Reverse();
        return neighbors;
    }

    //Depth First Traveral
    public string DFT(int root)
    {
        // create empty stack and push the root into it
        Stack<int> stack = new();
        stack.Push(root);
        // create array of booleans to keep track of visited nodes
        string output = "";
        bool[] visited = new bool[Count];
        while (stack.Count > 0)
        {
            // dequeue a node
            int current = stack.Pop();

            if (visited[current]) continue;

            // add the current node (followed by a space) to the string
            output += current + " ";
            visited[current] = true;

            // find neighbors of current
            List<int> neighbours = Neighbors(current);
            neighbours.Reverse();
            foreach (int node in neighbours)
            {
                stack.Push(node);
            }
            // enqueue all neighbors which are not visited yet and set them to visited
        }
        // Loop until stack is empty

        // pop a node from the stack 

        // check if current node is not visited yet
        // add current node to the string (followed by a space) and set it to visited

        // find neighbors (in reversed order) of current  

        // push all neighbors 

        return output;
    }

    //Dijkstra's algorithm SingleSourceShortestPath 
    public Tuple<double[], int[]> SingleSourceShortestPath(int source) //distance and prev arrays
    {
        // initialization of distance, prev and unvisitedNodes
        double[] distance = new double[Count];
        int[] previous = new int[Count];

        // default distance: double.PositiveInfinity
        for (int i = 0; i < distance.Length; i++)
        {
            distance[i] = double.PositiveInfinity;
        }
        // default previous node: -1
        for (int i = 0; i < previous.Length; i++)
        {
            previous[i] = -1;
        }

        List<int> unvisitedNodes = new List<int>(Enumerable.Range(0, Count));

        // set distance of source
        distance[source] = 0;

        // Loop until unvisitedNodes is empty
        while (unvisitedNodes.Count > 0)
        {
            // find closest node in unvisitedNodes
            int closest = 0;
            double dist = double.PositiveInfinity;
            foreach(int i in unvisitedNodes)
            {
                if (distance[i] < dist)
                {
                    dist = distance[i];
                    closest = i;
                }
            }

            // remove the closest node from unvisitedNodes
            unvisitedNodes.Remove(closest);

            //considering all neighbors of the closest node
            List<int> neighbours = new();

            for (int i = 0; i < Count; i++)
            {
                if (AdjacencyMatrix[closest, i] != double.PositiveInfinity && unvisitedNodes.Contains(i))
                {
                    neighbours.Add(i);
                }
            }
            // calculate distance and update distance (and previous node) if smaller
            neighbours.ForEach(item => {
                double alt = distance[closest] + AdjacencyMatrix[closest, item];
                if (alt < distance[item])
                {
                    distance[item] = alt;
                    previous[item] = closest;
                }
            });
        }

        return new Tuple<double[], int[]>(distance, previous);
    }

}


