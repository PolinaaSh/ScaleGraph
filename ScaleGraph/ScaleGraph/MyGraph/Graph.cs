using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.MyGraph
{
    class Graph
    {
        private List<Node> nodes;
        private List<Edge> edges;

        public Graph(List<Node> nodes, List<Edge> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
        }


        public List<Node> Nodes
        {
            get
            {
                return nodes;
            }
            set
            {
                nodes = value;
            }
        }

        public List<Edge> Edges
        {
            get
            {
                return edges;
            }
            set
            {
                edges = value;
            }
        }

        public void AddNode(int levelVisible, Color color, Point coordinate, float radius, string name)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, name));
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public void AddEdge(int levelVisible, Point firstCoordinate, Point secondCoordinate, Color color, float width, Dictionary<string, Point> scalePoints)
        {
            Node first = SearchNode(firstCoordinate,scalePoints);
            Node second = SearchNode(secondCoordinate,scalePoints);
            edges.Add(new Edge(levelVisible, first, second, color, 10 ,width));
        }

        public void RemoveNode(Point coordinate, Dictionary<string, Point> scalePoints)
        {
            Node delNode = SearchNode(coordinate, scalePoints);
            List<Edge> delEdges = new List<Edge>();
            foreach(Edge edge in edges)
            {
                if (edge.NodeFirst == delNode || edge.NodeSecond == delNode)
                    delEdges.Add(edge);
                    
            }
             nodes.Remove(delNode);
             edges.RemoveAll((Edge e)=>delEdges.Contains(e));
        }

        public void RemoveEdge(Edge edge)
        {
            edges.Remove(edge);
        }

        public Node SearchNode(Point coordinate, Dictionary<string, Point> scalePoints)
        {
            float minX = coordinate.X - scalePoints.First().Value.X;
            float minY = coordinate.Y - scalePoints.First().Value.Y;
            float minDistance = (float)Math.Sqrt(Math.Pow(minX, 2) + Math.Pow(minY, 2));
            string name = scalePoints.First().Key;

            foreach (KeyValuePair<string, Point> point in scalePoints)
            {
                if ((float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2)) < minDistance)
                {
                    minDistance = (float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2));
                    name = point.Key;
                }
            }
            Node res = Nodes.Find((Node n) => n.Name == name);
            return res;
        }

    }
}
