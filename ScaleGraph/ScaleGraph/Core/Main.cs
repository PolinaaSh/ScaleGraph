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
    class Main
    {
        private List<Node> nodes;
        private List<Edge> edges;
        private int maxNodeNumber = 0;

        public void StartView()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            Reading();
            Editing edit = new Editing(nodes);
        }

        private void ReadNodes()
        {
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
             fs = new FileStream("Nodes.txt", FileMode.Open, FileAccess.Read);
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

        }
        private void Reading()
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

       // Write

    }
}
