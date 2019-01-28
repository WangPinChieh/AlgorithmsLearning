using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{
    class FindArticulationPointsAlgorithm
    {
        private APVertex[] m_Vertices;
        private List<APVertex> m_ArticulationPoints;
        private Dictionary<APVertex, List<APVertex>> m_Graph;
        private int m_NumOfVertices;
        private int m_Counter;
        public FindArticulationPointsAlgorithm() {
            m_NumOfVertices = 6;
            m_Counter = 0;
            this.m_Vertices = new APVertex[m_NumOfVertices];
            this.m_Graph = new Dictionary<APVertex, List<APVertex>>();
            this.m_ArticulationPoints = new List<APVertex>();
            for (int i = 0; i < m_NumOfVertices; i++)
            {
                this.m_Vertices[i] = new APVertex(i);
                this.m_Graph[this.m_Vertices[i]] = new List<APVertex>();
                
            }
            List<string> _Temp = new List<string>();
            _Temp.Add("0 5");
            _Temp.Add("0 1");
            _Temp.Add("1 2");
            _Temp.Add("1 3");
            _Temp.Add("2 3");
            _Temp.Add("2 4");
            _Temp.Add("3 4");
            foreach (string s in _Temp)
            {
                int _NodeA = Convert.ToInt32(s.Split(new char[] { ' ' })[0]);
                int _NodeB = Convert.ToInt32(s.Split(new char[] { ' ' })[1]);
                this.m_Graph[this.m_Vertices[_NodeA]].Add(this.m_Vertices[_NodeB]);
                this.m_Graph[this.m_Vertices[_NodeB]].Add(this.m_Vertices[_NodeA]);
            }
        }
        public List<APVertex> Run(int startingVertexIndex) {

            FindArticulationPoints(this.m_Vertices[startingVertexIndex]);

            return this.m_ArticulationPoints;
        }
        public void FindArticulationPoints(APVertex vertex)
        {
            vertex.Visited = true;
            vertex.Low = vertex.Number = m_Counter++;
            foreach (APVertex w in this.m_Graph[vertex])
            {
                if (!w.Visited)
                {
                    w.Parent = vertex;
                    FindArticulationPoints(w);

                    if(vertex.Parent == null && this.m_Graph[vertex].Count >= 2)
                        this.m_ArticulationPoints.Add(vertex);

                    if (vertex.Parent != null && w.Low >= vertex.Number)
                        this.m_ArticulationPoints.Add(vertex);

                    vertex.Low = Math.Min(vertex.Low, w.Low);
                }
                else if (vertex.Parent != w)
                {
                    vertex.Low = Math.Min(vertex.Low, w.Number);
                }
            }
        }

    }

    public class APVertex {
        public int Index { get; set; }
        public int Number { get; set; }
        public int Low { get; set; }
        public bool Visited { get; set; }
        public APVertex Parent { get; set; }

        public APVertex(int index) {
            this.Index = index;
            this.Visited = false;
        }
    }
}
