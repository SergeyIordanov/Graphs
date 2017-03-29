using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Graphs.Dijkstra
{
    internal class Program
    {
        private static void Main()
        {
            var graph = ReadData("INPUT.txt");

            var result = Algorithm.Execute(graph);

            WriteResult(result.Distances[graph.FinishNode], result.ShortestPaths[graph.FinishNode], "OUTPUT.txt");
        }

        private static GraphData ReadData(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            int nodesNumber = Convert.ToInt32(lines[0].Split(' ')[0]);
            int startNode = Convert.ToInt32(lines[1].Split(' ')[0]) - 1;
            int finishNode = Convert.ToInt32(lines[1].Split(' ')[1]) - 1;
            var graphMatrix = new int[nodesNumber, nodesNumber];

            var graphData = new GraphData(graphMatrix, startNode, finishNode, nodesNumber);

            for (var i = 2; i < lines.Length; i++)
            {
                var lineData = lines[i].Split(' ');
                int source = Convert.ToInt32(lineData[0]) - 1;
                int destination = Convert.ToInt32(lineData[1]) - 1;
                int length = Convert.ToInt32(lineData[2]);

                graphData.GraphMatrix[source, destination] = length;
                graphData.GraphMatrix[destination, source] = length;
            }

            return graphData;
        }

        private static void WriteResult(int minDistance, IEnumerable<int> shortestPath, string fileName)
        {
            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                if (minDistance != int.MaxValue)
                {
                    sw.WriteLine(minDistance);
                    string aggregate = shortestPath.Aggregate("", (current, vertex) => current + (vertex + 1) + " ");
                    sw.WriteLine(aggregate.TrimEnd());
                }
                else
                {
                    sw.WriteLine("-1");
                }

            }
        }
    }
}