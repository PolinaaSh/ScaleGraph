﻿using System;
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

        public void AddNode(int levelVisible, Color color, PointF coordinate, float radius)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, nodes.Count+1));
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
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

        private Node SearchNode(PointF coordinate)
        {
            float minX = Math.Abs(coordinate.X - nodes[0].Coordinate.X);
            float minY = Math.Abs(coordinate.Y - nodes[0].Coordinate.Y);
            Node res = null;

            foreach (Node n in nodes)
            {
                if (Math.Abs(coordinate.X - n.Coordinate.X) < minX && Math.Abs(coordinate.Y - n.Coordinate.Y) < minY)
                {
                    minX = Math.Abs(coordinate.X - n.Coordinate.X);
                    minY = Math.Abs(coordinate.Y - n.Coordinate.Y);
                    res = n;
                }
            }
            return res;
        }
    }
}
