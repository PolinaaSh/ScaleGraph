using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaleGraph.MyGraph;
using System.Drawing;

namespace ScaleGraph.Draw
{
    class Drawing
    {
        private Graph graph;
        private Dictionary<int, PointF> scalePoints;

        public Drawing(Graph graph)
        {
            this.graph = graph;
            scalePoints = new Dictionary<int, PointF>();
        }

        private void DrawNodes(Graphics g, Rectangle r, float k, bool drawEdge, int currVisible)
        {

            float stepX = r.Width / 2;
            float stepY = r.Height / 2;
            foreach (Node n in graph.Nodes)
            {
                if (n.LevelVisible <= currVisible)
                {
                    Brush brush = new SolidBrush(n.Color);
                    float scaleRadius = (float)n.Radius * k;

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
        }

        private void DrawEdges(Graphics g, Rectangle r, float k, bool drawEdge, PointF p1, PointF p2, int currVisible)
        {
            foreach (Edge edge in graph.Edges)
            {
                if (edge.LevelVisible <= currVisible)
                {
                    float scaleRadius = (float)edge.NodeFirst.Radius * k;

                    Pen pen = new Pen(edge.Color, scaleRadius * 2);

                    PointF firstPoint = scalePoints[edge.NodeFirst.Number];
                    PointF secondPoint = scalePoints[edge.NodeSecond.Number];

                    g.DrawLine(pen, firstPoint.X + scaleRadius, firstPoint.Y + scaleRadius, secondPoint.X + scaleRadius, secondPoint.Y + scaleRadius);
                    pen.Dispose();
                }
            }
            if (drawEdge)
            {
                Pen p = new Pen(Color.Black, 20);
                g.DrawLine(p, p1, p2);
                p.Dispose();
            }
        }


        public Bitmap DrawGraph(Rectangle r, float k, bool drawEdge, PointF p1, PointF p2, int currVisible)
        {

            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            scalePoints.Clear();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                DrawNodes(g, r, k, drawEdge, currVisible);
                DrawEdges(g,r,k,drawEdge,p1, p2, currVisible);
               
            }
            return bitmap;
        }
    }
}
