using System;
using System.Drawing;
using System.Windows.Forms;
using ViewInfrastructure;

namespace View
{
    /// <summary>
    /// Class view - one of the three components of the MVC pattern.
    /// Designed to display data.
    /// </summary>
    public partial class GraphView : Form, IGraphView
    {
        public Action UploadFirstGraph { get; set; }
        public Action UploadSecondGraph { get; set; }
        public  Action GetAnswer { get; set; }

        private Graphics aFirstGraphics;
        private Graphics aSecondGraphics;

        /// <summary>
        /// Instantiating the view class.
        /// </summary>
        public GraphView()
        {
            InitializeComponent();
            myFirstGraphBotton.Click += uploadFirstGraph;
            mySecondGraphBotton.Click += uploadSecondGraph;
            myAnswerBotton.Click += getAnswer;
            aFirstGraphics = myFirstGraphPictureBox.CreateGraphics();
            aSecondGraphics = mySecondGraphPictureBox.CreateGraphics();
        }

        /// <summary>
        /// Display the running time of the algorithm.
        /// </summary>
        public void DisplayAlgorithmTime(string theTime)
        {
            myTimeLabel.Text = "Time: ";
            myTimeLabel.Text += theTime;
        }

        /// <summary>
        /// Display the algorithm answer.
        /// </summary>
        public void DisplayAlgorithmAnswer(string theAnswer)
        {
            myAnswerLabel.Text = "Answer: ";
            myAnswerLabel.Text += theAnswer;
        }

        /// <summary>
        /// Display graph isomorphism.
        /// </summary>
        public void DisplayGraphIsomorphism(string[] theIsomorphism)
        {
            myAnswerTextBox.Clear();
            for (int i = 0; i < theIsomorphism.Length; i++) myAnswerTextBox.Text = myAnswerTextBox.Text + theIsomorphism[i] + '\n';
        }

        /// <summary>
        /// Display graph edge.
        /// </summary>
        public void DrawGraphEdge(int theGraphNumber, float x1, float x2, float y1, float y2)
        {
            if (theGraphNumber == 0)
            {
                aFirstGraphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            }
            else
            {
                aSecondGraphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            }
        }

        /// <summary>
        /// Display graph vertex.
        /// </summary>
        public void DrawGraphVertex(int theGraphNumber, float x, float y, float width, float height, string theContent, string theColor, int theDeltaX = 3)
        {
            if (theGraphNumber == 0)
            {
                aFirstGraphics.FillEllipse(new SolidBrush(Color.FromName(theColor)), x, y, width, height);
                aFirstGraphics.DrawString(theContent, new Font("Arial", 11), new SolidBrush(Color.Black), x + theDeltaX, y + 3);
                aFirstGraphics.DrawEllipse(new Pen(Color.Black), x, y, width, height);
            }
            else
            {
                aSecondGraphics.FillEllipse(new SolidBrush(Color.FromName(theColor)), x, y, width, height);
                aSecondGraphics.DrawString(theContent, new Font("Arial", 11), new SolidBrush(Color.Black), x + theDeltaX, y + 3);
                aSecondGraphics.DrawEllipse(new Pen(Color.Black), x, y, width, height);
            }
        }

        private void uploadFirstGraph(object sender, EventArgs e)
        {
            UploadFirstGraph?.Invoke();
        }

        private void uploadSecondGraph(object sender, EventArgs e)
        {
            UploadSecondGraph?.Invoke();
        }

        private void getAnswer(object sender, EventArgs e)
        {
            GetAnswer?.Invoke();
        }

        /// <summary>
        /// Upload text file.
        /// </summary>
        public string UploadFile()
        {
            OpenFileDialog aDialog = new OpenFileDialog();
            if (aDialog.ShowDialog() == DialogResult.OK)
            {
                return aDialog.FileName;
            }
            else return null;
        }
    }
}
