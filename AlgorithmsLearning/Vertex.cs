using System;
namespace AlgorithmsLearning
{
    public class Vertex : IComparable<Vertex>
    {
        public int Node { get; set; }
        public int Weight { get; set; }
        public Vertex(int node, int weight)
        {
            Node = node;
            Weight = weight;
        }
        public int CompareTo(Vertex other)
        {
            if (this.Weight < other.Weight)
                return -1;
            else if (this.Weight > other.Weight)
                return 1;
            else
                return 0;
        }
    }
}
