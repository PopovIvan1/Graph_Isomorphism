using System;
using ControllerInfrastructure;
using ViewInfrastructure;
using ModelInfrastructure;

namespace Controller
{
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
            
        }

        /// <summary>
        /// Upload first graph from file.
        /// </summary>
        public void UploadFirstGraph()
        {
            
        }

        /// <summary>
        /// Upload second graph from file.
        /// </summary>
        public void UploadSecondGraph()
        {
            
        }
    }
}
