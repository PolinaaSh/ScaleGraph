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
        Graphics g;
        bool addNode ;

        public Form1()
        {
            InitializeComponent();
            dataHolder = new DataHolder();
           // dataHolder.Reading();
            graphBox.Image = dataHolder.Draw(ClientRectangle);
            g = CreateGraphics();
            addNode = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            addNode = true;
        }

        private void graphBox_Click(object sender, EventArgs e)
        {
            if (addNode)
            {
                MouseEventArgs e1 = (MouseEventArgs)e;
                dataHolder.WriteNode(dataHolder.CurrentVisible, dataHolder.CurrentColor, new Point(e1.X, e1.Y), dataHolder.CurrentRadius);
                graphBox.Image = dataHolder.Draw(ClientRectangle);
                addNode = false;
            }
        }

    }
}
