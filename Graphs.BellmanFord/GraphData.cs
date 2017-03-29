namespace Graphs.BellmanFord
{
    public class GraphData
    {
        public GraphData(Graph graph, int startNode, int finishNode)
        {
            Graph = graph;
            StartNode = startNode;
            FinishNode = finishNode;
        }

        public Graph Graph { get; }

        public int  StartNode { get; }

        public int FinishNode { get; }
    }
}