﻿using System.Collections.Generic;

namespace Graphs.BellmanFord
{
    public class Graph
    {
        public Graph(int nodesNumber, List<Edge> edges)
        {
            NodesNumber = nodesNumber;
            Edges = edges;
        }

        public int NodesNumber { get; }

        public List<Edge> Edges { get; }
    }
}