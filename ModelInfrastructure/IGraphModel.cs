using System;

namespace ModelInfrastructure
{
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
        string[] GetIsomorphism();

        /// <summary>
        /// Start alroritm.
        /// </summary>
        void StartAlgoritm();

        /// <summary>
        /// Upload graph from file.
        /// </summary>
        void UploadGraph(string theFileName, int theGraphNumber);

    }
}
