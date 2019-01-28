using System;
using System.Collections.Generic;

namespace AlgorithmsLearning
{
    public class DijkstraAlgorithm
    {
        public DijkstraAlgorithm()
        {
            Dictionary<int, List<Vertex>> _Graph = new Dictionary<int, List<Vertex>>();
            List<string> _Temp = new List<string>();
            int _NumOfVertices = 0;
            int _NumOfEdges = 0;
            string _NumOfVerticesAndEdges = Console.ReadLine();
            _NumOfVertices = Convert.ToInt32(_NumOfVerticesAndEdges.Split(new char[] { ' ' })[0]);
            _NumOfEdges = Convert.ToInt32(_NumOfVerticesAndEdges.Split(new char[] { ' ' })[1]);

            for (int i = 0; i < _NumOfEdges; i++)
            {
                _Temp.Add(Console.ReadLine());
            }

            for (int i = 1; i <= _NumOfVertices; i++)
                _Graph[i] = new List<Vertex>();

            foreach (string s in _Temp)
            {
                string[] _SplitString = s.Split(new char[] { ' ' });
                int _NodeA = Convert.ToInt32(_SplitString[0]);
                int _NodeB = Convert.ToInt32(_SplitString[1]);
                int _Weight = Convert.ToInt32(_SplitString[2]);
                _Graph[_NodeA].Add(new Vertex(_NodeB, _Weight));
            }

            PriorityQueue<Vertex> _PriorityQueue = new PriorityQueue<Vertex>();
            bool[] _Visited = new bool[_NumOfVertices + 1];
            int[] _Distance = new int[_NumOfVertices + 1];
            Vertex _SourceVertex = new Vertex(1, 0);
            _Distance[_SourceVertex.Node] = 0;
            for (int i = 2; i < _Distance.Length; i++)
            {
                _Distance[i] = Convert.ToInt32(Math.Pow(10, 9));
            }
            _PriorityQueue.Enqueue(_SourceVertex);
            while (_PriorityQueue.Count() > 0)
            {
                Vertex _CurrentNode = _PriorityQueue.Dequeue();
                if (_PriorityQueue.IsConsistent() == false)
                {
                    Console.WriteLine("Priority Queue Error");
                }
                if (_Visited[_CurrentNode.Node] == true)
                    continue;
                _Visited[_CurrentNode.Node] = true;

                for (int i = 0; i < _Graph[_CurrentNode.Node].Count; i++)
                {
                    if (_Distance[_CurrentNode.Node] + _Graph[_CurrentNode.Node][i].Weight < _Distance[_Graph[_CurrentNode.Node][i].Node])
                    {
                        _Distance[_Graph[_CurrentNode.Node][i].Node] = _Distance[_CurrentNode.Node] + _Graph[_CurrentNode.Node][i].Weight;
                        _PriorityQueue.Enqueue(new Vertex(_Graph[_CurrentNode.Node][i].Node, _Distance[_Graph[_CurrentNode.Node][i].Node]));
                        if (_PriorityQueue.IsConsistent() == false)
                        {
                            Console.WriteLine("Priority Queue Error");
                        }
                    }
                }
            }

            for (int i = 2; i < _Distance.Length; i++)
            {
                Console.WriteLine(_Distance[i]);
            }
            Console.ReadKey();
        }
    }
   
}
