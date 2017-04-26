using ScaleGraph.Core;
using ScaleGraph.Draw;
using ScaleGraph.MyGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Edit
{
    class EditManger
    {

        private int maxNodeNumber;
        private int currentVisible;
        private Color currentColor;
        private float currentRadius;

        private Graph graph;

        private Data data;
        private Drawing drawManager;

        public EditManger()
        {
            data = new Data("Nodes.txt", "Edges.txt");

            CreateGraph();

            drawManager = new Drawing(graph);
            currentVisible = 1;
            currentColor = Color.Black;
            currentRadius = 10F;
        }

        public int CurrentVisible
        {
            get
            {
                return currentVisible;
            }
            set
            {
                currentVisible = value;
            }
        }

        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                currentColor = value;
            }
        }

        public float CurrentRadius
        {
            get
            {
                return currentRadius;
            }
            set
            {
                currentRadius = value;
            }
        }



        private void CreateGraph()
        {
            List<Node> nodes = data.ReadNodes();
            List<Edge> edges = data.ReadEdges(nodes);
            graph = new Graph(nodes, edges);
            maxNodeNumber = graph.Nodes.Count;
        }

        public void SaveGraph()
        {
            data.WriteData(graph);
        }

        public void AddNode(int levelVisible, Color color, PointF coordinate, float radius)
        {
           graph.AddNode(levelVisible, color, coordinate, radius, ++maxNodeNumber);
        }

        public void AddEdge(PointF firstCoordinate, PointF secondCoordinate, Color color, float width)
        {
            graph.AddEdge(currentVisible, firstCoordinate, secondCoordinate, color, width);
        }

        public Bitmap Draw(Rectangle rect, bool drawEdge, PointF p1, PointF p2, float k)
        {
            return drawManager.DrawGraph(rect, k, drawEdge, p1, p2, currentVisible);
        }       
       
    }
}
