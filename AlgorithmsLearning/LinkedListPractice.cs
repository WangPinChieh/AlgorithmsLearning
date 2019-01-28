using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{
    public class LinkedListPractice
    {
        public LinkedListPractice()
        {

            //Node a = new Node('g');
            //a.next = new Node('e');
            //a.next.next = new Node('e');
            //a.next.next.next = new Node('k');
            //a.next.next.next.next = new Node('s');
            //a.next.next.next.next.next = new Node('a');

            //Node b = new Node('g');
            //b.next = new Node('e');
            //b.next.next = new Node('e');
            //b.next.next.next = new Node('k');
            //b.next.next.next.next = new Node('s');
            //b.next.next.next.next.next = new Node('b');

            //int _Result = CompareNodes(a, b);

            //Stack<int> _Stack = new Stack<int>();

            //Node a = new Node(1);
            //a.next = new Node(2);
            //a.next.next = new Node(3);
            //a.next.next.next = new Node(4);
            //a.next.next.next.next = new Node(5);
            //a.next.next.next.next.next = new Node(6);


            //Node b = new Node(1);
            //b.next = new Node(2);
            //b.next.next = new Node(3);
            //b.next.next.next = new Node(4);
            //b.next.next.next.next = new Node(5);
            //b.next.next.next.next.next = new Node(6);

            //int _SizeOfA = GetSize(a);
            //int _SizeOfB = GetSize(b);
            //if (_SizeOfA < _SizeOfB)
            //    a = PropogateLinkedList(a, _SizeOfB - _SizeOfA);
            //else if(_SizeOfA > _SizeOfB)
            //    b = PropogateLinkedList(b, _SizeOfA - _SizeOfB);

            //AddNodes(a, b, _Stack);

            //Node a = new Node(1);
            //a.next = new Node(2);
            //a.next.next = new Node(3);
            //a.next.next.next = new Node(4);
            //a.next.next.next.next = new Node(5);
            //a.next.next.next.next.next = new Node(6);


            //Node b = new Node(7);
            //b.next = new Node(8);
            //b.next.next = new Node(9);
            //b.next.next.next = new Node(10);
            //b.next.next.next.next = new Node(11);
            //b.next.next.next.next.next = new Node(12);

            //MergeLinkedList(ref a, ref b);


            //Node b = new Node(7);
            //b.next = new Node(8);
            //b.next.next = new Node(9);
            //b.next.next.next = new Node(10);
            //b.next.next.next.next = new Node(11);
            //b.next.next.next.next.next = new Node(12);
            //Node _Result = ReverseLinkedListEveryK(b, 3);

            //Node a = new Node(1);
            //a.next = new Node(2);
            //a.next.next = new Node(3);
            //a.next.next.next = new Node(4);
            //a.next.next.next.next = new Node(5);
            //a.next.next.next.next.next = new Node(6);
            //a.next.next.next.next.next.next = new Node(7);
            //a.next.next.next.next.next.next.next = new Node(8);
            //a.next.next.next.next.next.next.next = a.next.next;
            //DetectAndRemoveLoop(ref a);

            //Node b = new Node(6);
            //b.next = new Node(9);
            //b.next.next = new Node(7);
            //b.next.next.next = new Node(1);
            //b.next.next.next.next = new Node(4);
            //b.next.next.next.next.next = new Node(8);
            //MergeSort(ref b);
            while (true)
            {
                Node b = new Node(6);
                b.next = new Node(9);
                b.next.next = new Node(7);
                b.next.next.next = new Node(1);
                b.next.next.next.next = new Node(4);
                b.next.next.next.next.next = new Node(8);
                Node _Result = SelectSingleNode_ReservoirSampling(b);
                Console.WriteLine(_Result.data);
                Thread.Sleep(10);
            }
        }

        public Node SortedInsert(Node head, int key)
        {
            if (head == null)
            {
                Node _NewNode = new Node(key);
                return _NewNode;
            }
            else if (head != null && head.data >= key)
            {
                Node _NewHead = new Node(key);
                _NewHead.next = head;
                return _NewHead;
            }
            else
            {
                head.next = SortedInsert(head.next, key);
            }

            return head;
        }

        public Node DeleteNode(Node head, Node node)
        {
            if (head == node)
            {
                if (head.next == null)
                {
                    return head;
                }

                head = node.next;
            }
            Node _PreviousNode = head;
            Node _CurrentNode = head;
            while (_CurrentNode.next != null && _CurrentNode != node)
            {
                _PreviousNode = _CurrentNode;
                _CurrentNode = _CurrentNode.next;
            }

            if (_CurrentNode.next == null && _CurrentNode != node)
            {
                return head;
            }

            _PreviousNode.next = _CurrentNode.next;

            return head;

        }

        public int CompareNodes(Node node1, Node node2)
        {
            if (node1 == null && node2 == null)
                return 0;

            if (node1 == null && node2 != null)
                return -1;

            if (node1 != null && node2 == null)
                return 1;

            if (node1 != null && node2 != null && node1.data == node2.data)
                return CompareNodes(node1.next, node2.next);
            else
                return (node1.data > node2.data) ? 1 : -1;

            return 0;
        }

        public Node PropogateLinkedList(Node node, int numOfNodesAdded)
        {
            Node _NewHead = null;
            Node _CurrentNode = node;
            for (int i = 0; i < numOfNodesAdded; i++)
            {
                _NewHead = new Node(0);
                _NewHead.next = _CurrentNode;
                _CurrentNode = _NewHead;
            }
            return _NewHead;
        }

        public int AddNodes(Node node1, Node node2, Stack<int> stack)
        {
            int _Carry = 0;
            if (node1.next != null && node2.next != null)
                _Carry = AddNodes(node1.next, node2.next, stack);

            int _Sum = node1.data + node2.data + _Carry;
            _Carry = _Sum / 10;
            _Sum = _Sum % 10;
            stack.Push(_Sum);
            return _Carry;
        }

        public int GetSize(Node node)
        {
            int _Counter = 0;
            while (node != null)
            {
                _Counter++;
                node = node.next;
            }
            return _Counter;
        }
        /*
        List 1: 1->2->3
        List 2: 4->5->6
        Merged: 1->4->2->5->3->6
        */
        public void MergeLinkedList(ref Node node1, ref Node node2)
        {
            if (node1 == null || node2 == null)
                return;

            Node _Current = node1;
            Node _NodeToBeMerged = node2;
            while (_Current != null && _NodeToBeMerged != null)
            {
                node2 = node2.next;
                Node _Temp = _Current.next;
                _Current.next = _NodeToBeMerged;
                _NodeToBeMerged.next = _Temp;

                _Current = _Temp;
                _NodeToBeMerged = node2;
            }
        }
        public Node ReverseLinkedListEveryK(Node node, int k)
        {
            Node _Current = node;
            Node _Next = null;
            Node _Prev = null;
            int _Counter = 0;

            while (_Counter < k && _Current != null)
            {
                _Next = _Current.next;
                _Current.next = _Prev;
                _Prev = _Current;
                _Current = _Next;

                _Counter++;
            }
            if (_Next != null)
                node.next = ReverseLinkedListEveryK(_Next, k);

            return _Prev;
        }
        public Node Union(Node head1, Node head2)
        {
            List<Node> _Result = new List<Node>();
            Node _NewHead = null;

            if (head1 == null && head2 == null)
                return null;
            else if (head1 != null && head2 == null)
                return head1;
            else if (head1 == null && head2 != null)
                return head2;
            else
            {
                Node _Current = head1;
                while (_Current != null)
                {
                    if (!_Result.Contains(_Current))
                    {
                        _Result.Add(_Current);
                        this.Push(ref _NewHead, _Current.data);
                    }

                    _Current = _Current.next;
                }
                _Current = head2;
                while (_Current != null)
                {
                    if (!_Result.Contains(_Current))
                    {
                        _Result.Add(_Current);
                        this.Push(ref _NewHead, _Current.data);
                    }

                    _Current = _Current.next;
                }
            }

            return _NewHead;
        }
        public Node Intersect(Node head1, Node head2)
        {
            List<Node> _Result = new List<Node>();
            Node _NewHead = null;

            if (head1 == null && head2 == null)
                return null;
            else if (head1 != null && head2 == null)
                return head1;
            else if (head1 == null && head2 != null)
                return head2;
            else
            {
                Node _Current = head1;
                while (_Current != null)
                {
                    if (!_Result.Contains(_Current))
                    {
                        _Result.Add(_Current);
                    }

                    _Current = _Current.next;
                }
                _Current = head2;
                while (_Current != null)
                {
                    if (_Result.Contains(_Current))
                    {
                        _Result.Add(_Current);
                        this.Push(ref _NewHead, _Current.data);
                    }

                    _Current = _Current.next;
                }
            }

            return _NewHead;
        }
        public void Push(ref Node head, int newNode)
        {
            Node _Node = new Node(newNode);
            _Node.next = head;
            head = _Node;
        }
        public void DetectAndRemoveLoop(ref Node head)
        {
            bool _HasCycle = false;
            Node _FastNode = head;
            Node _SlowNode = head;
            while (true)
            {
                if (_FastNode == null)
                    break;
                _FastNode = _FastNode.next;

                if (_FastNode == null)
                    break;
                _FastNode = _FastNode.next;
                _SlowNode = _SlowNode.next;

                if (_FastNode == _SlowNode)
                {
                    _HasCycle = true;
                    break;
                }
            }
            if (_HasCycle == true)
            {
                Stack<Node> _Stack = new Stack<Node>();
                Node _Current = head;

                while (_Current != null)
                {
                    if (!_Stack.Contains(_Current))
                    {
                        _Stack.Push(_Current);
                    }
                    else
                        break;
                    _Current = _Current.next;
                }
                Node _LastNode = _Stack.Pop();
                _LastNode.next = null;
            }
        }
        public void MergeSort(ref Node head)
        {
            if (head == null || head.next == null)
                return;
            Node _NodeA = new Node(0);
            Node _NodeB = new Node(0);
            FrontBackSplit(head, ref _NodeA, ref _NodeB);

            MergeSort(ref _NodeA);
            MergeSort(ref _NodeB);

            head = SortedMerge(_NodeA, _NodeB);

        }
        public void FrontBackSplit(Node head, ref Node nodeA, ref Node nodeB)
        {
            if (head == null || head.next == null)
                return;
            Node _FastNode = head;
            Node _SlowNode = head;
            while (_FastNode != null)
            {
                _FastNode = _FastNode.next;
                if (_FastNode == null)
                    break;
                _FastNode = _FastNode.next;
                if (_FastNode == null)
                    break;
                _SlowNode = _SlowNode.next;
            }

            nodeA = head;
            nodeB = _SlowNode.next;
            _SlowNode.next = null;
        }
        public Node SortedMerge(Node nodeA, Node nodeB)
        {
            Node _Result;
            if (nodeA == null)
                return nodeB;
            if (nodeB == null)
                return nodeA;

            if (nodeA.data <= nodeB.data)
            {
                _Result = nodeA;
                _Result.next = SortedMerge(nodeA.next, nodeB);
            }
            else
            {
                _Result = nodeB;
                _Result.next = SortedMerge(nodeA, nodeB.next);
            }
            return _Result;
        }
        public Node SelectSingleNode_ReservoirSampling(Node node)
        {
            if (node == null)
                return node;
            Node _Current = node;
            Node _Result = node;
            int _Counter;
            Random _Random = new Random(Convert.ToInt32(DateTime.Now.ToOADate().ToString().Substring(6, 8)));
            for (_Counter = 2; _Current != null; _Counter++)
            {
                int _RandomNum = _Random.Next(0, _Counter+1);
                while (_RandomNum == 0)
                    _RandomNum = _Random.Next(0, _Counter+1);

                if (_RandomNum % _Counter == 0)
                    _Result = _Current;

                _Current = _Current.next;
            }

            return _Result;
        }
    }
}
