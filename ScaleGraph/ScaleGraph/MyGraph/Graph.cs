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

        public void AddNode(int levelVisible, Color color, PointF coordinate, float radius, int number)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number));
        }

        public void AddEdge(int levelVisible,PointF firstCoordinate, PointF secondCoordinate, Color color, float width)
        {
            Node first = SearchNode(firstCoordinate);
            Node second = SearchNode(secondCoordinate);
            edges.Add(new Edge(levelVisible, first, second, color, width));
        }

        public void RemoveNode(PointF coordinate)
        {
            nodes.Remove(SearchNode(coordinate));
        }

        public void RemoveEdge(PointF coordinate)
        {

        }

        public Node SearchNode(PointF coordinate)
        {
            float minX = nodes[0].Coordinate.X;
            float minY = nodes[0].Coordinate.Y;
            Node res = null;

            foreach (Node n in nodes)
            {
                if (Math.Abs(coordinate.X - n.Coordinate.X) < minX && Math.Abs(coordinate.Y - n.Coordinate.Y) < minY)
                    res = n;
            }
            return res;
        }
    }
}
