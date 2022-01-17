using System.Collections.Generic;
using System.IO;
using System.Text;
using ModelInfrastructure;

namespace Model
{
    public class GraphModel : IGraphModel
    {
        private Graph myFirstGraph = new Graph(0, new[,] { { 0, 0 } });
        private Graph mySecondGraph = new Graph(0, new[,] { { 0, 0 } });

        /// <summary>
        /// Upload graph from file.
        /// Verification and correction of input data
        /// </summary>
        public void UploadGraph(string theFileName, int theGraphNumber)
        {
            StreamReader aStreamReader = new StreamReader(theFileName, Encoding.Default);
            List<List<int>> aGraphMatrix = new List<List<int>>();
            string aCurrentString;
            int aVerticesNumber = 0;
            while ((aCurrentString = aStreamReader.ReadLine()) != null)
            {
                aGraphMatrix.Add(new List<int>());
                foreach (char aChar in aCurrentString)
                {
                    if (aChar == '0') aGraphMatrix[aGraphMatrix.Count - 1].Add(0);
                    else if (aChar == '1') aGraphMatrix[aGraphMatrix.Count - 1].Add(1);
                }
                if (aGraphMatrix[aGraphMatrix.Count - 1].Count > aVerticesNumber) aVerticesNumber = aGraphMatrix[aGraphMatrix.Count - 1].Count;
            }
            if (aVerticesNumber < aGraphMatrix.Count) aVerticesNumber = aGraphMatrix.Count;
            int[,] aGraphMatrixToArray = new int[aVerticesNumber, aVerticesNumber];
            for (int i = 0; i < aVerticesNumber; i++)
                for (int j = 0; j < aVerticesNumber; j++) 
                {
                    if (i < aGraphMatrix.Count)
                    {
                        if (j < aGraphMatrix[i].Count) aGraphMatrixToArray[i, j] = aGraphMatrix[i][j];
                        else aGraphMatrixToArray[i, j] = 0;
                    }
                    else aGraphMatrixToArray[i, j] = 0;
                }
            for (int i = 0; i < aVerticesNumber; i++)
                for (int j = 0; j < aVerticesNumber; j++)
                {
                    if (aGraphMatrixToArray[i, j] != aGraphMatrixToArray[j, i]) 
                    {
                        aGraphMatrixToArray[i, j] = 0;
                        aGraphMatrixToArray[j, i] = 0;
                    }
                }
            if (theGraphNumber == 0) myFirstGraph = new Graph(aVerticesNumber, aGraphMatrixToArray);
            else mySecondGraph = new Graph(aVerticesNumber, aGraphMatrixToArray);
        }

        /// <summary>
        /// Get alroritm answer.
        /// </summary>
        public string GetAnswer()
        {
            return "";
        }

        /// <summary>
        /// Get graph isomorphism.
        /// </summary>
        public string[] GetIsomorphism()
        {
            return null;
        }

        /// <summary>
        /// Get alroritm time.
        /// </summary>
        public string GetTime()
        {
            return "";
        }

        /// <summary>
        /// Start alroritm.
        /// </summary>
        public void StartAlgoritm()
        {
            
        }
    }
}
