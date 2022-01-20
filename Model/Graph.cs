using ModelInfrastructure;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Graph : IGraph
    {
        /// <summary>
        /// myGraphVertexCount - number of vertices in a graph.
        /// myGraphMatrix - graph adjacency matrix.
        /// myGraphVertexLabel - list of labels for each graph vertex.
        /// Labels are needed to reduce the number of iterations of different vertex 
        /// assignments by dividing the set of all vertices into different groups.
        /// myVertexCoordinates - vertex coordinates on the plane.
        /// </summary>
        private int myGraphVerticesCount;
        private int[,] myGraphMatrix;
        private List<string> myGraphVertexLabel = new List<string>();
        private float[,] myVertexCoordinates;

        /// <summary>
        /// Instantiating the graph class.
        /// </summary>
        public Graph(int theGraphVerticesCount, int[,] theGraphMatrix)
        {
            myGraphVerticesCount = theGraphVerticesCount;
            myGraphMatrix = theGraphMatrix;
            setVertexCoordinates();
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
        public void ClearGraphVertexLebel()
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
        /// Get graph vertex coordinates.
        /// </summary>
        public float[,] getVertexCoordinates()
        {
            return myVertexCoordinates;
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

        private void setVertexCoordinates()
        {
            myVertexCoordinates = new float[myGraphVerticesCount, 2];
            int R = 60;
            if (myGraphVerticesCount * 10 > R) R = myGraphVerticesCount * 10;
            if (R > 120) R = 120;
            double anAngle = 360.0 / myGraphVerticesCount;
            double aDeltaAngle = 0;
            for (int i = 0; i < myGraphVerticesCount; i++)
            {
                myVertexCoordinates[i, 0] = (float)Math.Round(Math.Cos(aDeltaAngle / 180 * Math.PI) * R) + 150;
                myVertexCoordinates[i, 1] = (-1) * (float)Math.Round(Math.Sin(aDeltaAngle / 180 * Math.PI) * R) + 150;
                aDeltaAngle = aDeltaAngle + anAngle;
            }
        }
    }
}
