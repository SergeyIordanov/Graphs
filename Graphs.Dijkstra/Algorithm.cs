using System;
using System.Collections.Generic;

namespace Graphs.Dijkstra
{
    public static class Algorithm
    {
        public static AlgorithmResult Execute(GraphData input)
        {
            var distance = new int[input.NodesNumber];
            var nodeStatuses = new bool[input.NodesNumber];
            var shortestPaths = new List<List<int>>();

            for (var i = 0; i < input.NodesNumber; i++)
            {
                distance[i] = int.MaxValue;
                shortestPaths.Add(new List<int> { input.StartNode });
            }

            distance[input.StartNode] = 0;

            for (var count = 0; count < input.NodesNumber - 1; count++)
            {
                // get nearest node
                int visitedNode = MinimumDistance(distance, nodeStatuses, input.NodesNumber);

                // mark it as visited
                nodeStatuses[visitedNode] = true;

                // set all neighbours marks
                if (distance[visitedNode] != int.MaxValue)
                {
                    for (var vertexIdx = 0; vertexIdx < input.NodesNumber; vertexIdx++)
                    {
                        if (!nodeStatuses[vertexIdx]
                            && Convert.ToBoolean(input.GraphMatrix[visitedNode, vertexIdx])
                            && distance[visitedNode] + input.GraphMatrix[visitedNode, vertexIdx] < distance[vertexIdx])
                        {
                            distance[vertexIdx] = distance[visitedNode] + input.GraphMatrix[visitedNode, vertexIdx];
                            shortestPaths[vertexIdx] = new List<int>(shortestPaths[visitedNode]) { vertexIdx };
                        }
                    }
                }

            }

            var algorithmResult = new AlgorithmResult
            {
                Distances = distance,
                ShortestPaths = shortestPaths
            };

            return algorithmResult;
        }

        private static int MinimumDistance(int[] distance, bool[] nodeStatuses, int nodesNumber)
        {
            int min = int.MaxValue;
            var minIndex = 0;

            for (var v = 0; v < nodesNumber; v++)
            {
                if (nodeStatuses[v] || distance[v] > min)
                {
                    continue;
                }

                min = distance[v];
                minIndex = v;
            }

            return minIndex;
        }
    }
}