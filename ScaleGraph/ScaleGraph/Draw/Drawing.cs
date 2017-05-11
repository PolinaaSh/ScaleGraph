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
        private Dictionary<string, Point> scalePoints;

        public Drawing(Graph graph)
        {
            this.graph = graph;
            scalePoints = new Dictionary<string, Point>();
        }

        public Dictionary<string,Point> ScalePoints
        {
            get
            {
                return this.scalePoints;
            }
        }

        private Point Scale(Rectangle rect,float scale, Node n )
        {
            float stepX = rect.Width / 2;
            float stepY = rect.Height / 2;

            float scaleRadius = (float)n.Radius * scale / n.LevelVisible;

            float coordinateX = n.Coordinate.X - scaleRadius - stepX;
            coordinateX *= scale;
            coordinateX += stepX;

            float coordinateY = n.Coordinate.Y - scaleRadius - stepY;
            coordinateY *= scale;
            coordinateY += stepY;

            return new Point((int)coordinateX, (int)coordinateY);
        }

        private Node SearchScaleNode(Point coordinate)
        {
            float minX = coordinate.X - scalePoints.First().Value.X;
            float minY = coordinate.Y - scalePoints.First().Value.Y;
            float minDistance = (float)Math.Sqrt(Math.Pow(minX, 2) + Math.Pow(minY, 2));
           string name = scalePoints.First().Key;
           
            foreach(KeyValuePair<string, Point> point in scalePoints)
            {
                if ((float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2)) < minDistance)
                {
                    minDistance = (float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2));
                    name = point.Key;
                }
            }
            Node res = graph.Nodes.Find((Node n)=> n.Name == name);
            return res;
        }

        private void DrawNodes(Graphics g, Rectangle r, float scale, int currVisible)
        {
            foreach (Node n in graph.Nodes)
            {
                if (n.LevelVisible <= currVisible)
                {
                    Brush brush = new SolidBrush(n.Color);
                    float scaleRadius = (float)n.Radius * scale / n.LevelVisible;

                    Point scalepoint = Scale(r, scale, n);

                    g.FillEllipse(brush, scalepoint.X, scalepoint.Y, scaleRadius * 2, scaleRadius * 2);

                    Font font = new Font("Arial",10);

                    g.DrawString(n.Name,font, new SolidBrush(Color.Black),scalepoint.X-15, scalepoint.Y-15);

                    scalePoints.Add(n.Name, scalepoint);

                    brush.Dispose();
                }
            }
        }

        private void DrawPathNodes(Graphics g, Rectangle r, float scale,int currVisible, List<Node> path)
        {
            foreach (Node n in graph.Nodes)
            {
                if (n.LevelVisible <= currVisible)
                {
                    Brush brush = new SolidBrush(n.Color);
                    float scaleRadius = (float)n.Radius * scale / n.LevelVisible;

                    Point scalepoint = Scale(r, scale, n);
                    if (path.Contains(n))
                    {
                        Brush b = new SolidBrush(Color.Blue);
                        g.FillEllipse(b, scalepoint.X, scalepoint.Y, scaleRadius * 2, scaleRadius * 2);
                    }
                    else
                    {
                        g.FillEllipse(brush, scalepoint.X, scalepoint.Y, scaleRadius * 2, scaleRadius * 2);
                    }

                    Font font = new Font("Arial", 10);

                    g.DrawString(n.Name, font, new SolidBrush(Color.Black), scalepoint.X - 15, scalepoint.Y - 15);

                    scalePoints.Add(n.Name, scalepoint);

                    brush.Dispose();
                }
            }
        }

        private void DrawEdges(Graphics g, float k, bool drawEdge, Point p1, Point p2, int currVisible)
        {
            foreach (Edge edge in graph.Edges)
            {
                if (edge.LevelVisible <= currVisible)
                {
                    float scaleRadius = (float)edge.NodeFirst.Radius * k / edge.LevelVisible ;
                    float firstRadius = (float)edge.NodeFirst.Radius * k / edge.NodeFirst.LevelVisible;
                    float secondRadius = (float)edge.NodeSecond.Radius * k / edge.NodeSecond.LevelVisible;

                    Pen pen = new Pen(edge.Color, scaleRadius);

                    Point firstPoint = scalePoints[edge.NodeFirst.Name];
                    Point secondPoint = scalePoints[edge.NodeSecond.Name];

                    g.DrawLine(pen, firstPoint.X + firstRadius, firstPoint.Y + firstRadius, secondPoint.X + secondRadius, secondPoint.Y + secondRadius);
                    pen.Dispose();

                    Point weightPnt = new Point((firstPoint.X + secondPoint.X) / 2-5, (firstPoint.Y + secondPoint.Y) / 2-5);
                    Font font = new Font("Arial", 14);
                    g.DrawString(edge.Weight.ToString(), font, new SolidBrush(Color.Black), weightPnt);

                }
            }
            if (drawEdge)
            {
                Node firstNode = SearchScaleNode(p1);
                float scaleRadius = firstNode.Radius * k /  firstNode.LevelVisible;
                Pen pen = new Pen(Color.Gray, scaleRadius*2);
                g.DrawLine(pen, p1, p2);
                pen.Dispose();
            }
        }

        private void DrawPathEdges(Graphics g, float k, Point p1, Point p2, int currVisible, List<Node> path)
        {
            List<Edge> forDrawPath = new List<Edge>();
            for (int i = 0; i < path.Count-1; i++)
            {
                Edge edge = graph.Edges.Find((Edge e) => ((e.NodeFirst == path[i] && e.NodeSecond == path[i + 1]) || (e.NodeSecond == path[i] && e.NodeFirst == path[i + 1])));
                if(edge != null)
                    forDrawPath.Add(edge);
            }
            
            foreach (Edge edge in graph.Edges)
                {
                    if (edge.LevelVisible <= currVisible)
                    {
                        float scaleRadius = (float)edge.NodeFirst.Radius * k / edge.LevelVisible;
                        float firstRadius = (float)edge.NodeFirst.Radius * k / edge.NodeFirst.LevelVisible;
                        float secondRadius = (float)edge.NodeSecond.Radius * k / edge.NodeSecond.LevelVisible;

                        Pen pen = new Pen(edge.Color, scaleRadius);

                        Point firstPoint = scalePoints[edge.NodeFirst.Name];
                        Point secondPoint = scalePoints[edge.NodeSecond.Name];
                        if (forDrawPath.Contains(edge))
                        {
                            Pen p = new Pen(Color.Blue, scaleRadius);
                            g.DrawLine(p, firstPoint.X + firstRadius, firstPoint.Y + firstRadius, secondPoint.X + secondRadius, secondPoint.Y + secondRadius);
                        }
                        else
                        {
                        g.DrawLine(pen, firstPoint.X + firstRadius, firstPoint.Y + firstRadius, secondPoint.X + secondRadius, secondPoint.Y + secondRadius);
                        }

                        pen.Dispose();

                        Point weightPnt = new Point((firstPoint.X + secondPoint.X) / 2 - 5, (firstPoint.Y + secondPoint.Y) / 2 - 5);
                        Font font = new Font("Arial", 14);
                        g.DrawString(edge.Weight.ToString(), font, new SolidBrush(Color.Black), weightPnt);

                    }
                }
           
        }

        public Bitmap DrawGraph(Rectangle r, float k, bool drawEdge, Point p1, Point p2, int currVisible)
        {

            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            scalePoints.Clear();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.LightGreen),r);
                DrawNodes(g, r, k, currVisible);
                DrawEdges(g,k,drawEdge,p1, p2, currVisible);
               
            }
            return bitmap;
        }

        public Bitmap DrawPath(Rectangle r, float k, Point p1, Point p2, int currVisible, List<Node> path)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            scalePoints.Clear();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.LightGreen), r);
                DrawPathNodes(g, r, k, currVisible,path);
                DrawPathEdges(g, k, p1, p2, currVisible,path);
            }
            return bitmap;
        }
    }
}
