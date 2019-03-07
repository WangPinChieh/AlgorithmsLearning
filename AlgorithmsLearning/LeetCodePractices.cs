using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class LeetCodePractices
    {
        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public LeetCodePractices()
        {

            //Console.WriteLine(NumJewelsInStones("aA", "aAAbbb"));
            //int[] T = new int[10];
            //T[0] = 9;
            //T[1] = 1;
            //T[2] = 4;
            //T[3] = 9;
            //T[4] = 0;
            //T[5] = 4;
            //T[6] = 8;
            //T[7] = 9;
            //T[8] = 0;
            //T[9] = 1;
            //int[] _Result = SummarizeDistanceInfo(T);

            //string[] _Emails = new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            //int _Result = NumUniqueEmails(_Emails);

            //TreeNode _Root = new TreeNode(3);
            //_Root.left = new TreeNode(0);
            //_Root.right = new TreeNode(4);
            //_Root.left.right = new TreeNode(2);
            //_Root.left.right.left = new TreeNode(1);

            //_Root = TrimBST(_Root, 1, 3);

            //TreeNode _Root = new TreeNode(2);
            //_Root.left = new TreeNode(1);
            //_Root.right = new TreeNode(3);
            //_Root = TrimBST(_Root, 3, 4);

            //ListNode _L = new ListNode(1);
            //_L.next = new ListNode(2);
            //_L.next.next = new ListNode(3);
            //_L.next.next.next = new ListNode(4);
            //_L.next.next.next.next = new ListNode(5);
            //ListNode _Result = ReverseList(_L);

            //int[] _Nums = new int[] { 2, 3, 3, 2, 4 };

            //Console.WriteLine(CheckPossibility(_Nums));

            //Console.WriteLine(BuddyStrings("aa", "aa"));

            Console.WriteLine(52 / 26);
            Console.WriteLine(52 % 26);
            Console.WriteLine(ConvertToTitle(52));
            Console.ReadKey();
        }
        public int NumJewelsInStones(string J, string S)
        {

            int _Result = 0;

            if (string.IsNullOrEmpty(J) || string.IsNullOrEmpty(S))
                return _Result;

            HashSet<char> _Set = new HashSet<char>(J.ToCharArray());

            foreach (char stone in S)
            {
                if (_Set.Contains(stone))
                    _Result++;
            }

            return _Result;
        }
        public int[] SummarizeDistanceInfo(int[] roads)
        {
            List<int>[] _Cities = new List<int>[roads.Length + 1];

            for (int i = 0; i < _Cities.Length; i++)
            {
                _Cities[i] = new List<int>();
            }


            int _StartingCity = -1;
            for (int city = 0; city < roads.Length; city++)
            {
                if (roads[city] == city)
                    _StartingCity = city;

                _Cities[city].Add(roads[city]);
                _Cities[roads[city]].Add(city);
            }
            int[] _Level = new int[roads.Length];
            bool[] _Visited = new bool[roads.Length];

            FindDepth(_Cities, _Level, _Visited, _StartingCity, 0);

            return _Level;


        }
        public void FindDepth(List<int>[] cities, int[] level, bool[] visited, int index, int currentLevel)
        {

            if (visited[index])
                return;

            visited[index] = true;

            foreach (int city in cities[index])
            {
                FindDepth(cities, level, visited, city, currentLevel + 1);
            }

            level[currentLevel]++;
        }
        public int NumUniqueEmails(string[] emails)
        {
            for (int i = 0; i < emails.Length; i++)
            {
                string[] _EmailSplit = emails[i].Split(new char[] { '@' });
                _EmailSplit[0] = _EmailSplit[0].Replace(".", "");

                if (_EmailSplit[0].IndexOf("+") != -1)
                    _EmailSplit[0] = _EmailSplit[0].Substring(0, _EmailSplit[0].IndexOf("+"));

                emails[i] = string.Join("", _EmailSplit);
            }

            HashSet<string> _Result = new HashSet<string>(emails);

            return _Result.Count;
        }
        private TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return null;

            root.left = TrimBST(root.left, L, R);

            root.right = TrimBST(root.right, L, R);

            if (root.val < L || root.val > R)
            {
                if (root.left != null)
                    return root.left;
                else if (root.right != null)
                    return root.right;
                else
                    return null;
            }

            return root;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode _Pointer = head;
            ListNode _Previous = null;
            ListNode _NewHead = null;
            while (_Pointer != null)
            {
                ListNode _Next = _Pointer.next;

                _Pointer.next = _Previous;

                _Previous = _Pointer;

                _NewHead = _Pointer;

                _Pointer = _Next;
            }

            return _NewHead;
        }

        public bool CheckPossibility(int[] nums)
        {
            int _Counter = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    if (nums[i - 1] > nums[i + 1])
                        nums[i - 1] = nums[i];
                    else
                        nums[i] = nums[i - 1];

                    _Counter++;
                }
                if (nums[i] > nums[i + 1])
                {
                    if (nums[i - 1] > nums[i + 1])
                        nums[i + 1] = nums[i];
                    else
                        nums[i] = nums[i + 1];

                    _Counter++;
                }
            }

            return _Counter <= 1;
        }
        public int Reverse(int x)
        {
            bool _IsMinus = x < 0;
            int _Result = 0;
            string _IntString = x.ToString();
            string _ReversedIntString = string.Empty;

            if (_IsMinus)
                _IntString = _IntString.Replace("-", "");

            for (int i = _IntString.Length - 1; i >= 0; i--)
            {
                _ReversedIntString += _IntString[i];
            }

            if (_IsMinus)
                _ReversedIntString = "-" + _ReversedIntString;

            if (int.TryParse(_ReversedIntString, out _Result))
                return _Result;
            else
                return 0;

        }
        public bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length)
                return false;

            int _DifferenceCounter = 0;
            int _LenOfString = A.Length;
            bool _HasTwoAlternatives = false;
            int[] _NumOfWordsInA = new int[123];
            int[] _NumOfWordsInB = new int[123];
            for (int i = 0; i < _LenOfString; i++)
            {
                if (!A[i].Equals(B[i]))
                    _DifferenceCounter++;

                if (_DifferenceCounter > 2)
                    return false;

                _NumOfWordsInA[A[i]]++;
                _NumOfWordsInB[B[i]]++;
            }
            for (int i = 1; i < 123; i++)
            {
                if (!_NumOfWordsInA[i].Equals(_NumOfWordsInB[i]))
                    return false;

                if (_NumOfWordsInA[i] >= 2 && _NumOfWordsInB[i] >= 2)
                    _HasTwoAlternatives = true;

            }

            return _DifferenceCounter == 2 || (_DifferenceCounter == 0 && _HasTwoAlternatives);
        }
        /*Sieve of Eratosthenes*/
        public int CountPrimes(int n)
        {
            int _Result = 0;
            bool[] _PrimeMarker = new bool[n];
            for (long i = 2; i < n; i++)
            {
                if (_PrimeMarker[i] == true)
                    continue;

                int _Added = 0;
                while (i * (i + _Added) < n)
                {
                    _PrimeMarker[i * (i + _Added)] = true;
                    _Added++;
                }
            }

            for (long i = 2; i < n; i++)
            {
                if (_PrimeMarker[i] == false)
                    _Result++;
            }

            return _Result;
        }
        /*Given a positive integer, return its corresponding column title as appear in an Excel sheet.*/
        public string ConvertToTitle(int n)
        {
            string _Result = string.Empty;
            string[] _AlphabetBase = new string[27];
            int _Index = 1;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                _AlphabetBase[_Index] = c.ToString();
                _Index++;
            }
            if (n <= 26)
            {
                return _AlphabetBase[n];
            }
            else
                return ConvertToTitleHelper(n, _AlphabetBase);
        }
        public string ConvertToTitleHelper(int n, string[] alphabetBase)
        {
            string _Result = string.Empty;
            int _ReminingNum = n % 26;
            int _DividedNum = n / 26;
            if (_ReminingNum == 0)
            {
                _ReminingNum = 26;
                _DividedNum--;
            }

            if (n / 26 > 26)
            {
                _Result = ConvertToTitleHelper(_DividedNum, alphabetBase) + alphabetBase[_ReminingNum];
            }
            else
                _Result = alphabetBase[_DividedNum] + alphabetBase[_ReminingNum];

            return _Result;
        }
    }

    public class MyLinkedList
    {
        private ListNode m_LinkedList = null;
        private int m_Length = 0;
        /** Initialize your data structure here. */
        public MyLinkedList()
        {

        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (this.m_LinkedList == null)
                return -1;

            if (index >= 0 && index < this.m_Length)
            {
                ListNode _Pointer = this.m_LinkedList;
                int _LoopCounter = 0;

                while (_LoopCounter != index)
                {
                    _Pointer = _Pointer.next;
                    _LoopCounter++;
                }

                return _Pointer.val;
            }
            else
                return -1;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            ListNode _NewHead = new ListNode(val)
            {
                next = this.m_LinkedList
            };

            this.m_LinkedList = _NewHead;
            this.m_Length++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            ListNode _Node = new ListNode(val);
            if (this.m_LinkedList == null)
                this.m_LinkedList = _Node;
            else
            {
                ListNode _Pointer = this.m_LinkedList;
                while (_Pointer.next != null)
                {
                    _Pointer = _Pointer.next;
                }
                _Pointer.next = _Node;
            }
            this.m_Length++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > this.m_Length)
                return;

            if (index == this.m_Length || this.m_LinkedList == null)
            {
                AddAtTail(val);
                return;
            }

            ListNode _Pointer = this.m_LinkedList;
            int _Counter = 0;
            while (_Pointer.next != null && index != _Counter + 1)
            {
                _Pointer = _Pointer.next;
                _Counter++;
            }

            ListNode _Next = _Pointer.next;
            _Pointer.next = new ListNode(val) { next = _Next };
            this.m_Length++;

        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (this.m_LinkedList == null)
                return;
            if (index >= 0 && index < this.m_Length)
            {
                ListNode _Pointer = this.m_LinkedList;
                ListNode _PreviousPointer = null;
                int _Counter = 0;
                while (_Pointer.next != null && _Counter != index)
                {
                    _PreviousPointer = _Pointer;
                    _Pointer = _Pointer.next;
                    _Counter++;
                }
                _PreviousPointer.next = _Pointer.next;
                this.m_Length--;
            }
        }
    }
}
