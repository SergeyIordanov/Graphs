using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Graphs.BellmanFord
{
    internal class Program
    {
        private static void Main()
        {
            var graph = ReadData("INPUT.txt");

            var result = Algorithm.Execute(graph);

            WriteResult(result.MinDistance, result.ShortestPath, "OUTPUT.txt");
        }

        private static GraphData ReadData(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            int nodesNumber = Convert.ToInt32(lines[0].Split(' ')[0]);
            int startNode = Convert.ToInt32(lines[1].Split(' ')[0]) - 1;
            int finishNode = Convert.ToInt32(lines[1].Split(' ')[1]) - 1;

            var edges = new List<Edge>();

            for (var i = 2; i < lines.Length; i++)
            {
                var selectLine = lines[i].Split(' ');

                var edge = new Edge(
                    Convert.ToInt32(selectLine[0]) - 1,
                    Convert.ToInt32(selectLine[1]) - 1,
                    Convert.ToInt32(selectLine[2]));

                edges.Add(edge);
            }

            var graph = new Graph(nodesNumber, edges);
            var result = new GraphData(graph, startNode, finishNode);

            return result;
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