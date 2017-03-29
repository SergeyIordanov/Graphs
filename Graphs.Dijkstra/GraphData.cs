namespace Graphs.Dijkstra
{
    public class GraphData
    {
        public GraphData(int[,] graphMatrix, int startNode, int finishNode, int nodesNumber)
        {
            GraphMatrix = graphMatrix;
            StartNode = startNode;
            FinishNode = finishNode;
            NodesNumber = nodesNumber;
        }

        public int[,] GraphMatrix { get; }

        public int  StartNode { get; }

        public int FinishNode { get; }

        public int NodesNumber { get; }
    }
}