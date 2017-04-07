using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Graph
{
    class Edge
    {
        private Node nodeFirst, nodeSecond;//номера вершин, которые соединяет
        private Color color;

        public Edge(Color color)
        {
            this.color = color;
        }

        public Node NodeFirst
        {
            get
            {
                return this.nodeFirst;
            }
            set
            {
                this.nodeFirst = value;
            }
        }

        public Node NodeSecond
        {
            get
            {
                return this.nodeSecond;
            }
            set
            {
                this.nodeSecond = value;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
    }
}
