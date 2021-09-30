﻿using System;

namespace ViewInfrastructure
{
    /// <summary>
    /// View interface.
    /// </summary>
    public interface IGraphView
    {
        Action UploadFirstGraph { get; set; }
        Action UploadSecondGraph { get; set; }
        Action GetAnswer { get; set; }
        /// <summary>
        /// Display the running time of the algorithm.
        /// </summary>
        void DisplayAlgorithmTime(string theTime);

        /// <summary>
        /// Display the algorithm answer.
        /// </summary>
        void DisplayAlgorithmAnswer(string theAnswer);

        /// <summary>
        /// Display graph isomorphism.
        /// </summary>
        void DisplayGraphIsomorphism(string[] theIsomorphism);

        /// <summary>
        /// Display graph label.
        /// </summary>
        void DisplayGraphLabel(int theGraphNumber, string[] theLabel);

        /// <summary>
        /// Display graph edge.
        /// </summary>
        void DrawGraphEdge(int theGraphNumber, float x1, float x2, float y1, float y2);

        /// <summary>
        /// Display graph vertex.
        /// </summary>
        void DrawGraphVertex(int theGraphNumber, float x, float y, float width, float height, string theContent, string theColor);

        /// <summary>
        /// Clear the view.
        /// </summary>
        void ViewClear();
    }
}
