using System.Collections.Generic;

namespace Model
{
    class Graph
    {
        /// <summary>
        /// myGraphVertexCount - number of vertices in a graph.
        /// myGraphMatrix - graph adjacency matrix.
        /// myGraphVertexLabel - list of labels for each graph vertex.
        /// Labels are needed to reduce the number of iterations of different vertex 
        /// assignments by dividing the set of all vertices into different groups.
        /// </summary>
        private int myGraphVerticesCount;
        private int[,] myGraphMatrix;
        private List<string> myGraphVertexLabel = new List<string>();

        /// <summary>
        /// Instantiating the graph class.
        /// </summary>
        public Graph(int theGraphVertexCount, int[,] theGraphMatrix)
        {
            myGraphVerticesCount = theGraphVertexCount;
            myGraphMatrix = theGraphMatrix;
        }

        /// <summary>
        /// Get graph vertex count.
        /// </summary>
        public int getGraphVerticesCount()
        {
            return myGraphVerticesCount;
        }

        /// <summary>
        /// Clear graph vertex label.
        /// </summary>
        public void clearGraphVertexLebel()
        {
            myGraphVertexLabel.Clear();
        }

        /// <summary>
        /// Get graph vertex label.
        /// </summary>
        public List<string> getGraphVertexLabel()
        {
            return myGraphVertexLabel;
        }

        /// <summary>
        /// Get graph adjacency matrix.
        /// </summary>
        public int[,] getGraphMatrix()
        {
            return myGraphMatrix;
        }

        /// <summary>
        /// Сounting labels for vertices with a level theLabelLevel.
        /// At the initial stage, the label of a vertex is equal to the number of vertices adjacent to this vertex.
        /// This number is called the degree of the vertex.
        /// At each next stage, the degrees of neighbors of the vertices scanned at the previous level are considered.
        /// For example: if a vertex has 4 neighbors, then at the first stage the label of this vertex is 4.
        /// Further, if each neighboring vertex has degree 3, then at the second stage the label of the vertex will be equal to 4 3333.
        /// </summary>
        public void SetGraphVertexLabel(int theLabelLevel)
        {
            List<int> aVertexNeighbors = new List<int>();
            List<int> anArrayToSortDegrees = new List<int>();
            for (int i = 0; i < myGraphVerticesCount; i++)
            {
                if (theLabelLevel == 0)
                {
                    int aNeighborsCount = 0;
                    myGraphVertexLabel.Add("");
                    for (int k = 0; k < myGraphVerticesCount; k++)
                        if (myGraphMatrix[i, k] == 1) aNeighborsCount++;
                    myGraphVertexLabel[i] = myGraphVertexLabel[i] + aNeighborsCount.ToString() + ' ';
                }
                else
                {
                    for (int k = 0; k < myGraphVerticesCount; k++)
                        if (myGraphMatrix[i, k] == 1) aVertexNeighbors.Add(k);
                    for (int j = 0; j < theLabelLevel; j++)
                    {
                        List<int> aNextVertexNeighbors = new List<int>();
                        for (int k = 0; k < aVertexNeighbors.Count; k++)
                        {
                            int aNeighborsCount = 0;
                            for (int m = 0; m < myGraphVerticesCount; m++)
                            {
                                if (myGraphMatrix[aVertexNeighbors[k], m] == 1)
                                {
                                    aNextVertexNeighbors.Add(m);
                                    aNeighborsCount++;
                                }
                            }
                            anArrayToSortDegrees.Add(aNeighborsCount);
                        }
                        aVertexNeighbors = aNextVertexNeighbors;
                        if (j == theLabelLevel - 1)
                        {
                            anArrayToSortDegrees.Sort();
                            for (int m = 0; m < anArrayToSortDegrees.Count; m++)
                                myGraphVertexLabel[i] = myGraphVertexLabel[i] + anArrayToSortDegrees[m].ToString();
                        }
                    }
                    aVertexNeighbors.Clear();
                    anArrayToSortDegrees.Clear();
                }
                myGraphVertexLabel[i] = myGraphVertexLabel[i] + ' ';
            }
        }
    }
}
