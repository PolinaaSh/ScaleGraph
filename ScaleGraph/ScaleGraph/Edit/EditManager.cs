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
        private int currentVisible;
        private Color currentColor;
        private float currentRadius;
        private float scale;

        private Graph graph;

        private Data data;
        private Drawing drawManager;

        public EditManger()
        {
            data = new Data("Nodes.txt", "Edges.txt");

            CreateGraph();

            drawManager = new Drawing(graph);
            currentVisible = 1;
            scale = 1;
            currentColor = Color.Black;
            currentRadius = 5F;
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

        public float Scale
        {
            get
            {
                return this.scale;

            }
            set
            {
                this.scale = value;
            }
        }



        private void CreateGraph()
        {
            List<Node> nodes = data.ReadNodes();
            List<Edge> edges = data.ReadEdges(nodes);
            graph = new Graph(nodes, edges);
        }

        public void SaveGraph()
        {
            data.WriteData(graph);
        }

        public void AddNode( Rectangle rect,Point coordinate)
        {
           graph.AddNode(currentVisible, currentColor,  CalcilateRealCoordinate(rect,coordinate)/*coordinate*/, currentRadius);
        }

        public void AddEdge(Rectangle rect, Point firstCoordinate, Point secondCoordinate, Color color, float width)
        {
            graph.AddEdge(currentVisible,firstCoordinate, secondCoordinate, color, width, drawManager.ScalePoints);
        }

        public Bitmap Draw(Rectangle rect, bool drawEdge, Point p1, Point p2, float k)
        {
            return drawManager.DrawGraph(rect, k, drawEdge,  p1, p2, currentVisible);
        }

        private Point CalcilateRealCoordinate(Rectangle rect,Point coordinate)
        {
            int stepX = rect.Width / 2;
            int stepY = rect.Height / 2;

            float scaleRadius = (float)currentRadius * scale / currentVisible;

            float coordinateX = coordinate.X - stepX;
            coordinateX /= scale;
            coordinateX += stepX + scaleRadius;

            float coordinateY = coordinate.Y - stepY;
            coordinateY /= scale;
            coordinateY += stepY + scaleRadius;

            return new Point((int)coordinateX, (int)coordinateY);

        }

       
    }
}
