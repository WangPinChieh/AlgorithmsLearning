using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FloydWarshallAlgorithm
    {
        private int[,] m_Graph;
        private int[,] m_Distance;
        public FloydWarshallAlgorithm(int[,] graph) {
            //assuming that the input graph is a square matrix
            int _NumOfMatrixEdges = graph.GetLength(0);

            this.m_Graph = graph;
            this.m_Distance = graph;
            for (int k = 0; k < _NumOfMatrixEdges; k++) //intermediate points
            {
                for (int i = 0; i < _NumOfMatrixEdges; i++)
                {
                    for (int j = 0; j < _NumOfMatrixEdges; j++)
                    {
                        if (m_Distance[i, j] > m_Distance[i, k] + m_Distance[k, j])
                            m_Distance[i, j] = m_Distance[i, k] + m_Distance[k, j];
                    }
                }
            }
            StringBuilder _SB = new StringBuilder();
            for (int i = 0; i < this.m_Distance.GetLength(0); i++)
            {
                for (int j = 0; j < this.m_Distance.GetLength(1); j++)
                {
                    if (_SB.Length != 0)
                        _SB.Append(" ");
                    _SB.Append(this.m_Distance[i, j]);
                }
            }
            Console.WriteLine(_SB.ToString());
        }
    }
}
