using System.Collections.Generic;

namespace Graphs.Prim
{
    public static class Algorithm
    {
        public static List<Edge> Execute(Graph inputGraph)
        {
            var originEdges = new List<Edge>(inputGraph.Edges);
            var usedVertexes = new List<int>();
            var originVertexes = new List<int>();
            var mst = new List<Edge>();

            usedVertexes.Add(1);
            for (var i = 2; i <= inputGraph.NodesNumber; i++)
            {
                originVertexes.Add(i);
            }

            while (originVertexes.Count > 0)
            {
                var minEdge = -1;

                for (var i = 0; i < originEdges.Count; i++)
                {
                    if (usedVertexes.Contains(originEdges[i].V1)
                        && originVertexes.Contains(originEdges[i].V2)
                        || usedVertexes.Contains(originEdges[i].V2)
                        && originVertexes.Contains(originEdges[i].V1))
                    {
                        if (minEdge != -1)
                        {
                            if (originEdges[i].Weight < originEdges[minEdge].Weight)
                            {
                                minEdge = i;
                            }
                        }
                        else
                        {
                            minEdge = i;
                        }
                    }
                }

                if (usedVertexes.Contains(originEdges[minEdge].V1))
                {
                    usedVertexes.Add(originEdges[minEdge].V2);
                    originVertexes.Remove(originEdges[minEdge].V2);
                }
                else
                {
                    usedVertexes.Add(originEdges[minEdge].V1);
                    originVertexes.Remove(originEdges[minEdge].V1);
                }

                mst.Add(originEdges[minEdge]);
                originEdges.RemoveAt(minEdge);
            }

            return mst;
        }
    }
}