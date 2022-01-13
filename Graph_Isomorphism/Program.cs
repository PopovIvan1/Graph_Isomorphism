using System;
using System.Windows.Forms;
using View;
using Controller;
using Model;

namespace Graph_Isomorphism
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var aView = new GraphView();
            new GraphController(new GraphModel(), aView);
            Application.Run(aView);
        }
    }
}
