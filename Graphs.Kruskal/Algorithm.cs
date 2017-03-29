using System.Collections.Generic;
using System.Linq;

namespace Graphs.Kruskal
{
    public static class Algorithm
    {
        public static List<Edge> Execute(Graph inputGraph)
        {
            var mst = new List<Edge>();
            var usedVertexes = new List<int>();
            var originEdges = inputGraph.Edges.OrderBy(x => x.Weight).ToList();

            foreach (var edge in originEdges)
            {
                // todo fix loop check
                if (usedVertexes.Contains(edge.V1) && usedVertexes.Contains(edge.V2))
                {
                    continue;
                }

                mst.Add(edge);

                if (usedVertexes.IndexOf(edge.V1) == -1)
                {
                    usedVertexes.Add(edge.V1);
                }

                if (usedVertexes.IndexOf(edge.V2) == -1)
                {
                    usedVertexes.Add(edge.V2);
                }
            }

            return mst;
        }
    }
}