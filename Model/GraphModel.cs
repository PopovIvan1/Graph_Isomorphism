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
        private string myAlgoritmAnswer = "No";
        private int[] myGraphIsomorphism;
        private List<int>[] mySimilarVertexFromSecondGraph;
        private int isHeuristicNecessary;

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
        /// Start isomorphism alroritm. First the initial equivalence classes are initialized.
        /// Further, new equivalence classes are formed based on the labels of the current level.
        /// Comparing new and old classes. If new classes appear, process is repeated. Else the function of forming and checking appointments is launched.
        /// If necessary, the heuristic algorithm is run.
        /// </summary>
        public void StartAlgoritm()
        {
            isHeuristicNecessary = 0;
            myGraphIsomorphism = null;
            Stopwatch time = new Stopwatch();
            time.Start();
            if (myFirstGraph.GetGraphVerticesCount() != mySecondGraph.GetGraphVerticesCount())
            {
                myAlgoritmTime = time.Elapsed.ToString();
                myAlgoritmAnswer = "No";
                return;
            }
            int anEquivalenceClassesCount = 0;
            int anOldEquivalenceClassesCount = -1;
            int aLabelLevel = 0;
            int[] aCurrentAssignment = new int[myFirstGraph.GetGraphVerticesCount()];
            int[] isVertexInAssignment = new int[myFirstGraph.GetGraphVerticesCount()];
            int[,] anEquivalenceClasses = new int[myFirstGraph.GetGraphVerticesCount(), 2];
            while (anEquivalenceClassesCount != anOldEquivalenceClassesCount)
            {
                for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
                {
                    anEquivalenceClasses[i, 0] = -1;
                    anEquivalenceClasses[i, 1] = -1;
                    aCurrentAssignment[i] = -1;
                    isVertexInAssignment[i] = -1;
                }
                myFirstGraph.SetGraphVertexLabel(aLabelLevel);
                mySecondGraph.SetGraphVertexLabel(aLabelLevel);
                aLabelLevel++;
                List<string> aFirstGraphLabel = myFirstGraph.GetGraphVertexLabel();
                List<string> aSecondGraphLabel = mySecondGraph.GetGraphVertexLabel();
                for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
                    for (int j = 0; j < myFirstGraph.GetGraphVerticesCount(); j++)
                    {
                        if (aFirstGraphLabel[i] == aSecondGraphLabel[j])
                        {
                            if (anEquivalenceClasses[j, 1] == -1)
                            {
                                anEquivalenceClasses[i, 0] = i;
                                anEquivalenceClasses[j, 1] = i;
                            }
                            else anEquivalenceClasses[i, 0] = anEquivalenceClasses[j, 1];
                            if (aCurrentAssignment[i] == -1 && isVertexInAssignment[j] == -1)
                            {
                                aCurrentAssignment[i] = j;
                                isVertexInAssignment[j] = 0;
                            }
                        }
                    }
                List<int> aDifferentEquivalenceClasses = new List<int>();
                for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
                {
                    if (aDifferentEquivalenceClasses.Count == 0) aDifferentEquivalenceClasses.Add(anEquivalenceClasses[i, 0]);
                    else
                    {
                        int isClassInList = 0;
                        for (int j = 0; j < aDifferentEquivalenceClasses.Count; j++)
                        {
                            if (aDifferentEquivalenceClasses[j] == anEquivalenceClasses[i, 0]) isClassInList = 1;
                        }
                        if (isClassInList == 0) aDifferentEquivalenceClasses.Add(anEquivalenceClasses[i, 0]);
                    }
                }
                anEquivalenceClassesCount = aDifferentEquivalenceClasses.Count;
                for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
                {
                    if (aCurrentAssignment[i] == -1)
                    {
                        myAlgoritmTime = time.Elapsed.ToString();
                        myAlgoritmAnswer = "No";
                        return;
                    }
                }
                if (anEquivalenceClassesCount == anOldEquivalenceClassesCount)
                {
                    setSimilarVertexFromSecondGraph(anEquivalenceClasses);
                    formationAssignment(new int[0], 0);
                    while (isHeuristicNecessary == 200)
                    {
                        isHeuristicNecessary = 0;
                        Heuristic aHeuristic = new Heuristic();
                        anEquivalenceClasses = aHeuristic.GenerateNewClasses(myFirstGraph, mySecondGraph, anEquivalenceClasses);
                        setSimilarVertexFromSecondGraph(anEquivalenceClasses);
                        formationAssignment(new int[0], 0);
                    }
                    if (myGraphIsomorphism == null)
                    {
                        myAlgoritmAnswer = "No";
                    }
                    else
                    {
                        myAlgoritmAnswer = "Yes";
                    }
                    myAlgoritmTime = time.Elapsed.ToString();
                    return;
                }
                anOldEquivalenceClassesCount = anEquivalenceClassesCount;
                anEquivalenceClassesCount = -1;
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
            int[,] aFirstGraphMatrix = myFirstGraph.GetGraphMatrix();
            int[,] aSecondGraphMatrix = mySecondGraph.GetGraphMatrix();
            int isAssigmetTrue;
            for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
            {
                isAssigmetTrue = 0;
                List<int> aFirstVertexNeighbors = new List<int>(), aSecondVertexNeighbors = new List<int>();
                for (int j = 0; j < myFirstGraph.GetGraphVerticesCount(); j++)
                {
                    if (aFirstGraphMatrix[i, j] == 1) aFirstVertexNeighbors.Add(theAssigment[j]);
                }
                for (int j = 0; j < myFirstGraph.GetGraphVerticesCount(); j++)
                {
                    if (aSecondGraphMatrix[theAssigment[i], j] == 1) aSecondVertexNeighbors.Add(j);
                }
                for (int j = 0; j < aFirstVertexNeighbors.Count; j++)
                {
                    isAssigmetTrue = 1;
                    for (int m = 0; m < aSecondVertexNeighbors.Count; m++)
                        if (aFirstVertexNeighbors[j] == aSecondVertexNeighbors[m]) isAssigmetTrue = 0;
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
            if (theNextVertexIndex > myFirstGraph.GetGraphVerticesCount() - 1)
            {
                if (isHeuristicNecessary != 200) isHeuristicNecessary++;
                if (checkAssignment(theCurrentPath))
                {
                    myGraphIsomorphism = theCurrentPath;
                }
                return;
            }
            if (isHeuristicNecessary == 200)
            {
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

        private void setSimilarVertexFromSecondGraph(int[,] theEquivalenceClasses)
        {
            mySimilarVertexFromSecondGraph = new List<int>[myFirstGraph.GetGraphVerticesCount()];
            for (int i = 0; i < myFirstGraph.GetGraphVerticesCount(); i++)
            {
                mySimilarVertexFromSecondGraph[i] = new List<int>();
                for (int j = 0; j < myFirstGraph.GetGraphVerticesCount(); j++)
                    if (theEquivalenceClasses[i, 0] == theEquivalenceClasses[j, 1])
                        mySimilarVertexFromSecondGraph[i].Add(j);
            }
        }
    }
}
