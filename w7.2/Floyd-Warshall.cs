namespace Solution;

public class FloydWarshall
{
    public static Tuple<double[,], int[,]> Init(double[,] graph)
    {
        //ToDo 1.1 Initialize the distance and next matrix
        var size = graph.GetLength(0);
        double[,] distances = new double[size,size];
        int[,] next = new int[size,size];
        distances = graph;
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                if(graph[i,j] != double.PositiveInfinity)
                {
                    next[i,j] = j;
                } else next[i,j] = -1;
            }
            distances[i,i] = 0;
            next[i,i] = -1;
        }
        return new Tuple<double[,], int[,]>(distances, next);
    }
    
    public static Tuple<double[,], int[,]> AllPairShortestPath(double[,] graph)
    {
        //ToDo 1: Floyd-Warshall Algorithm, All Pairs Shortest Path
        //Includes 1.1
        var size = graph.GetLength(0);
        var (dist, next) = Init(graph);
        for (int k = 0; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(dist[i,k] + dist[k,j] < dist[i,j])
                    {
                        dist[i,j] = dist[i,k] + dist[k,j];
                        next[i,j] = next[i,k];
                    }
                }
            }
        }
        return new Tuple<double[,], int[,]>(dist, next);
    }
}
