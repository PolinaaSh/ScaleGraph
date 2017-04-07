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


        private List<Node> nodes;
       
        public Editing(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public void AddNode(int levelVisible, Color color, Point coordinate, int radius, int number)
        {
            nodes.Add(new Node(levelVisible, color, coordinate, radius, number));
        }

        public void AddEdge(Node nodeFirst, Node nodeSecond, Color color , int width)
        {
           Node first =  nodes.Find((Node node) => node.Equals(nodeFirst));
           first.AddEdge(new Edge(nodeFirst, nodeSecond , color,width));
           Node second = nodes.Find((Node node) => node.Equals(nodeSecond));
           second.AddEdge(new Edge(nodeFirst, nodeSecond, color,width));
        }
    }
}
