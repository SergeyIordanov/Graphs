namespace Graphs.BellmanFord
{
    public class Edge
    {
        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public int From { get; }

        public int To { get; }

        public int Weight { get; }
    }
}