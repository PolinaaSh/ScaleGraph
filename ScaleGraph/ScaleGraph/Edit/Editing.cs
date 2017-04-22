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
        Dictionary<int, PointF> scalePoints;

        public Editing(List<Node> nodes, List<Edge> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
            scalePoints = new Dictionary<int, PointF>();
        }

        public void AddNode(int levelVisible, Color color, PointF coordinate, float radius, int number)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number));
        }

        public void AddEdge(int levelVisible,Node nodeFirst, Node nodeSecond, Color color, float width)
        {
            edges.Add(new Edge(levelVisible, nodeFirst, nodeSecond, color, width));
        }

       
        public Bitmap DrawGraph(Rectangle r, float k, bool drawEdge, PointF p1, PointF p2, int currVisible)
        {
            float stepX = r.Width / 2;
            float stepY = r.Height / 2;

            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            scalePoints.Clear();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (Node n in nodes)
                {
                    if (n.LevelVisible <= currVisible)
                    {
                        Brush brush = new SolidBrush(n.Color);
                        float scaleRadius = (float) n.Radius * k;

                        float coordinateX = n.Coordinate.X - scaleRadius - stepX;
                        coordinateX *= k;
                        coordinateX += stepX;

                        float coordinateY = n.Coordinate.Y - scaleRadius - stepY;
                        coordinateY *= k;
                        coordinateY += stepY;

                        g.FillEllipse(brush, coordinateX, coordinateY, scaleRadius * 2, scaleRadius * 2);
                       
                        scalePoints.Add(n.Number, new PointF(coordinateX, coordinateY));                           
                                          
                        brush.Dispose();
                    }
                }

                foreach (Edge edge in edges)
                {
                    if (edge.LevelVisible <= currVisible)
                    {
                        float scaleRadius = (float)edge.NodeFirst.Radius * k;

                        Pen pen = new Pen(edge.Color, scaleRadius*2);
                      
                        PointF firstPoint = scalePoints[edge.NodeFirst.Number];
                        PointF secondPoint = scalePoints[edge.NodeSecond.Number];

                        g.DrawLine(pen, firstPoint.X + scaleRadius, firstPoint.Y + scaleRadius, secondPoint.X + scaleRadius, secondPoint.Y + scaleRadius);
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
