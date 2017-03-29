namespace Graphs.Warshall
{
    public class GraphData
    {
        public GraphData(int[,] graphMatrix, int nodesNumber)
        {
            GraphMatrix = graphMatrix;
            NodesNumber = nodesNumber;
        }

        public int[,] GraphMatrix { get; }

        public int NodesNumber { get; }
    }
}