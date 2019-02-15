using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{

    public class LeetCodePractices
    {
        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
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

            int[] _Nums = new int[] { 2,3,3,2,4 };

            Console.WriteLine(CheckPossibility(_Nums));
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
    }
}
