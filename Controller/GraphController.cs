using ControllerInfrastructure;
using ViewInfrastructure;
using ModelInfrastructure;
using System.IO;
using System.Text;

namespace Controller
{
    /// <summary>
    /// Class controller - one of the three components of the MVC pattern.
    /// Designed for communication between the model and the view.
    /// </summary>
    public class GraphController : IGraphController
    {
        private IGraphModel myGraphModel;
        private IGraphView myGraphView;

        /// <summary>
        /// Instantiating the controller class.
        /// </summary>
        public GraphController(IGraphModel theModel, IGraphView theView)
        {
            myGraphModel = theModel;
            myGraphView = theView;
            myGraphView.GetAnswer += GetAnswer;
            myGraphView.UploadFirstGraph += UploadFirstGraph;
            myGraphView.UploadSecondGraph += UploadSecondGraph;
        }

        /// <summary>
        /// Get alroritm answer.
        /// </summary>
        public void GetAnswer()
        {
            myGraphModel.StartAlgoritm();
            if (myGraphModel.GetAnswer() != "No")
            {
                int[] anIsomorphism = myGraphModel.GetIsomorphism();
                string aFileName = "VerticesColors.txt";
                if (File.Exists(aFileName))
                {
                    StreamReader aStreamReader = new StreamReader(aFileName, Encoding.Default);
                    string[] aFirstGraphVerticesColors = new string[anIsomorphism.Length];
                    string[] aSecondGraphVerticesColors = new string[anIsomorphism.Length];
                    for (int i = 0; i < anIsomorphism.Length;i++)
                    {
                        aFirstGraphVerticesColors[i] = aStreamReader.ReadLine();
                        aSecondGraphVerticesColors[anIsomorphism[i]] = aFirstGraphVerticesColors[i];
                    }
                    drawGraph(myGraphModel.GetGraph(0), 0, aFirstGraphVerticesColors);
                    drawGraph(myGraphModel.GetGraph(1), 1, aSecondGraphVerticesColors);
                }
                string[] anIsomorphismToString = new string[anIsomorphism.Length];
                for (int i = 0; i < anIsomorphism.Length; i++)
                    anIsomorphismToString[i] = $"{i + 1} -> {anIsomorphism[i] + 1}";
                myGraphView.DisplayGraphIsomorphism(anIsomorphismToString);
            }
            else 
                myGraphView.DisplayGraphIsomorphism(new[] { "No" });
            myGraphView.DisplayAlgorithmAnswer(myGraphModel.GetAnswer());
            myGraphView.DisplayAlgorithmTime(myGraphModel.GetTime());
        }

        /// <summary>
        /// Upload first graph from file.
        /// </summary>
        public void UploadFirstGraph()
        {
            myGraphView.ZeroingPictureBoxImage(0);
            myGraphModel.UploadGraph(myGraphView.UploadFile(), 0);
            drawGraph(myGraphModel.GetGraph(0), 0);
        }

        /// <summary>
        /// Upload second graph from file.
        /// </summary>
        public void UploadSecondGraph()
        {
            myGraphView.ZeroingPictureBoxImage(1);
            myGraphModel.UploadGraph(myGraphView.UploadFile(), 1);
            drawGraph(myGraphModel.GetGraph(1), 1);
        }

        private void drawGraph(IGraph theGraph, int theGraphNumber, string[] theGraphVertexColor = null)
        {
            if (theGraph.GetGraphVerticesCount() > 20) return;
            int aGraphVerticesCount = theGraph.GetGraphVerticesCount();
            int[,] aGraphMatrix = theGraph.GetGraphMatrix();
            float[,] aGraphVertexCoordinates = theGraph.GetVertexCoordinates();
            if (theGraphVertexColor == null)
            {
                theGraphVertexColor = new string[aGraphVerticesCount];
                for (int i = 0; i < aGraphVerticesCount; i++)
                    theGraphVertexColor[i] = "White";
            }
            for (int i = 0; i < aGraphVerticesCount; i++)
                for (int j = 0; j < aGraphVerticesCount; j++)
                    if (aGraphMatrix[i, j] == 1) myGraphView.DrawGraphEdge(theGraphNumber, aGraphVertexCoordinates[i, 0] + 10, aGraphVertexCoordinates[j, 0] + 10, aGraphVertexCoordinates[i, 1] + 10, aGraphVertexCoordinates[j, 1] + 10);
            for (int i = 0; i < aGraphVerticesCount; i++)
            { 
                if (i < 9) myGraphView.DrawGraphVertex(theGraphNumber, aGraphVertexCoordinates[i, 0], aGraphVertexCoordinates[i, 1], 20, 20, (i + 1).ToString(), theGraphVertexColor[i]);
                else myGraphView.DrawGraphVertex(theGraphNumber, aGraphVertexCoordinates[i, 0], aGraphVertexCoordinates[i, 1], 20, 20, (i + 1).ToString(), theGraphVertexColor[i], 0);
            }
        }
    }
}
