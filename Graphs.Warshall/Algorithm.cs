namespace Graphs.Warshall
{
    public static class Algorithm
    {
        public static int Execute(GraphData input)
        {
            var relationMatrix = 
                GenerateRelationMatrixes(ReplaceMinusOneWithInf(input.GraphMatrix, input.NodesNumber), input.NodesNumber);

            return FindMaxPath(relationMatrix, input.NodesNumber);
        }

        public static int[,] GenerateRelationMatrixes(int[,] graph, int nodesNumber)
        {
            var relationMatrix = new int[nodesNumber, nodesNumber];

            for (var i = 0; i < nodesNumber; ++i)
            {
                for (var j = 0; j < nodesNumber; ++j)
                {
                    relationMatrix[i, j] = graph[i, j];
                }
            }

            for (var k = 0; k < nodesNumber; ++k)
            {
                for (var i = 0; i < nodesNumber; ++i)
                {
                    for (var j = 0; j < nodesNumber; ++j)
                    {
                        if (relationMatrix[i, k] < int.MaxValue 
                            && relationMatrix[k, j] < int.MaxValue 
                            && relationMatrix[i, k] + relationMatrix[k, j] < relationMatrix[i, j])
                        {
                            relationMatrix[i, j] = relationMatrix[i, k] + relationMatrix[k, j];
                        }
                    }
                }
            }

            return relationMatrix;
        }

        private static int[,] ReplaceMinusOneWithInf(int[,] matrix, int nodeNumber)
        {
            for (var i = 0; i < nodeNumber; i++)
            {
                for (var j = 0; j < nodeNumber; j++)
                {
                    if (matrix[i, j] == -1)
                    {
                        matrix[i, j] = int.MaxValue;
                    }
                }
            }

            return matrix;
        }

        private static int FindMaxPath(int[,] matrix, int nodeNumber)
        {
            int maxPath = -1;

            for (var i = 0; i < nodeNumber; i++)
            {
                for (var j = 0; j < nodeNumber; j++)
                {
                    if (matrix[i, j] > maxPath)
                    {
                        maxPath = matrix[i, j];
                    }
                }
            }

            return maxPath;
        }
    }
}