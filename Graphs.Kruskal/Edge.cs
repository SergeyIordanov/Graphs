namespace Graphs.Kruskal
{
    public class Edge
    {
        public Edge(int v1, int v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }

        public int V1 { get; }

        public int V2 { get; }

        public int Weight { get; }
    }
}