namespace ControllerInfrastructure
{
    /// <summary>
    /// Controller interface.
    /// </summary>
    public interface IGraphController
    {
        /// <summary>
        /// Upload first graph from file.
        /// </summary>
        void UploadFirstGraph();

        /// <summary>
        /// Upload second graph from file.
        /// </summary>
        void UploadSecondGraph();

        /// <summary>
        /// Get alroritm answer.
        /// </summary>
        void GetAnswer();
    }
}
