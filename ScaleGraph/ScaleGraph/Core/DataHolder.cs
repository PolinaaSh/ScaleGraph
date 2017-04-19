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
            currentRadius = 10;
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
                    new Point(Convert.ToInt32(lineResult[2]), Convert.ToInt32(lineResult[3])), Convert.ToInt32(lineResult[4]), ++maxNodeNumber));
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

        public void WriteData()
        {
            WriteNode();
            WriteEdge();
        }
        private void WriteNode()
        {
            FileStream fs = null;
            StreamWriter writer = null;
            try
            {
                fs = new FileStream("Nodes.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(fs);
                foreach (Node n in nodes)
                {
                    string line = n.LevelVisible.ToString() + ' ' + ColorToStr(n.Color) + ' ' + n.Coordinate.X.ToString() + ' '
                        + n.Coordinate.Y.ToString() + ' ' + n.Radius.ToString() + ' ' + n.Number.ToString();

                    writer.WriteLine(line);
                }

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

        private void WriteEdge()
        {
            FileStream fs = null;
            StreamWriter writer = null;
            try
            {
                fs = new FileStream("Edges.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(fs);
                foreach (Edge edge in edges)
                {             
                    String edgeInfo = edge.LevelVisible.ToString()+' ' + edge.NodeFirst.Number.ToString() + ' ' +edge.NodeSecond.Number.ToString() + ' ' + ColorToStr(edge.Color) + ' ' + edge.Width.ToString();
                    writer.WriteLine(edgeInfo);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                writer.Close();
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
                    edges.Add(new Edge(Convert.ToInt32(lineResult[0]),nodes.Find((Node n) => n.Number == Convert.ToInt32(lineResult[1])),
                        nodes.Find((Node n) => n.Number == Convert.ToInt32(lineResult[2])), Color.FromName(lineResult[3]),Convert.ToInt32(lineResult[4])));
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

        public Node SearchNode(PointF coordinate)
        {
            foreach(Node n in nodes)
            {
                if ((n.Coordinate.X >= coordinate.X - 5 && n.Coordinate.X <= coordinate.X +5)
                    && (n.Coordinate.Y >= coordinate.Y - 5 && n.Coordinate.Y <= coordinate.Y + 5))
                    return n;
            }
            return null;
        }

        public void AddNode(int levelVisible, Color color, PointF coordinate, int radius)
        {
            edit.AddNode(levelVisible, color, coordinate, radius, ++maxNodeNumber);
        }

        public void AddEdge(PointF firstCoordinate, PointF secondCoordinate, Color color, int width)
        {
            Node first = SearchNode(firstCoordinate);
            Node second = SearchNode(secondCoordinate);
            edit.AddEdge(currentVisible,first, second, color, width);
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

        public Bitmap Draw(Rectangle rect, bool drawEdge, PointF p1, PointF p2, float k)
        {
            return edit.DrawGraph(rect, k, drawEdge,p1,p2, currentVisible);
        }

        private String ColorToStr(Color color)
        {
            String res = color.ToString();
            res = res.Remove(res.Length-1);
            res = res.Substring(7,res.Length-7);
            return res;
        }

        public void Scale(float k)
        {

        }
    }
}
