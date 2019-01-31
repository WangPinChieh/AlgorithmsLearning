using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{
    class SortingAndSearching
    {
        public SortingAndSearching()
        {

            //int[] arr = new int[] { 1, 2, 3, 4 };
            //int target = 5;
            //int result = BinarySearch(arr, target, 0, arr.Length - 1);

            //int[] arr = new int[] { 3, 4, 5, 1, 2 };
            //int target = 5;
            //int result = 0;
            //int pivot = FindPivotPoint(arr, 0, arr.Length - 1);
            //if (pivot == -1)
            //    result = BinarySearch(arr, target, 0, arr.Length - 1);
            //else
            //{
            //    if (arr[pivot] == target)
            //        result = pivot;
            //    else
            //    {
            //        if (arr[0] > target)
            //            result = BinarySearch(arr, target, pivot + 1, arr.Length - 1);
            //        else
            //            result = BinarySearch(arr, target, 0, pivot);

            //    }

            //}
            int[] arr = new int[] { 5, 7, 3, 9, 4, 6 };
            //BubbleSort(arr);

            //InsertionSort(arr);

            //int[] _Result = MergeSort_Sort(arr, 0, arr.Length - 1);

            HeapSort(arr);
            int _LeftIndex = 0;
            int _RightIndex = 0;
            FindClosestPair(arr, 10, out _LeftIndex, out _RightIndex);

            Console.ReadKey();
        }

        public int BinarySearch(int[] arr, int target, int startingIndex, int endingIndex)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            if (startingIndex > endingIndex)
                return -1;

            int _MiddleIndex = (startingIndex + endingIndex) / 2;

            if (arr[_MiddleIndex] == target)
                return _MiddleIndex;
            if (arr[_MiddleIndex] < target)
                return BinarySearch(arr, target, _MiddleIndex + 1, endingIndex);
            else
                return BinarySearch(arr, target, startingIndex, _MiddleIndex - 1);

        }

        public int FindPivotPoint(int[] arr, int startingIndex, int endingIndex)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            if (startingIndex > endingIndex)
                return -1;

            int _MiddleIndex = (startingIndex + endingIndex) / 2;

            if (_MiddleIndex < endingIndex && arr[_MiddleIndex] > arr[_MiddleIndex + 1])
                return _MiddleIndex;
            if (_MiddleIndex > startingIndex && arr[_MiddleIndex] < arr[_MiddleIndex - 1])
                return _MiddleIndex - 1;

            if (arr[_MiddleIndex] < arr[0])
                return FindPivotPoint(arr, startingIndex, _MiddleIndex - 1);
            else
                return FindPivotPoint(arr, _MiddleIndex + 1, endingIndex);

        }
        public void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        int _Temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = _Temp;
                    }
                }
            }
        }

        public void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {

                if (arr[i - 1] <= arr[i])
                    continue;

                int _Current = arr[i];
                int j = i - 1;
                while (j >= 0 && _Current < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = _Current;

            }
        }
        public int[] MergeSort_Sort(int[] arr, int i, int j)
        {

            if (arr == null || arr.Length == 1)
                return arr;

            int _Mid = (i + j) / 2;
            int[] _Left = new int[_Mid + 1];
            int[] _Right = new int[j - _Mid];
            for (int m = i, counter = 0; m <= _Mid; m++)
            {
                _Left[counter] = arr[m];
                counter++;
            }
            for (int n = _Mid + 1, counter = 0; n <= j; n++)
            {
                _Right[counter] = arr[n];
                counter++;
            }

            _Left = MergeSort_Sort(_Left, 0, _Left.Length - 1);
            _Right = MergeSort_Sort(_Right, 0, _Right.Length - 1);

            return MergeSort_Merge(_Left, _Right);
        }
        public int[] MergeSort_Merge(int[] left, int[] right)
        {
            if (left == null || left.Length == 0)
                return right;
            if (right == null || right.Length == 0)
                return left;

            int[] _Result = new int[left.Length + right.Length];

            int i = 0;
            int j = 0;
            int _Counter = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    _Result[_Counter] = left[i];
                    i++;
                }
                else
                {
                    _Result[_Counter] = right[j];
                    j++;
                }
                _Counter++;
            }
            while (i < left.Length)
            {
                _Result[_Counter] = left[i];
                i++;
                _Counter++;
            }
            while (j < right.Length)
            {
                _Result[_Counter] = right[j];
                j++;
                _Counter++;
            }

            return _Result;
        }

        public void HeapSort(int[] arr)
        {

            for (int i = (arr.Length - 1) / 2; i >= 0; i--)
            {
                Heapify(arr, arr.Length, i);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                int _Temp = arr[i];
                arr[i] = arr[0];
                arr[0] = _Temp;

                Heapify(arr, i, 0);
            }
        }
        public void Heapify(int[] arr, int n, int i)
        {
            if (arr == null || n == 0)
                return;

            int _LargestIndex = i;
            int _LeftIndex = i * 2 + 1;
            int _RightIndex = i * 2 + 2;

            if (_LeftIndex < n && arr[_LeftIndex] > arr[_LargestIndex])
                _LargestIndex = _LeftIndex;
            if (_RightIndex < n && arr[_RightIndex] > arr[_LargestIndex])
                _LargestIndex = _RightIndex;

            if (_LargestIndex != i)
            {
                int _Temp = arr[_LargestIndex];
                arr[_LargestIndex] = arr[i];
                arr[i] = _Temp;
                Heapify(arr, n, _LargestIndex);
            }

        }
        public int InterpolationSearch(int[] arr, int target)
        {
            int _StartingIndex = 0;
            int _EndingIndex = arr.Length - 1;

            while (_StartingIndex <= _EndingIndex && target >= arr[_StartingIndex] && target <= arr[_EndingIndex])
            {
                int _Pos = (_EndingIndex - _StartingIndex) * ((target - arr[_StartingIndex]) / (arr[_EndingIndex] - arr[_StartingIndex])) + _StartingIndex;

                if (arr[_Pos] == target)
                    return _Pos;

                if (arr[_Pos] > target)
                {
                    _EndingIndex = _Pos - 1;
                }
                if (arr[_Pos] < target)
                {
                    _StartingIndex = _Pos + 1;
                }
            }

            return -1;

        }
        public void QuickSort(int[] arr, int startingIndex, int endingIndex)
        {

            if (startingIndex < endingIndex)
            {

                int _PartitionIndex = Partition(arr, startingIndex, endingIndex);

                QuickSort(arr, startingIndex, _PartitionIndex - 1);
                QuickSort(arr, _PartitionIndex + 1, endingIndex);
            }

        }
        public int Partition(int[] arr, int startingIndex, int endingIndex)
        {

            int _PivotValue = arr[endingIndex];
            int _IndexToBeReplaced = startingIndex;
            int _Temp = 0;
            for (int i = startingIndex; i < endingIndex; i++)
            {
                if (arr[i] <= arr[endingIndex])
                {
                    _Temp = arr[i];
                    arr[i] = arr[_IndexToBeReplaced];
                    arr[_IndexToBeReplaced] = _Temp;

                    _IndexToBeReplaced++;
                }
            }
            _Temp = arr[_IndexToBeReplaced];
            arr[_IndexToBeReplaced] = arr[endingIndex];
            arr[endingIndex] = _Temp;

            return _IndexToBeReplaced;
        }

        public void FindClosestPair(int[] arr, int target, out int leftIndex, out int rightIndex)
        {
            leftIndex = 0;
            rightIndex = 0;

            int _LeftIndex = 0;
            int _RightIndex = arr.Length - 1;
            int _Diff = int.MaxValue;

            while (_LeftIndex < _RightIndex)
            {
                if (Math.Abs(arr[_LeftIndex] + arr[_RightIndex] - target) <= _Diff)
                {
                    leftIndex = _LeftIndex;
                    rightIndex = _RightIndex;
                    _Diff = Math.Abs(arr[_LeftIndex] + arr[_RightIndex] - target);
                }

                if (Math.Abs(arr[_LeftIndex] + arr[_RightIndex]) > target)
                    _RightIndex--;
                else
                    _LeftIndex++;
            }
        }

    }
}
