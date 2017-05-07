using ScaleGraph.Edit;
using ScaleGraph.MyGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGraph.Core
{
    class Data
    {
        private string nodeFileName;
        private string edgesFileName;

        public Data(string nodeFileName, string edgesFileName)
        {
            this.nodeFileName = nodeFileName;
            this.edgesFileName = edgesFileName;
        }

        public List<Node> ReadNodes()
        {
            FileStream fs = null;
            StreamReader reader = null;
            List<Node> nodes = new List<Node>();
            try
            {
             fs = new FileStream(nodeFileName, FileMode.OpenOrCreate, FileAccess.Read);
             reader = new StreamReader(fs);
            string line;
            string[] lineResult;
            while((line = reader.ReadLine())!=null)
            {
                lineResult = line.Split(' ');
                nodes.Add(new Node((Convert.ToInt32(lineResult[0])),Color.FromName(lineResult[1]),
                    new Point(Convert.ToInt32(lineResult[2]), Convert.ToInt32(lineResult[3])), Convert.ToInt32(lineResult[4]), lineResult[5]));
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            reader.Close();
            fs.Close();
            }
            return nodes;
        }

        public List<Edge> ReadEdges(List<Node> nodes)
        {
            FileStream fs = null;
            StreamReader reader = null;
            List<Edge> edges = new List<Edge>();
            try
            {
                fs = new FileStream(edgesFileName, FileMode.OpenOrCreate, FileAccess.Read);
                reader = new StreamReader(fs);
                string line;
                string[] lineResult;
                while ((line = reader.ReadLine()) != null)
                {
                    lineResult = line.Split(' ');
                    edges.Add(new Edge(Convert.ToInt32(lineResult[0]), nodes.Find((Node n) => n.Name == lineResult[1]),
                        nodes.Find((Node n) => n.Name == lineResult[2]), Color.FromName(lineResult[3]), Convert.ToInt32(lineResult[4]), Convert.ToInt32(lineResult[5])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
                fs.Close();
            }
            return edges;
        }

        private void WriteNode(Graph graph)
        {
            FileStream fs = null;
            StreamWriter writer = null;
            List<Node> nodes = graph.Nodes;
            try
            {
                fs = new FileStream(nodeFileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(fs);
                foreach (Node n in nodes)
                {
                    string line = n.LevelVisible.ToString() + ' ' + ColorToStr(n.Color) + ' ' + n.Coordinate.X.ToString() + ' '
                        + n.Coordinate.Y.ToString() + ' ' + n.Radius.ToString() + ' ' + n.Name.ToString();

                    writer.WriteLine(line);
                }

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }

        private void WriteEdge(Graph graph)
        {
            FileStream fs = null;
            StreamWriter writer = null;
            List<Edge> edges = graph.Edges;
            try
            {
                fs = new FileStream(edgesFileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(fs);
                foreach (Edge edge in edges)
                {             
                    String edgeInfo = edge.LevelVisible.ToString()+' ' + edge.NodeFirst.Name + ' ' +edge.NodeSecond.Name+ ' ' + ColorToStr(edge.Color) + ' ' + edge.Width.ToString();
                    writer.WriteLine(edgeInfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }


        public void WriteData(Graph graph)
        {
            WriteNode(graph);
            WriteEdge(graph);
        }
      
        private String ColorToStr(Color color)
        {
            String res = color.ToString();
            res = res.Remove(res.Length-1);
            res = res.Substring(7,res.Length-7);
            return res;
        }
    }
}
