using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Graph
{
    class Node
    {
         private int levelVisile;
         private List<Edge> edges;
         private Color color;
         private Point coordinate;
         private int radius;


        public Node(int levelVisible, Color color, Point coordinate, int radius)
         {
             this.levelVisile = levelVisible;
             edges = new List<Edge>();
             this.color = color;
             this.coordinate = coordinate;
             this.radius = radius;
         }

       public int LevelVisible
        {
            get
            {
                return this.levelVisile;
            }
            set
            {
                this.levelVisile = value;
            }
        }

       public List<Edge> Edges
       {
           get
           {
               return this.edges;
           }
           set
           {
               try
               {
                   this.edges = value;
               }
               catch (Exception e)
               {
                   Console.Write(e.Message);
               }
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

       public Point Coordinate
       {
           get
           {
               return this.coordinate;
           }
           set
           {
               this.coordinate = value;
           }
       }

       public void AddEdge(Edge edge)
       {
           edges.Add(edge);
       }

    }
}
