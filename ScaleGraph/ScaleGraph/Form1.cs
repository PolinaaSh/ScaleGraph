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
        int currentVisible;
        int currentRadius;
        Color currentColor;

        public Form1()
        {
            InitializeComponent();
            dataHolder = new DataHolder();
            dataHolder.Reading();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            dataHolder.WriteNode(currentVisible, currentColor, new Point(20,20), currentRadius);
        }
    }
}
