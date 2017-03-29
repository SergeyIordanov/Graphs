using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Graphs.Prim
{
    internal class Program
    {
        private static void Main()
        {
            var graph = ReadData("INPUT.txt");

            var mst = Algorithm.Execute(graph);

            WriteResult(mst, "OUTPUT.txt");
        }

        private static void WriteResult(IEnumerable<Edge> mst, string fileName)
        {
            int weight = mst.Sum(edge => edge.Weight);

            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                sw.Write(weight);
            }
        }

        private static Graph ReadData(string fileName)
        {
            var edges = new List<Edge>();

            var lines = File.ReadAllLines(fileName);

            int nodesNumber = Convert.ToInt32(lines[0].Split(' ')[0]);

            for (var i = 1; i < lines.Length; i++)
            {
                var selectLine = lines[i].Split(' ');
                edges.Add(
                    new Edge(
                        Convert.ToInt32(selectLine[0]),
                        Convert.ToInt32(selectLine[1]),
                        Convert.ToInt32(selectLine[2])));
            }

            return new Graph(nodesNumber, edges);
        }
    }
}