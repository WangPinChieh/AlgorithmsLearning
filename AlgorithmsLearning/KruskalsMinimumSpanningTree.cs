using System;
using System.Collections.Generic;

namespace AlgorithmsLearning
{
    public class KruskalsMinimumSpanningTree
    {
        public KruskalsMinimumSpanningTree()
        {
        }
        public List<Edge> Run()
        {
            UnionFindAlgorithm _UFA = new UnionFindAlgorithm();
            PriorityQueue<Edge> _Queue = new PriorityQueue<Edge>();
            List<Edge> _EdgesPicked = new List<Edge>();
            int _NumOfVertices = 9;
            int[] _Graph = new int[_NumOfVertices];
            for (int i = 0; i < _NumOfVertices; i++)
            {
                _Graph[i] = i;
            }
            List<string> _Temp = new List<string>();
            _Temp.Add("1 7 6");
            _Temp.Add("2 8 2");
            _Temp.Add("2 6 5");
            _Temp.Add("4 0 1");
            _Temp.Add("4 2 5");
            _Temp.Add("6 8 6");
            _Temp.Add("7 2 3");
            _Temp.Add("7 7 8");
            _Temp.Add("8 0 7");
            _Temp.Add("8 1 2");
            _Temp.Add("9 3 4");
            _Temp.Add("10 5 4");
            _Temp.Add("11 1 7");
            _Temp.Add("14 3 5");
            foreach (string s in _Temp)
            {
                string[] _Split = s.Split(new char[] { ' ' });
                _Queue.Enqueue(new Edge(Convert.ToInt32(_Split[1]), Convert.ToInt32(_Split[2]), Convert.ToInt32(_Split[0])));
            }
            int _Counter = 0;
            while (_Queue.Count() > 0)
            {
                if (_Counter == _NumOfVertices - 1)
                    break;
                Edge _Edge = _Queue.Dequeue();
                if (_UFA.FindRoot(_Graph, _Edge.m_NodeA) == _UFA.FindRoot(_Graph, _Edge.m_NodeB))
                    continue;
                else
                {
                    _EdgesPicked.Add(_Edge);
                    _UFA.Union(ref _Graph, _Edge.m_NodeA, _Edge.m_NodeB);
                    _Counter++;
                }
            }

            return _EdgesPicked;
        }
    }

}
