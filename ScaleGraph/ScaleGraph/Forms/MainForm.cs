using ScaleGraph.Core;
using ScaleGraph.Edit;
using ScaleGraph.Forms;
using ScaleGraph.MyGraph;
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
    public partial class MainForm : Form
    {
        Edit.EditManger manager;
        bool addNode;
        bool addEdge;

        bool removeNode;
        bool removeEdge;

        int edgeCount;

        MouseEventArgs node1;

        public MainForm()
        {
            InitializeComponent();

            manager = new Edit.EditManger();

            DrawGraph();

            addNode = false;
            edgeCount = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            addEdge = false;
            removeNode = false;
            removeEdge = false;
            addNode = true;
        }

        private void graphBox_Click(object sender, EventArgs e)
        {
            if (addNode)
            {
                MouseEventArgs e1 = (MouseEventArgs)e;
                AddNodeForm addForm = new AddNodeForm();
                addForm.ShowDialog(this);
                if (FormDialog.nodeName != String.Empty)
                    manager.AddNode(ClientRectangle,new Point(e1.X, e1.Y), FormDialog.nodeName);
                FormDialog.nodeName = String.Empty;
                DrawGraph();
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
                    AddEdgeForm addForm = new AddEdgeForm();
                    addForm.ShowDialog(this);
                    if (FormDialog.edgeWeight>0)
                        manager.AddEdge(node1.Location, ((MouseEventArgs)e).Location,  FormDialog.edgeWeight,10);
                    FormDialog.edgeWeight = -1;
                    DrawGraph();
                    edgeCount = 2;
                    addEdge = false;
                }
            }
            else if (removeNode)
            {
                manager.RemoveNode(new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
                DrawGraph();
                removeNode = false;
            }
            else if(removeEdge)
            {
                manager.RemoveEdge(new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
                DrawGraph();
                removeEdge = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            manager.SaveGraph();
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            addNode = false;
            removeNode = false;
            removeEdge = false;
            addEdge = true;
        }

        private void graphBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(addEdge && edgeCount == 1)
            {
                graphBox.Image = manager.Draw(ClientRectangle, true, node1.Location, e.Location);
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
                manager.CurrentVisible = (int)((double)trackBar.Value/2 + 0.5);
                manager.Scale = 0.9F + trackBar.Value * 0.1F;
                DrawGraph();                
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void RemoveNodeButton_Click(object sender, EventArgs e)
        {
            addNode = false;
            addEdge = false;
            removeEdge = false;
            removeNode = true;
        }

        public void DrawGraph()
        {
            graphBox.Image = manager.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0));
        }

        private void removeEdgeButton_Click(object sender, EventArgs e)
        {
            removeEdge = true;
            addNode = false;
            addEdge = false;
            removeNode = false;
        }

        private void searchPathButton_Click(object sender, EventArgs e)
        {
            FormDialog.nodes = manager.Graph.Nodes;
            SearchPathForm searchform = new SearchPathForm();
            searchform.ShowDialog(this);
            if (FormDialog.from != String.Empty && FormDialog.to != String.Empty)
            {
                List<Node> res = manager.Search(FormDialog.from, FormDialog.to);
                manager.CurrentVisible = minVisible(res);

                trackBar.Value = minVisible(res)*2 - 1;
                manager.Scale = 0.9F + trackBar.Value * 0.1F;

                graphBox.Image = manager.DrawPath(ClientRectangle, new Point(0, 0), new Point(0, 0), res);
            }
        }
        private int minVisible(List<Node> nodes)
        {
            int min = 1;
            foreach (Node n in nodes)
            {
                if (n.LevelVisible > min)
                    min = n.LevelVisible;
            }
            return min;
        }
    }
}
