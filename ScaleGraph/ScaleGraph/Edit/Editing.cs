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

        public void AddEdge(Node nodeFirst, Node nodeSecond, Color color , int width)
        {
            edges.Add(new Edge(nodeFirst, nodeSecond,color, width));
           //first.AddEdge(new Edge(nodeFirst, nodeSecond , color,width));
          // second.AddEdge(new Edge(nodeFirst, nodeSecond, color,width));
        }

        public Bitmap DrawGraph()
        {
            Bitmap bitmap = null;
            foreach(Node n in nodes)
            {

            }
            return bitmap;
        }
    }
}
