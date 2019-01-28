using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLearning
{
    public class PrimsMinimumSpanningTree
    {
        private int m_NumOfVerties;
        public PrimsMinimumSpanningTree(int numOfVerties)
        {
            this.m_NumOfVerties = numOfVerties;
        }
        public List<Edge> Run()
        {
            List<int> _IncludedVerties = new List<int>();
            List<int> _ExcludedVerties = new List<int>();
            List<Edge> _EdgesPicked = new List<Edge>();
            Dictionary<int, List<Edge>> _Graph = new Dictionary<int, List<Edge>>();
            #region init graph
            for (int i = 0; i < this.m_NumOfVerties;i++)
            {
                _Graph[i] = new List<Edge>();
                _ExcludedVerties.Add(i);
            }
            List<string> _Temp = new List<string>();
            _Temp.Add("0 2 200");
            _Temp.Add("0 3 70");
            _Temp.Add("0 4 50");
            _Temp.Add("1 2 70");
            _Temp.Add("1 3 70");
            _Temp.Add("1 4 300");
            _Temp.Add("2 3 60");
            _Temp.Add("4 3 90");
            foreach(string s in _Temp)
            {
                string[] _SplitStrings = s.Split(" ");
                int _NodeA = Convert.ToInt32(_SplitStrings[0]);
                int _NodeB = Convert.ToInt32(_SplitStrings[1]);
                int _Weight = Convert.ToInt32(_SplitStrings[2]);
                _Graph[_NodeA].Add(new Edge(_NodeA, _NodeB, _Weight));
                _Graph[_NodeB].Add(new Edge(_NodeA, _NodeB, _Weight));
            }
            #endregion
            _IncludedVerties.Add(_ExcludedVerties[0]);
            _ExcludedVerties.RemoveAt(0);

            while (_ExcludedVerties.Count > 0)
            {
                PriorityQueue<Edge> _PriorityQueue = new PriorityQueue<Edge>();
                foreach (int i in _IncludedVerties)
                {
                    foreach (Edge e in _Graph[i])
                    {
                        if (_IncludedVerties.Contains(e.m_NodeA) && _IncludedVerties.Contains(e.m_NodeB))
                            continue;
                        _PriorityQueue.Enqueue(e);
                    }
                }
                Edge _SmallestWegitEdge = _PriorityQueue.Dequeue();
                _EdgesPicked.Add(_SmallestWegitEdge);
                int _ExchagnedVertex = 0;
                if (!_IncludedVerties.Contains(_SmallestWegitEdge.m_NodeA))
                    _ExchagnedVertex = _SmallestWegitEdge.m_NodeA;
                else
                    _ExchagnedVertex = _SmallestWegitEdge.m_NodeB;
                _IncludedVerties.Add(_ExchagnedVertex);
                _ExcludedVerties.Remove(_ExchagnedVertex);
            }
            return _EdgesPicked;
        }
    }
}
