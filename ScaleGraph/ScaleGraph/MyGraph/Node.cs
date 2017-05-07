using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.MyGraph
{
    class Node
    {
         private int levelVisible;
         private Color color;
         private PointF coordinate;
         private float radius;
         private string name;


        public Node(int levelVisible, Color color, PointF coordinate, float radius, string name)
         {
             this.levelVisible = levelVisible;
             this.color = color;
             this.coordinate = coordinate;
             this.radius = radius;
             this.name = name;
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

       public PointF Coordinate
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

       public string Name
       {
           get
           {
               return name;
           }

           set
           {
               name = value;
           }
       }

        public float Radius
       {
           get
           {
               return radius;
           }
            set
           {
               radius = value;
           }
       }
    }
}
