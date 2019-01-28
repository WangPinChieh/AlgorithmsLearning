using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{
    class BoggleAlgorithmUsingTire
    {
        public TireNode RootNode;
        private string[] m_Dictionary;
        private char[,] m_Boggle;
        private List<string> m_Result;
        private int m_NumOfRows;
        private int m_NumOfColums;
        public BoggleAlgorithmUsingTire()
        {
            RootNode = new TireNode(' ');
            m_Result = new List<string>();
            m_Dictionary = new string[] { "GEEKS", "FOR", "QUIZ", "GO" };
            m_Boggle = new char[,] {
            {'G','I','Z'},
            {'U','E','K'},
            {'Q','S','E'}};
            m_NumOfRows = this.m_Boggle.GetLength(0);
            m_NumOfColums = this.m_Boggle.GetLength(1);
            foreach (string s in m_Dictionary)
                Insert(s);
        }
        public List<string> Run()
        {
            bool[,] _Visited = new bool[m_NumOfRows, m_NumOfColums];
            for (int row = 0; row < this.m_Boggle.GetLength(0); row++)
            {
                for (int column = 0; column < this.m_Boggle.GetLength(1); column++)
                {
                    if (RootNode.ChildrenNodes[this.m_Boggle[row, column] - 'A'] != null)
                        Find(RootNode.ChildrenNodes[this.m_Boggle[row, column] - 'A'], string.Empty + this.m_Boggle[row, column], row, column, _Visited);
                }
            }
            return this.m_Result;
        }
        public void Find(TireNode node, string word, int x, int y, bool[,] visited)
        {

            if (node.IsEndOfWord)
                this.m_Result.Add(word);
            visited[x, y] = true;
            for (int xp = x - 1; xp <= x + 1 && xp < m_NumOfRows; xp++)
            {
                for (int yp = y - 1; yp <= y + 1 && yp < m_NumOfColums; yp++)
                {
                    if (xp == x && yp == y) continue;

                    if (xp >= 0 && yp >= 0 && visited[xp, yp] == false)
                    {
                        int _InnerIndex = this.m_Boggle[xp, yp] - 'A';
                        if (node.ChildrenNodes[_InnerIndex] != null)
                            Find(node.ChildrenNodes[_InnerIndex], word + this.m_Boggle[xp, yp], xp, yp, visited);
                    }
                }
            }

            visited[x, y] = false;
        }
        public void Insert(string key)
        {

            TireNode _StartingNode = RootNode;

            for (int i = 0; i < key.Length; i++)
            {
                char _Char = Convert.ToChar(key.Substring(i, 1));
                int _Index = _Char - 'A';
                if (_StartingNode.ChildrenNodes[_Index] == null)
                    _StartingNode.ChildrenNodes[_Index] = new TireNode(_Char);

                _StartingNode = _StartingNode.ChildrenNodes[_Index];
            }
            _StartingNode.IsEndOfWord = true;
        }
        public bool Search(string key)
        {
            TireNode _StartingNode = RootNode;
            for (int i = 0; i < key.Length; i++)
            {
                char _Char = Convert.ToChar(key.Substring(i, 1));
                int _Index = _Char - 'a';
                if (_StartingNode.ChildrenNodes[_Index] != null)
                {
                    _StartingNode = _StartingNode.ChildrenNodes[_Index];
                }
                else
                    return false;
            }

            return _StartingNode.IsEndOfWord;
        }
    }
    public class TireNode
    {
        public char Word;
        public TireNode[] ChildrenNodes;
        public bool IsEndOfWord;

        public TireNode(char word)
        {
            this.Word = word;
            ChildrenNodes = new TireNode[26];
            IsEndOfWord = false;
        }
    }
}
