using ScaleGraph.Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Bitmap DrawGraph(Rectangle r)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (Node n in nodes)
                {
                    Brush brush = new SolidBrush(n.Color);
                    g.FillEllipse(brush,n.Coordinate.X,n.Coordinate.Y, n.Radius*2,n.Radius*2);
                    brush.Dispose();
                }

                foreach(Edge edge in edges)
                {
                    Pen pen = new Pen(edge.Color,edge.Width);
                    g.DrawLine(pen,edge.NodeFirst.Coordinate, edge.NodeSecond.Coordinate);
                    pen.Dispose();
                }
            }
            return bitmap;
        }
    }
}
