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

        public void AddNode( Rectangle rect,PointF coordinate)
        {
           graph.AddNode(currentVisible, currentColor,  CalcilateRealCoordinate(rect,coordinate)/*coordinate*/, currentRadius);
        }

        public void AddEdge(Rectangle rect, PointF firstCoordinate, PointF secondCoordinate, Color color, float width)
        {
            graph.AddEdge(currentVisible, CalcilateRealCoordinate(rect, firstCoordinate), CalcilateRealCoordinate( rect, secondCoordinate), color, width);
        }

        public Bitmap Draw(Rectangle rect, bool drawEdge, PointF p1, PointF p2, float k)
        {
            return drawManager.DrawGraph(rect, k, drawEdge, CalcilateRealCoordinate(rect, p1), p2, currentVisible);
        }

        private PointF CalcilateRealCoordinate(Rectangle rect,PointF coordinate)
        {
            float stepX = rect.Width / 2;
            float stepY = rect.Height / 2;

            float scaleRadius = (float)currentRadius * scale / currentVisible;

            float coordinateX = coordinate.X - stepX;
            coordinateX /= scale;
            coordinateX += scaleRadius + stepX;

            float coordinateY = coordinate.Y - stepY;
            coordinateY /= scale;
            coordinateY += scaleRadius + stepY;

            return new PointF(coordinateX, coordinateY);

        }

       
    }
}
