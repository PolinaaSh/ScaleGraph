using ScaleGraph.Edit;
using ScaleGraph.Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Core
{
    class DataHolder
    {
        private List<Node> nodes;
        private List<Edge> edges;
        private int maxNodeNumber = 0;

        private Editing edit;

        private int currentVisible;
        private Color currentColor;
        private int currentRadius;

        public DataHolder()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            Reading();
            edit = new Editing(nodes, edges);

            currentVisible = 1;
            currentColor = Color.Black;
            currentRadius = 5;
        }

        private void ReadNodes()
        {
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
             fs = new FileStream("Nodes.txt", FileMode.OpenOrCreate, FileAccess.Read);
             reader = new StreamReader(fs);
            string line;
            string[] lineResult;
            while((line = reader.ReadLine())!=null)
            {
                lineResult = line.Split(' ');
                nodes.Add(new Node((Convert.ToInt32(lineResult[0])),Color.FromName(lineResult[1]),
                    new Point(Convert.ToInt32(lineResult[2]), Convert.ToInt32(lineResult[3])), Convert.ToInt32(lineResult[4]), maxNodeNumber++));
            }
            }
            catch(Exception e)
            {
               //Не оставлять пустым!!!!!!!!!!!
            }
            finally
            {
            reader.Close();
            fs.Close();
            }
        }

        private void ReadEdges()
        {
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
                fs = new FileStream("Edges.txt", FileMode.OpenOrCreate, FileAccess.Read);
                reader = new StreamReader(fs);
                string line;
                string[] lineResult;
                while ((line = reader.ReadLine()) != null)
                {
                    lineResult = line.Split(' ');
                    edges.Add(new Edge(nodes.Find((Node n) => n.Number == Convert.ToInt32(lineResult[0])),
                        nodes.Find((Node n) => n.Number == Convert.ToInt32(lineResult[1])), Color.FromName(lineResult[2]),Convert.ToInt32(lineResult[3])));
                }
            }
            catch (Exception e)
            {
                //Не оставлять пустым!!!!!!!!!!!
            }
            finally
            {
                reader.Close();
                fs.Close();
            }
        }

        public void Reading()
        {
            ReadNodes();
            ReadEdges();
        }

        public Node SearchNode(Point coordinate)
        {
            foreach(Node n in nodes)
            {
                if (n.Coordinate != coordinate)
                    return n;
            }
            return null;
        }

        public void WriteNode(int levelVisible, Color color, Point coordinate, int radius)
        {
            FileStream fs = null;
            StreamWriter writer = null;
            try
            {
                fs = new FileStream("Nodes.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(fs);

                edit.AddNode(levelVisible,color, coordinate, radius, ++maxNodeNumber);

                string line = levelVisible.ToString() + ' ' + color.ToString() + ' ' + coordinate.X.ToString() + ' '
                    + coordinate.Y.ToString() + ' ' + radius.ToString() + ' ' + maxNodeNumber.ToString();

                writer.WriteLine(line);
               
            }
            catch (Exception e)
            {
                //Не оставлять пустым!!!!!!!!!!!
            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }

        public void WriteEdge(Point firstCoordinate, Point secondCoordinate, Color color, int width)
        {
            FileStream fs = null;
            StreamWriter writer = null;
            try
            {
                fs = new FileStream("Edges.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(fs);

                Node first = SearchNode(firstCoordinate);
                Node second = SearchNode(secondCoordinate);
                edit.AddEdge(first,second, color, width);

                String edgeInfo = first.Number.ToString() + ' ' + second.Number.ToString() + ' ' + color.ToString() + ' ' + width.ToString();
                writer.WriteLine(edgeInfo);
            }
            catch(Exception e)
            {

            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }

        public int CurrentVisible
        {
            get
            {
                return currentVisible;
            }
            set
            {
                currentVisible = value;
            }
        }

        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                currentColor = value;
            }
        }

        public int CurrentRadius
        {
            get
            {
                return currentRadius;
            }
            set
            {
                currentRadius = value;
            }
        }

        public Bitmap Draw(Rectangle rect)
        {
            return edit.DrawGraph(rect);
        }

    }
}
