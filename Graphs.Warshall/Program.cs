using System;
using System.IO;
using System.Text;

namespace Graphs.Warshall
{
    internal class Program
    {
        private static void Main()
        {
            var graph = ReadData("INPUT.txt");

            int longestWayWeigth = Algorithm.Execute(graph);

            WriteResult(longestWayWeigth, "OUTPUT.txt");
        }

        private static GraphData ReadData(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            int nodesNumber = Convert.ToInt32(lines[0].Split(' ')[0]);
            var graphMatrix = new int[nodesNumber, nodesNumber];

            var graphData = new GraphData(graphMatrix, nodesNumber);

            for (var i = 1; i < lines.Length; i++)
            {
                var lineData = lines[i].Split(' ');

                for (var j = 0; j < lineData.Length; j++)
                {
                    graphData.GraphMatrix[i - 1, j] = Convert.ToInt32(lineData[j]);
                }
            }

            return graphData;
        }

        private static void WriteResult(int result, string fileName)
        {
            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                sw.Write(result);
            }
        }
    }
}