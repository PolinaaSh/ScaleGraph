using ScaleGraph.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleGraph
{
    public partial class Form1 : Form
    {
        Edit.EditManger manager;
        bool addNode;
        bool addEdge;
        int edgeCount;

        MouseEventArgs node1;

        public Form1()
        {
            InitializeComponent();

            manager = new Edit.EditManger();

            graphBox.Image = manager.Draw(ClientRectangle, false, new Point (0,0),new Point (0,0),manager.Scale);

            addNode = false;
            edgeCount = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            addEdge = false;
            addNode = true;
        }

        private void graphBox_Click(object sender, EventArgs e)
        {
            if (addNode)
            {
                MouseEventArgs e1 = (MouseEventArgs)e;
                manager.AddNode(ClientRectangle,new PointF(e1.X, e1.Y));
                graphBox.Image = manager.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0), manager.Scale);
                addNode = false;
            }
            else if(addEdge)
            {
                if(edgeCount==2)
                {
                    node1 = (MouseEventArgs)e;
                    edgeCount--;
                }
                else if(edgeCount == 1)
                {
                    manager.AddEdge(ClientRectangle, node1.Location, ((MouseEventArgs)e).Location, manager.CurrentColor, 10);
                    graphBox.Image = manager.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0), manager.Scale);
                    edgeCount = 2;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            manager.SaveGraph();
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            addNode = false;
            addEdge = true;
        }

        private void graphBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(addEdge && edgeCount == 1)
            {
                graphBox.Image = manager.Draw(ClientRectangle, true, node1.Location, e.Location, manager.Scale);
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
                manager.CurrentVisible = (int)((double)trackBar.Value/2 + 0.5);
                manager.Scale = 0.9F + trackBar.Value * 0.1F;

                graphBox.Image = manager.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0), manager.Scale);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
