using System.Collections.Generic;

namespace ModelInfrastructure
{
    public interface IGraph
    {
        /// <summary>
        /// Get graph vertex count.
        /// </summary>
        int getGraphVerticesCount();

        /// <summary>
        /// Clear graph vertex label.
        /// </summary>
        void ClearGraphVertexLebel();

        /// <summary>
        /// Get graph vertex label.
        /// </summary>
        List<string> getGraphVertexLabel();

        /// <summary>
        /// Get graph adjacency matrix.
        /// </summary>
        int[,] getGraphMatrix();

        /// <summary>
        /// Get graph vertex coordinates.
        /// </summary>
        float[,] getVertexCoordinates();

        /// <summary>
        /// Сounting labels for vertices with a level theLabelLevel.
        /// At the initial stage, the label of a vertex is equal to the number of vertices adjacent to this vertex.
        /// This number is called the degree of the vertex.
        /// At each next stage, the degrees of neighbors of the vertices scanned at the previous level are considered.
        /// For example: if a vertex has 4 neighbors, then at the first stage the label of this vertex is 4.
        /// Further, if each neighboring vertex has degree 3, then at the second stage the label of the vertex will be equal to 4 3333.
        /// </summary>
        void SetGraphVertexLabel(int theLabelLevel);
    }
}
