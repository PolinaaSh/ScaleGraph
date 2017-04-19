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
        private int width;
        private int levelVisible;

        public Edge(int levelVisible, Node nodeFirst, Node nodeSecond, Color color, int width)
        {
            this.levelVisible = levelVisible;
            this.nodeFirst = nodeFirst;
            this.nodeSecond = nodeSecond;
            this.color = color;
            this.width = width;
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

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int LevelVisible
        {
            get
            {
                return this.levelVisible;
            }
            set
            {
                this.levelVisible = value;
            }
        }

    }
}
