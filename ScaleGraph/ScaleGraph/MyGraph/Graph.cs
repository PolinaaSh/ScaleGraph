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

        public void AddNode(int levelVisible, Color color, Point coordinate, float radius)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, nodes.Count+1));
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public void AddEdge(int levelVisible, Point firstCoordinate, Point secondCoordinate, Color color, float width, Dictionary<int, Point> scalePoints)
        {
            Node first = SearchNode(firstCoordinate,scalePoints);
            Node second = SearchNode(secondCoordinate,scalePoints);
            edges.Add(new Edge(levelVisible, first, second, color, width));
        }

        public void RemoveNode(Point coordinate, Dictionary<int, Point> scalePoints)
        {
            nodes.Remove(SearchNode(coordinate,scalePoints));
        }

        public void RemoveEdge(Point coordinate)
        {

        }

        public Node SearchNode(Point coordinate, Dictionary<int, Point> scalePoints)
        {
            float minX = coordinate.X - scalePoints.First().Value.X;
            float minY = coordinate.Y - scalePoints.First().Value.Y;
            float minDistance = (float)Math.Sqrt(Math.Pow(minX, 2) + Math.Pow(minY, 2));
            int number = scalePoints.First().Key;

            foreach (KeyValuePair<int, Point> point in scalePoints)
            {
                if ((float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2)) < minDistance)
                {
                    minDistance = (float)Math.Sqrt(Math.Pow(coordinate.X - point.Value.X, 2) + Math.Pow(coordinate.Y - point.Value.Y, 2));
                    number = point.Key;
                }
            }
            Node res = Nodes.Find((Node n) => n.Number == number);
            return res;
        }
    }
}
