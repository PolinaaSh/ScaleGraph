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

        public void AddNode(int levelVisible, Color color, PointF coordinate, int radius, int number)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number));
        }

        public void AddEdge(int levelVisible,Node nodeFirst, Node nodeSecond, Color color, int width)
        {
            edges.Add(new Edge(levelVisible, nodeFirst, nodeSecond, color, width));
        }

       
        public Bitmap DrawGraph(Rectangle r, float k, bool drawEdge, PointF p1, PointF p2, int currVisible)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (Node n in nodes)
                {
                    if (n.LevelVisible <= currVisible)
                    {
                        Brush brush = new SolidBrush(n.Color);
                        float scaleRadius = n.Radius * k;
                        g.FillEllipse(brush,k*( n.Coordinate.X - scaleRadius),k*( n.Coordinate.Y - scaleRadius), scaleRadius*2, scaleRadius*2);
                        brush.Dispose();
                    }
                }

                foreach (Edge edge in edges)
                {
                    if (edge.LevelVisible <= currVisible)
                    {
                        float scaleRadius = edge.NodeFirst.Radius * k;
                        Pen pen = new Pen(edge.Color, edge.Width*k);

                        g.DrawLine(pen, edge.NodeFirst.Coordinate.X * k-scaleRadius , edge.NodeFirst.Coordinate.Y * k-scaleRadius, edge.NodeSecond.Coordinate.X * k - scaleRadius, edge.NodeSecond.Coordinate.Y * k - scaleRadius);
                       
                        pen.Dispose();
                    }
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
