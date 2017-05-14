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
       
        int edgeCount;

        MouseEventArgs node1;

        public MainForm()
        {
            InitializeComponent();

            showRadioButton.Checked = true;
            manager = new Edit.EditManger();

            DrawGraph();

            edgeCount = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void graphBox_Click(object sender, EventArgs e)
        {
            if (addNodeRadioButton.Checked)
            {
                MouseEventArgs e1 = (MouseEventArgs)e;
                AddNodeForm addForm = new AddNodeForm();
                addForm.ShowDialog(this);
                if (FormDialog.nodeName != String.Empty)
                    manager.AddNode(ClientRectangle,new Point(e1.X, e1.Y), FormDialog.nodeName);
                FormDialog.nodeName = String.Empty;
                DrawGraph();
            }
            else if(addEdgeRadioButton.Checked)
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
                }
            }
            else if (removeNodeRadioButton.Checked)
            {
                manager.RemoveNode(new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
                DrawGraph();
            }
            else if(removeEdgeRadioButton.Checked)
            {
                manager.RemoveEdge(new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
                DrawGraph();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            manager.SaveGraph();
        }

        private void graphBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(addEdgeRadioButton.Checked && edgeCount == 1)
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

        public void DrawGraph()
        {
            graphBox.Image = manager.Draw(ClientRectangle, false, new Point(0, 0), new Point(0, 0));
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

        private void searchRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (searchRadioButton.Checked)
            {
                FormDialog.nodes = manager.Graph.Nodes;
                SearchPathForm searchform = new SearchPathForm();
                searchform.ShowDialog(this);
                if (FormDialog.from != String.Empty && FormDialog.to != String.Empty)
                {
                    List<Node> res = manager.Search(FormDialog.from, FormDialog.to);
                    manager.CurrentVisible = minVisible(res);

                    trackBar.Value = minVisible(res) * 2 - 1;
                    manager.Scale = 0.9F + trackBar.Value * 0.1F;

                    graphBox.Image = manager.DrawPath(ClientRectangle, new Point(0, 0), new Point(0, 0), res);
                }
            }
        }
    }
}
