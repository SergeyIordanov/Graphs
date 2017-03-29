using System.Collections.Generic;

namespace Graphs.Dijkstra
{
    public class AlgorithmResult
    {
        public int[] Distances { get; set; }

        public List<List<int>> ShortestPaths { get; set; }
    }
}