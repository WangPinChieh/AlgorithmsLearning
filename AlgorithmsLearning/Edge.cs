using System;
namespace AlgorithmsLearning
{
    public class Edge : IComparable<Edge>
    {
        public int m_NodeA { get; set; }
        public int m_NodeB { get; set; }
        public int m_Weight { get; set; }

        public Edge(int nodeA, int nodeB, int weight)
        {
            this.m_NodeA = nodeA;
            this.m_NodeB = nodeB;
            this.m_Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            if (this.m_Weight < other.m_Weight)
                return -1;
            else if (this.m_Weight > other.m_Weight)
                return 1;
            else
                return 0;

        }
    }
}
