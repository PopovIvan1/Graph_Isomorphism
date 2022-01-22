using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using ModelInfrastructure;

namespace Model
{
    /// <summary>
    /// Class model - one of the three components of the MVC pattern.
    /// Designed to work with data.
    /// </summary>
    public class GraphModel : IGraphModel
    {
        private Graph myFirstGraph = new Graph(0, new[,] { { 0, 0 } });
        private Graph mySecondGraph = new Graph(0, new[,] { { 0, 0 } });
        private string myAlgoritmTime = "";
        private string myAlgoritmAnswer = "";
        private int[] myGraphIsomorphism;
        private List<int>[] mySimilarVertexFromSecondGraph;

        /// <summary>
        /// Upload graph from file.
        /// Verification and correction of input data
        /// </summary>
        public void UploadGraph(string theFileName, int theGraphNumber)
        {
            if (!File.Exists(theFileName)) return;
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
            if (theGraphNumber == 0)
            {
                myFirstGraph = new Graph(aVerticesNumber, aGraphMatrixToArray);
            }
            else
            {
                mySecondGraph = new Graph(aVerticesNumber, aGraphMatrixToArray);
            }
        }

        /// <summary>
        /// Get alroritm answer.
        /// </summary>
        public string GetAnswer()
        {
            myFirstGraph.ClearGraphVertexLebel();
            mySecondGraph.ClearGraphVertexLebel();
            return myAlgoritmAnswer;
        }

        /// <summary>
        /// Get graph isomorphism.
        /// </summary>
        public int[] GetIsomorphism()
        {
            return myGraphIsomorphism;
        }

        /// <summary>
        /// Get alroritm time.
        /// </summary>
        public string GetTime()
        {
            return myAlgoritmTime;
        }

        /// <summary>
        /// Start alroritm.
        /// </summary>
        public void StartAlgoritm()
        {
            myGraphIsomorphism = null;
            Stopwatch time = new Stopwatch();
            time.Start();
            if (myFirstGraph.getGraphVerticesCount() != mySecondGraph.getGraphVerticesCount())
            {
                myAlgoritmTime = time.Elapsed.ToString();
                myAlgoritmAnswer = "No";
                return;
            }
        }

        /// <summary>
        /// Get first or second graph.
        /// </summary>
        public IGraph GetGraph(int theGraphNumber)
        {
            if (theGraphNumber == 0) return myFirstGraph;
            else return mySecondGraph;
        }

        /// <summary>
        /// The input of the function is assigment. For example assigment [1 3 2 0] means 0->1, 1->3, 2->2, 3->0.
        /// That is, the vertex with number 0 is assigned to the vertex with number 1, and so on.
        /// For each vertex and its pair, lists of neighbors are compiled and compared.
        /// </summary>
        private bool checkAssignment(int[] theAssigment)
        {
            int[,] aFirstGraphMatrix = myFirstGraph.getGraphMatrix();
            int[,] aSecondGraphMatrix = mySecondGraph.getGraphMatrix();
            int aVertexNumber;
            int isAssigmetTrue;
            for (int i = 0; i < myFirstGraph.getGraphVerticesCount(); i++)
            {
                isAssigmetTrue = 0;
                List<int> aFirstVertexNeighbors = new List<int>(), aSecondVertexNeighbors = new List<int>();
                aVertexNumber = -1;
                for (int k = 0; k < myFirstGraph.getGraphVerticesCount(); k++)
                {
                    if (aFirstGraphMatrix[i, k] == 1) aFirstVertexNeighbors.Add(k);
                    if (theAssigment[k] == i) aVertexNumber = k;
                }
                for (int k = 0; k < myFirstGraph.getGraphVerticesCount(); k++)
                {
                    if (aSecondGraphMatrix[aVertexNumber, k] == 1) aSecondVertexNeighbors.Add(theAssigment[k]);
                }
                for (int k = 0; k < aFirstVertexNeighbors.Count; k++)
                {
                    isAssigmetTrue = 1;
                    for (int m = 0; m < aSecondVertexNeighbors.Count; m++)
                        if (aFirstVertexNeighbors[k] == aSecondVertexNeighbors[m]) isAssigmetTrue = 0;
                    if (isAssigmetTrue == 1) break;
                }
                if (isAssigmetTrue == 1) return false;
            }
            return true;
        }

        /// <summary>
        /// Recursive function to form assignments and send them for review.
        /// The function input is the current generated assignment and the index of the next viewed vertex.
        /// As soon as the current path contains all the vertices, the destination will go to check.
        /// </summary>
        private void formationAssignment(int[] theCurrentPath, int theNextVertexIndex)
        {
            if (myGraphIsomorphism != null) return;
            if (theNextVertexIndex > myFirstGraph.getGraphVerticesCount() - 1)
            {
                if (checkAssignment(theCurrentPath))
                {
                    myGraphIsomorphism = theCurrentPath;
                }
                return;
            }
            for (int i = 0; i < mySimilarVertexFromSecondGraph[theNextVertexIndex].Count(); i++)
            {
                int isVertexInCurrentPath = 0;
                for (int j = 0; j < theCurrentPath.Length; j++)
                    if (theCurrentPath[j] == mySimilarVertexFromSecondGraph[theNextVertexIndex][i]) isVertexInCurrentPath = 1;
                if (isVertexInCurrentPath == 0)
                {
                    int[] aNextCurrentPath = new int[theCurrentPath.Length + 1];
                    for (int m = 0; m < theCurrentPath.Length; m++)
                        aNextCurrentPath[m] = theCurrentPath[m];
                    aNextCurrentPath[theCurrentPath.Length] = mySimilarVertexFromSecondGraph[theNextVertexIndex][i];
                    formationAssignment(aNextCurrentPath, theNextVertexIndex + 1);
                }
            }
        }
    }
}
