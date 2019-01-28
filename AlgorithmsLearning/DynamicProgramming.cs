using System;
using System.Collections.Generic;

namespace AlgorithmsLearning
{
    public class DynamicProgramming
    {
        public DynamicProgramming()
        {
            //String s1 = "AGGTAB";
            //String s2 = "GXTXAYB";
            //int _Result = LCS(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length);

            //int[] a = new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            //int[] _LIS;
            //int _Result = LIS(a, out _LIS);

            //char[] str1 = "cut".ToCharArray();
            //char[] str2 = "cat".ToCharArray();
            //char[] str1 = "gesek".ToCharArray();
            //char[] str2 = "geek".ToCharArray();
            //char[] str1 = "sunday".ToCharArray();
            //char[] str2 = "saturday".ToCharArray();
            //int result = CalculateEditDistance(str1, str2, str1.Length, str2.Length);

            //int[] a = new int[] { 1, 5, 11, 5 };
            //bool _Result = PartitionProblemSum(a);

            //int[] a = new int[] { 1, 6, 11, 5 };
            //int[] a = new int[] { 3, 1, 4, 2, 2, 1 };
            //int _Result = PartitionProblemMinSum(a);

            //int _Result = CountNumOfWaysToCoverDistance(4);
            //int _Result = CountNumOfWaysToConverDistanceMemoization(4);

            //int[,] _Matrix = new int[3, 3]{{1, 2, 9},
            //                               {5, 3, 8},
            //                               {4, 6, 7}};

            //int _Result = FindLongestPathFromACell(_Matrix);


            //int[] a = new int[] { 3, 34, 4, 12, 5, 2 };
            //int _TargetSum = 100;
            //bool _Result = FindSumSubset(a, a.Length - 1, _TargetSum);

            //int[] values = new int[] { 60, 100, 120 };
            //int[] weights = new int[] { 10, 20, 30 };
            //int _WeightLimitation = 50;
            //int _Result = Solve01KnapsackProblemHelper(values, weights, values.Length, _WeightLimitation);

            //String operands = "TTFTT";
            //String operators = "|&^";
            //int _Result = BooleanParenthesizationProblem(operators, operands);

            Console.ReadKey();

        }
        /*Longest Common Subsequence*/
        public int LCS(char[] x, char[] y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            if (x[m - 1] == y[n - 1])
                return 1 + LCS(x, y, m - 1, n - 1);
            else
                return Math.Max(LCS(x, y, m, n - 1), LCS(x, y, m - 1, n));
        }
        /*Longest Increasing Subsequence*/
        public int LIS(int[] array, out int[] LISArray)
        {
            int[] _Result = new int[array.Length];
            for (int i = 0; i < _Result.Length; i++)
                _Result[i] = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                        _Result[j] = Math.Max(_Result[j], _Result[i] + 1);
                }
            }

            int _Num = 0;
            for (int i = 0; i < _Result.Length; i++)
            {
                _Num = Math.Max(_Num, _Result[i]);
            }
            LISArray = new int[_Num];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                LISArray[_Result[i] - 1] = array[i];
            }
            return _Num;
        }

        public int CalculateEditDistance(char[] str1, char[] str2, int m, int n)
        {
            if (n == 0)
                return m;
            if (m == 0)
                return n;
            int _Delta = 0;
            if (str1[m - 1] != str2[n - 1])
                _Delta = 1;
            return Min(CalculateEditDistance(str1, str2, m - 1, n - 1) + _Delta,
                       CalculateEditDistance(str1, str2, m - 1, n) + 1,
                       CalculateEditDistance(str1, str2, m, n - 1) + 1);

        }
        private int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public bool PartitionProblemSum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return false;

            int _Sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                _Sum += arr[i];
            }
            if (_Sum % 2 != 0)
                return false;

            return PartitionProblemSubsetSum(arr, arr.Length - 1, _Sum / 2);

        }
        public bool PartitionProblemSubsetSum(int[] arr, int n, int sum)
        {
            if (sum == 0)
                return true;

            if (n < 0 || sum < 0)
                return false;

            bool _Include = PartitionProblemSubsetSum(arr, n - 1, sum - arr[n]);

            bool _Exclude = PartitionProblemSubsetSum(arr, n - 1, sum);

            return _Include || _Exclude;
        }
        public int PartitionProblemMinSum(int[] arr)
        {
            int _TotalSum = 0;
            for (int i = 0; i < arr.Length; i++)
                _TotalSum += arr[i];

            return PartitionProblemMinSubsetSum(arr, arr.Length - 1, 0, _TotalSum);
        }
        public int PartitionProblemMinSubsetSum(int[] arr, int n, int accumulatedSum, int totalSum)
        {
            if (n == 0)
                return Math.Abs((totalSum - accumulatedSum) - accumulatedSum);


            return Math.Min(PartitionProblemMinSubsetSum(arr, n - 1, accumulatedSum + arr[n], totalSum), PartitionProblemMinSubsetSum(arr, n - 1, accumulatedSum, totalSum));
        }
        public int CountNumOfWaysToCoverDistance(int n)
        {
            if (n == 0)
                return 1;

            if (n < 0)
                return 0;

            int _Result = 0;
            for (int i = 1; i <= 3; i++)
            {
                _Result += CountNumOfWaysToCoverDistance(n - i);
            }

            return _Result;
        }
        public int CountNumOfWaysToConverDistanceMemoization(int dist)
        {
            int[] _Count = new int[dist + 1];
            _Count[0] = 1;
            _Count[1] = 1;
            _Count[2] = 2;

            for (int i = 3; i <= dist; i++)
            {
                _Count[i] = _Count[i - 1] + _Count[i - 2] + _Count[i - 3];
            }

            return _Count[dist];
        }
        public int FindLongestPathFromACell(int[,] matrix)
        {

            int[,] _Path = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < _Path.GetLength(0); i++)
            {
                for (int j = 0; j < _Path.GetLength(1); j++)
                {
                    _Path[i, j] = -1;
                }
            }



            int _LongestPath = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    _LongestPath = Math.Max(_LongestPath, FindLongestPathFromACellHelper(i, j, matrix, _Path));
                }
            }
            return _LongestPath;

        }
        public int FindLongestPathFromACellHelper(int i, int j, int[,] matrix, int[,] path)
        {
            if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                return 0;

            if (path[i, j] != -1)
                return path[i, j];

            if (i > 0 && matrix[i - 1, j] + 1 == matrix[i, j])
                return path[i, j] = 1 + FindLongestPathFromACellHelper(i - 1, j, matrix, path);
            if (j > 0 && matrix[i, j - 1] + 1 == matrix[i, j])
                return path[i, j] = 1 + FindLongestPathFromACellHelper(i, j - 1, matrix, path);
            if (i < matrix.GetLength(0) - 1 && matrix[i + 1, j] + 1 == matrix[i, j])
                return path[i, j] = 1 + FindLongestPathFromACellHelper(i + 1, j, matrix, path);
            if (j < matrix.GetLength(1) - 1 && matrix[i, j + 1] + 1 == matrix[i, j])
                return path[i, j] = 1 + FindLongestPathFromACellHelper(i, j + 1, matrix, path);

            return path[i, j] = 1;
        }
        public bool FindSumSubset(int[] arr, int n, int sum)
        {
            if (sum == 0)
                return true;
            if (n < 0 || sum < 0)
                return false;

            return FindSumSubset(arr, n - 1, sum - arr[n]) || FindSumSubset(arr, n - 1, sum);
        }
        public int Solve01KnapsackProblemHelper(int[] values, int[] weights, int n, int weightLimitation)
        {

            if (n == 0 || weightLimitation <= 0) return 0;

            if (weights[n - 1] > weightLimitation)
                return Solve01KnapsackProblemHelper(values, weights, n - 1, weightLimitation);

            return Math.Max(Solve01KnapsackProblemHelper(values, weights, n - 1, weightLimitation - weights[n - 1]) + values[n - 1], Solve01KnapsackProblemHelper(values, weights, n - 1, weightLimitation));

        }
        public int BooleanParenthesizationProblem(string operators, string operands)
        {
            return 0;
        }
    }
}
