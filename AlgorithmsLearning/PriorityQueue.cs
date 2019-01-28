using System;
using System.Collections.Generic;

namespace AlgorithmsLearning
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> m_Data;
        public PriorityQueue()
        {
            this.m_Data = new List<T>();
        }
        public void Enqueue(T item)
        {
            this.m_Data.Add(item);
            int _CurrentIndex = this.m_Data.Count - 1;
            while (_CurrentIndex > 0)
            {
                int _ParentIndex = (_CurrentIndex - 1) / 2;
                if (this.m_Data[_CurrentIndex].CompareTo(this.m_Data[_ParentIndex]) >= 0)
                    break;
                T _Temp = this.m_Data[_CurrentIndex];
                this.m_Data[_CurrentIndex] = this.m_Data[_ParentIndex];
                this.m_Data[_ParentIndex] = _Temp;
                _CurrentIndex = _ParentIndex;
            }
        }
        public T Dequeue()
        {
            int _LastIndex = this.m_Data.Count - 1;
            T _FrontItem = this.m_Data[0];
            this.m_Data[0] = this.m_Data[_LastIndex];
            this.m_Data.RemoveAt(_LastIndex);
            --_LastIndex;
            int _ParentIndex = 0;
            while (true)
            {
                int _CurrentIndex = _ParentIndex * 2 + 1;
                if (_CurrentIndex > _LastIndex)
                    break;
                int _CurrentRightIndex = _CurrentIndex + 1;
                if (_CurrentRightIndex <= _LastIndex && this.m_Data[_CurrentRightIndex].CompareTo(this.m_Data[_CurrentIndex]) < 0)
                    _CurrentIndex = _CurrentRightIndex;
                if (this.m_Data[_ParentIndex].CompareTo(this.m_Data[_CurrentIndex]) <= 0)
                    break;

                T _Temp = this.m_Data[_CurrentIndex];
                this.m_Data[_CurrentIndex] = this.m_Data[_ParentIndex];
                this.m_Data[_ParentIndex] = _Temp;
                _ParentIndex = _CurrentIndex;

            }
            return _FrontItem;
        }
        public int Count(){
            return this.m_Data.Count;
        }
        public T Peek(){
            T _FrontItem = this.m_Data[0];
            return _FrontItem;
        }
        public bool IsConsistent()
        {
            if (this.m_Data.Count == 0) return true;
            int li = this.m_Data.Count - 1; // last index
            for (int pi = 0; pi < this.m_Data.Count; ++pi) // each parent index
            {
                int lci = 2 * pi + 1; // left child index
                int rci = 2 * pi + 2; // right child index
                if (lci <= li && this.m_Data[pi].CompareTo(this.m_Data[lci]) > 0) return false;
                if (rci <= li && this.m_Data[pi].CompareTo(this.m_Data[rci]) > 0) return false;
            }
            return true; // Passed all checks
        }
    }
}
