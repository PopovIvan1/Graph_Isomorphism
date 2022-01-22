namespace ModelInfrastructure
{
    /// <summary>
    /// Model interface.
    /// </summary>
    public interface IGraphModel
    {
        /// <summary>
        /// Get alroritm answer.
        /// </summary>
        string GetAnswer();

        /// <summary>
        /// Get alroritm time.
        /// </summary>
        string GetTime();

        /// <summary>
        /// Get graph isomorphism.
        /// </summary>
        int[] GetIsomorphism();

        /// <summary>
        /// Start alroritm.
        /// </summary>
        void StartAlgoritm();

        /// <summary>
        /// Upload graph from file.
        /// </summary>
        void UploadGraph(string theFileName, int theGraphNumber);

        /// <summary>
        /// Get first or second graph.
        /// </summary>
        IGraph GetGraph(int theGraphNumber);
    }
}
