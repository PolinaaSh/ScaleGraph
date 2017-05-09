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
            currentColor = Color.Gray;
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

        public void AddNode( Rectangle rect,Point coordinate, string name)
        {
           graph.AddNode(currentVisible, currentColor,  CalcilateRealCoordinate(rect,coordinate), currentRadius, name);
        }

        public void AddEdge( Point firstCoordinate, Point secondCoordinate, int weight, float width)
        {
            graph.AddEdge(currentVisible,firstCoordinate, secondCoordinate, currentColor, weight, width, drawManager.ScalePoints);
        }

        public void RemoveNode(Point nodeCoordinate)
        {
            graph.RemoveNode(nodeCoordinate, drawManager.ScalePoints);
        }

        public void RemoveEdge(Point clickCoordinate)
        {
            Edge res = graph.Edges[0];
            int minDistance = CalculateDistance(graph.Edges[0].NodeFirst.Name, graph.Edges[0].NodeSecond.Name, clickCoordinate);
            int distance = minDistance;
            foreach(Edge e in graph.Edges)
            {
                if (e.LevelVisible <= currentVisible)
                {
                    if ((distance = CalculateDistance(e.NodeFirst.Name, e.NodeSecond.Name, clickCoordinate)) < minDistance)
                    {
                        minDistance = distance;
                        res = e;
                    }
                }
            }
            graph.RemoveEdge(res);
        }

        public Bitmap Draw(Rectangle rect, bool drawEdge, Point p1, Point p2)
        {
            return drawManager.DrawGraph(rect, scale, drawEdge,  p1, p2, currentVisible);
        }

        private Point CalcilateRealCoordinate(Rectangle rect, Point coordinate)
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
        
        private int CalculateDistance(string firstNodeName, string secondNodeName, Point clickPoint)
        {
            Point first = drawManager.ScalePoints[firstNodeName];
            Point second = drawManager.ScalePoints[secondNodeName];
            int A = second.Y - first.Y;
            int B = first.X - second.X;
            int C = first.Y * second.X - first.X * second.Y;

            int distance = Math.Abs(A * clickPoint.X + B * clickPoint.Y + C) / (int)Math.Sqrt(A*A + B*B );
            return distance;
        } 

        public List<Node> Search(string from, string to)
        {
            Dictionary<Node, int> minDistance = new Dictionary<Node, int>();
            List<Node> firstRes = Deikstra(from, minDistance);
            int numb = 0;
            foreach(KeyValuePair<Node, int> pair in minDistance)
            {
                if (pair.Key.Name != to)
                    numb++;
                else
                {
                    break;
                }
            }

            List<Node> res = firstRes.Take<Node>(numb).ToList<Node>();

            res.Add(graph.Nodes.Find((Node n)=> n.Name == to));

            return res;

        }

        public List<Node> Deikstra(String name, Dictionary<Node, int> minDistance)
        {
            List<Node> path = new List<Node>();
           // path.Add(graph.Nodes.Find((Node n)=> n.Name == name));

            minDistance.Add((graph.Nodes.Find((Node n)=> n.Name == name)),0);

            List<Node> visitedNodes = new List<Node>();

            Node currentNode = graph.Nodes.Find((Node n) => n.Name == name);

            while (graph.Nodes.Count != visitedNodes.Count)
            {
                List<Edge> nearEdges = graph.Edges.FindAll((Edge e) => (e.NodeFirst == currentNode || e.NodeSecond == currentNode));
     
                foreach (Edge edge in nearEdges)
                {
                    if(edge.NodeFirst == currentNode)
                    {
                        if (!minDistance.ContainsKey(edge.NodeSecond) && !visitedNodes.Contains(edge.NodeSecond))
                        {
                            minDistance.Add(edge.NodeSecond, edge.Weight + minDistance[currentNode]);
                           // path.Add(currentNode);
                        }
                        else
                            if (edge.Weight + minDistance[currentNode] < minDistance[edge.NodeSecond] && !visitedNodes.Contains(edge.NodeSecond))
                            {
                                minDistance[edge.NodeSecond] = edge.Weight + minDistance[currentNode];
                            }

                    }
                    else
                    {
                        if (!minDistance.ContainsKey(edge.NodeFirst) && !visitedNodes.Contains(edge.NodeFirst))
                        {
                            minDistance.Add(edge.NodeFirst, edge.Weight + minDistance[currentNode]);
                           // path.Add(currentNode);
                        }
                        else
                            if (edge.Weight + minDistance[currentNode] < minDistance[edge.NodeFirst] && !visitedNodes.Contains(edge.NodeFirst))
                            {
                                minDistance[edge.NodeFirst] = edge.Weight + minDistance[currentNode];
                            }
                    }
                    path.Add(currentNode);
                }

                visitedNodes.Add(currentNode);

                var myList = minDistance.ToList();

                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                foreach( KeyValuePair<Node, int> p in myList)
                {
                    if(!visitedNodes.Contains( p.Key))
                    {
                        currentNode = p.Key;
                        break;
                    }
                }                       
            }
            return path;
        }
      
    }
}
