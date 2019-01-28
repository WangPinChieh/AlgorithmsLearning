using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AlgorithmsLearning
{
    public class UnionFindAlgorithm
    {
        public UnionFindAlgorithm()
        {

        }
        public void Run(){
            int _NumOfNodes = Convert.ToInt32(Console.ReadLine());
            int _NumOfTakeovers = Convert.ToInt32(Console.ReadLine());
            int[] _Graph = new int[_NumOfNodes + 1];
            for (int i = 0; i < _Graph.Count(); i++)
            {
                _Graph[i] = i;
            }
            for (int i = 0; i < _NumOfTakeovers; i++)
            {
                string _ALine = Console.ReadLine();
                int _NodeA = Convert.ToInt32(_ALine.Split(new char[] { ' ' })[0]);
                int _NodeB = Convert.ToInt32(_ALine.Split(new char[] { ' ' })[1]);
                Union(ref _Graph, _NodeB, _NodeA);
            }


            int _Counter = 0;
            for (int i = 1; i <= _NumOfNodes; i++)
            {
                if (i == _Graph[i])
                    _Counter++;
            }
            Console.Write(_Counter);
        }
        public void Union(ref int[] graph, int nodeA, int nodeB)
        {
            int _RootOfA = FindRoot(graph, nodeA);
            int _RootOfB = FindRoot(graph, nodeB);
            graph[_RootOfA] = _RootOfB;

        }
        public bool Find(int[] graph, int nodeA, int nodeB)
        {
            if (FindRoot(graph, nodeA) == FindRoot(graph, nodeB))
                return true;
            else
                return false;
        }
        public int FindRoot(int[] graph, int node)
        {
            while (graph[node] != node)
            {
                node = graph[node];
            }
            return node;
        }

    }
}
