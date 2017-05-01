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
            int number = nodes[nodes.Count - 1].Number;
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number + 1));
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

        private Edge SearchEdge(Point coordinate)
        { 
            if(edges.Count >0)
            {
                /*Node first = edges[0].NodeFirst;
                Node second = edges[0].NodeSecond;
                float minFirstX = coordinate.X - first.Coordinate.X;
                float minFirstY = coordinate.Y - first.Coordinate.Y;
                float minFirstDistance = (float)Math.Sqrt(Math.Pow(minFirstX,2) + Math.Pow(minFirstY,2));

                float minSecondX = coordinate.X - second.Coordinate.X;
                float minSecondY = coordinate.Y - second.Coordinate.Y;
                float minSecondDistance = (float)Math.Sqrt(Math.Pow(minSecondX, 2) + Math.Pow(minSecondY, 2));

                foreach(Edge edge in edges)
                {
                    if((float)Math.Sqrt(Math.Pow(coordinate.X - edge.NodeFirst.Coordinate.X, 2) + Math.Pow(coordinate.Y - edge.NodeFirst.Coordinate.Y, 2)) < minFirstDistance &&
                        (float)Math.Sqrt(Math.Pow(coordinate.X - edge.NodeSecond.Coordinate.X, 2) + Math.Pow(coordinate.Y - edge.NodeSecond.Coordinate.Y, 2)) < minSecondDistance)
                    {
                        first = edge.NodeFirst;
                        second = edge.NodeSecond;
                        minFirstDistance = (float)Math.Sqrt(Math.Pow(coordinate.X - edge.NodeFirst.Coordinate.X, 2) + Math.Pow(coordinate.Y - edge.NodeFirst.Coordinate.Y, 2));
                        minSecondDistance = (float)Math.Sqrt(Math.Pow(coordinate.X - edge.NodeSecond.Coordinate.X, 2) + Math.Pow(coordinate.Y - edge.NodeSecond.Coordinate.Y, 2));
                    }
                }

                Edge res = edges.Find((Edge e)=> ((e.NodeFirst == first) && (e.NodeSecond == second)));
                return res;*/


            }
            return null;
        }
    }
}
