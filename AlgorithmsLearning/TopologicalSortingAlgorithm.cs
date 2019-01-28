using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TopologicalSortingAlgorithm
    {
        private int m_NumOfVertices;
        private Dictionary<int, List<int>> m_Graph;
        public TopologicalSortingAlgorithm(int numOfVertices) {
            this.m_NumOfVertices = numOfVertices;
            this.m_Graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < this.m_NumOfVertices; i++)
            {
                this.m_Graph[i] = new List<int>();
            }
            this.m_Graph[5].Add(2);
            this.m_Graph[5].Add(0);
            this.m_Graph[4].Add(0);
            this.m_Graph[4].Add(1);
            this.m_Graph[2].Add(3);
            this.m_Graph[3].Add(1);
        }
        public void TopologicalSort() {
            bool[] _Visited = new bool[this.m_NumOfVertices];
            Stack<int> _Stack = new Stack<int>();
            for (int i = 0; i < this.m_NumOfVertices; i++)
            {
                if (_Visited[i] == false)
                    TopologicalSortHelper(i, _Visited, _Stack);
            }

            while (_Stack.Count > 0)
            {
                Console.Write(_Stack.Pop() + " ");
            }
            Console.ReadKey();
        }
        public void TopologicalSortHelper(int vertex, bool[] visited, Stack<int> stack) {
            visited[vertex] = true;
            for (int adjacent = 0; adjacent < this.m_Graph[vertex].Count; adjacent++)
            {
                if (visited[this.m_Graph[vertex][adjacent]] == true)
                    continue;

                TopologicalSortHelper(this.m_Graph[vertex][adjacent], visited, stack);
            }

            stack.Push(vertex);
        }
    }
}
