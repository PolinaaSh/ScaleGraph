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
        DataHolder dataHolder;
        bool addNode ;
        bool addEdge;
        MouseEventArgs node1;
        int edgeCount;

        public Form1()
        {
            InitializeComponent();
            dataHolder = new DataHolder();
            graphBox.Image = dataHolder.Draw(ClientRectangle, false, new Point (0,0),new Point (0,0));
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
                dataHolder.AddNode(dataHolder.CurrentVisible, dataHolder.CurrentColor, new Point(e1.X, e1.Y), dataHolder.CurrentRadius);
                graphBox.Image = dataHolder.Draw(ClientRectangle, false,new Point (0,0), new Point (0,0));
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
                    dataHolder.AddEdge(node1.Location, ((MouseEventArgs)e).Location, dataHolder.CurrentColor,20);
                    graphBox.Image = dataHolder.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0));
                    edgeCount = 2;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataHolder.WriteData();
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
                graphBox.Image = dataHolder.Draw(ClientRectangle, true, node1.Location, e.Location);
            }
        }

    }
}
