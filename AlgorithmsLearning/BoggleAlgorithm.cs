using System;
namespace AlgorithmsLearning
{
    public class BoggleAlgorithm
    {
        private string[] m_Dictionary;
        private char[,] m_Boggle;
        public BoggleAlgorithm()
        {
            this.m_Dictionary = new string[] { "GEEKS", "FOR", "QUIZ", "GO" };
            this.m_Boggle = new char[,] {
                       {'G','I','Z'},
                       {'U','E','K'},
                       {'Q','S','E'} };
        }
        public void FindWords()
        {
            bool[,] _Visited = new bool[this.m_Boggle.GetLength(0), this.m_Boggle.GetLength(1)];
            for (int x = 0; x < this.m_Boggle.GetLength(0); x++)
            {
                for (int y = 0; y < this.m_Boggle.GetLength(1); y++)
                {
                    FindWordsHelper(string.Empty, x, y, _Visited);
                }
            }

        }
        public void FindWordsHelper(string word, int x, int y, bool[,] visited)
        {
            visited[x, y] = true;
            word += this.m_Boggle[x, y];
            if (IsWord(word))
                Console.WriteLine(word);
            for (int xp = x - 1; xp <= x + 1 && xp < this.m_Boggle.GetLength(0); xp++)
            {
                for (int yp = y - 1; yp <= y + 1 && yp < this.m_Boggle.GetLength(1); yp++)
                {
                    if (xp >= 0 && yp >= 0 && !visited[xp, yp])
                    {
                        visited[xp, yp] = true;
                        FindWordsHelper(word, xp, yp, visited);
                    }
                }
            }
            visited[x, y] = false;
            word = word.Substring(0, word.Length - 1);

        }
        public bool IsWord(string word)
        {
            for (int i = 0; i < this.m_Dictionary.Length; i++)
            {
                if (word == this.m_Dictionary[i])
                    return true;
            }
            return false;
        }
    }
}
