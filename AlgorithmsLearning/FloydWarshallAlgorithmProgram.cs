/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int _NumOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int count = 0; count < _NumOfTestCases; count++)
            {
                int _NumOfMatrixEdges = Convert.ToInt32(Console.ReadLine());
                string _Line = Console.ReadLine();
                string[] _SplitLine = _Line.Split(new char[] { ' ' });
                int[,] _Graph = new int[_NumOfMatrixEdges, _NumOfMatrixEdges];
                initGraph(ref _Graph);
                int _ArrayCounter = 0;
                for (int i = 0; i < _NumOfMatrixEdges; i++)
                {
                    for (int j = 0; j < _NumOfMatrixEdges; j++)
                    {
                        _Graph[i, j] = Convert.ToInt32(_SplitLine[_ArrayCounter]);
                        _ArrayCounter++;
                    }
                }
                new FloydWarshallAlgorithm(_Graph);
                Console.ReadKey();
            }


        }
        public static void initGraph(ref int[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = int.MaxValue;
                }
            }
        }
    }
}
*/