using System;
using System.Collections.Generic;
using System.IO;

namespace Graphs.BellmanFord
{
    public static class Algorithm
    {
        public static AlgorithmResult Execute(GraphData input)
        {
            int nodesNumber = input.Graph.NodesNumber;
            int edgesNumber = input.Graph.Edges.Count;
            var distance = new int[nodesNumber];
            var paths = new List<List<int>>();

            for (var i = 0; i < nodesNumber; i++)
            {
                distance[i] = int.MaxValue;
                paths.Add(new List<int> { input.StartNode });
            }

            distance[input.StartNode] = 0;

            for (var i = 1; i <= nodesNumber - 1; i++)
            {
                for (var j = 0; j < edgesNumber; j++)
                {
                    int u = input.Graph.Edges[j].From;
                    int v = input.Graph.Edges[j].To;
                    int weight = input.Graph.Edges[j].Weight;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    {
                        distance[v] = distance[u] + weight;
                        paths[v] = new List<int>(paths[u]) { v };
                    }
                }
            }

            var algorithmResult = new AlgorithmResult
            {
                ShortestPath = paths[input.FinishNode].ToArray(),
                MinDistance = distance[input.FinishNode]
            };

            return algorithmResult;
        }
    }
}