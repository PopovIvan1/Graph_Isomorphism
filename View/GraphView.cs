using System;
using System.Drawing;
using System.Windows.Forms;
using ViewInfrastructure;

namespace View
{
    public partial class GraphView : Form, IGraphView
    {
        public Action UploadFirstGraph { get; set; }
        public Action UploadSecondGraph { get; set; }
        public  Action GetAnswer { get; set; }

        /// <summary>
        /// Instantiating the view class.
        /// </summary>
        public GraphView()
        {
            InitializeComponent();
            myFirstGraphBotton.Click += uploadFirstGraph;
            mySecondGraphBotton.Click += uploadSecondGraph;
            myAnswerBotton.Click += getAnswer;
        }

        /// <summary>
        /// Display the running time of the algorithm.
        /// </summary>
        public void DisplayAlgorithmTime(string theTime)
        {
            myTimeLabel.Text += theTime;
        }

        /// <summary>
        /// Display the algorithm answer.
        /// </summary>
        public void DisplayAlgorithmAnswer(string theAnswer)
        {
            myAnswerLabel.Text += theAnswer;
        }

        /// <summary>
        /// Display graph isomorphism.
        /// </summary>
        public void DisplayGraphIsomorphism(string[] theIsomorphism)
        {
            for (int i = 0; i < theIsomorphism.Length; i++) myAnswerTextBox.Text = myAnswerTextBox.Text + theIsomorphism[i] + '\n';
        }

        /// <summary>
        /// Display graph label.
        /// </summary>
        public void DisplayGraphLabel(int theGraphNumber, string[] theLabel)
        {
            if (theGraphNumber == 0) for (int i = 0; i < theLabel.Length; i++) myFirstGraphLabelTextBox.Text = myFirstGraphLabelTextBox.Text + theLabel[i] + '\n';
            else for (int i = 0; i < theLabel.Length; i++) mySecondGraphLabelTextBox.Text = mySecondGraphLabelTextBox.Text + theLabel[i] + '\n';
        }

        /// <summary>
        /// Display graph edge.
        /// </summary>
        public void DrawGraphEdge(int theGraphNumber, float x1, float x2, float y1, float y2)
        {
            Bitmap aBitmap;
            if (theGraphNumber == 0)
            {
                aBitmap = new Bitmap(myFirstGraphPictureBox.Width, myFirstGraphPictureBox.Height);
                myFirstGraphPictureBox.Image = aBitmap;
            }
            else
            {
                aBitmap = new Bitmap(mySecondGraphPictureBox.Width, mySecondGraphPictureBox.Height);
                mySecondGraphPictureBox.Image = aBitmap;
            }
            Graphics aGraphics = Graphics.FromImage(aBitmap);
            aGraphics.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
        }

        /// <summary>
        /// Display graph vertex.
        /// </summary>
        public void DrawGraphVertex(int theGraphNumber, float x, float y, float width, float height, string theContent, string theColor)
        {
            Bitmap aBitmap;
            if (theGraphNumber == 0)
            {
                aBitmap = new Bitmap(myFirstGraphPictureBox.Width, myFirstGraphPictureBox.Height);
                myFirstGraphPictureBox.Image = aBitmap;
            }
            else
            {
                aBitmap = new Bitmap(mySecondGraphPictureBox.Width, mySecondGraphPictureBox.Height);
                mySecondGraphPictureBox.Image = aBitmap;
            }
            Graphics aGraphics = Graphics.FromImage(aBitmap);
            aGraphics.DrawEllipse(new Pen(Color.Black), x, y, width, height);
            aGraphics.FillEllipse(new SolidBrush(Color.FromName(theColor)), x, y, width, height);
            aGraphics.DrawString(theContent, new Font("Arial", 11), new SolidBrush(Color.Black), x + 3, y + 3);
        }

        /// <summary>
        /// Clear the view.
        /// </summary>
        public void ViewClear()
        {
            myFirstGraphLabelTextBox.Clear();
            mySecondGraphLabelTextBox.Clear();
            myTimeLabel.Text = "Time: ";
            myAnswerLabel.Text = "Answer: ";
            myAnswerTextBox.Clear();
            myFirstGraphPictureBox.Image = null;
            mySecondGraphPictureBox.Image = null;
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
