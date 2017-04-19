using ScaleGraph.Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Edit
{
    class Editing
    {
        List<Node> nodes;
        List<Edge> edges;
        public Editing(List<Node> nodes, List<Edge> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
        }

        public void AddNode(int levelVisible, Color color, Point coordinate, int radius, int number)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number));
        }

        public void AddEdge(Node nodeFirst, Node nodeSecond, Color color, int width)
        {
            edges.Add(new Edge(nodeFirst, nodeSecond, color, width));
            //first.AddEdge(new Edge(nodeFirst, nodeSecond , color,width));
            // second.AddEdge(new Edge(nodeFirst, nodeSecond, color,width));
        }

       
        public Bitmap DrawGraph(Rectangle r, int k, bool drawEdge, Point p1, Point p2)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (Node n in nodes)
                {
                    Brush brush = new SolidBrush(n.Color);
                    int scaleRadius = n.Radius * 2 * k;
                    g.FillEllipse(brush, n.Coordinate.X - scaleRadius / 2, n.Coordinate.Y - scaleRadius / 2,scaleRadius, scaleRadius);
                    brush.Dispose();
                }

                foreach(Edge edge in edges)
                {
                    Pen pen = new Pen(edge.Color,edge.Width);
                    g.DrawLine(pen,edge.NodeFirst.Coordinate, edge.NodeSecond.Coordinate);
                    pen.Dispose();
                }
                if(drawEdge)
                {
                    Pen p = new Pen(Color.Black,20);
                    g.DrawLine(p, p1, p2);
                    p.Dispose();
                }
            }
            return bitmap;
        }
    }
}
