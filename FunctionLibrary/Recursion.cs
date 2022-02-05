using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Recursion
    {
        public int Factorial(int num)
        {
            if (num <= 1)
                return 1;
            else
                return num * Factorial(num - 1); //num is stacking up
        }

        public int FactorialTailRecursion(int num, int totalSoFar=1)
        {
            if (num == 0)
                return totalSoFar;
            else
                return FactorialTailRecursion(num - 1, num * totalSoFar);
        }

        public void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high)
                return;
            int i = low;
            int j = high;
            int pivot = arr[low];
            while(i < j)
            {
                while(arr[i] <= pivot)
                {
                    if (i + 1 >= arr.Length)
                        break;
                    i++;
                }
                while(arr[j] > pivot)
                {
                    if (j - 1 < 0)
                        break;
                    j--;
                }
                if (i < j)
                {
                    Swap(arr, i, j);
                }
            }
            Swap(arr, low, j);
            QuickSort(arr, low, j);
            QuickSort(arr, j+1, high);
        }

        public int KthLargestElement(int[] arr, int k, int low, int high)
        {
            if (arr.Length == 1)
                return arr[0];
            if (low >= high)
                return -999;

            int i = low;
            int j = high;
            int pivot = arr[low];
            while (i < j)
            {
                while (i < arr.Length && arr[i] <= pivot)
                {
                    i++;
                }
                while(j >=0 && arr[j] > pivot)
                {
                    j--;
                }
                if (i < j)
                {
                    Swap(arr, i, j);
                }
            }
            Swap(arr, low, j);
            if (j == arr.Length - k)
                return arr[j];
            else if(arr.Length - k >= low && arr.Length - k <= j && j != high)
            {
                return KthLargestElement(arr, k, low, j);
            }
            else if(arr.Length - k >= j+1 && arr.Length - k <= high && j+1 != low)
            {
                return KthLargestElement(arr, k, j + 1, high);
            }
            else
            {
                return arr[j];
            }
        }

        public void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static int left;
        public static int right;
        public int[] StartAndEndIndex(int[] arr, int num)
        {
            int leftReturn, rightReturn;
            leftReturn = rightReturn = left = right = FindIndexThroughBinarySearch(arr, num, 0, arr.Length - 1);
            
            while (leftReturn != -1 && rightReturn != -1)
            {
                leftReturn = FindIndexThroughBinarySearch(arr, num, 0, leftReturn - 1);
                rightReturn = FindIndexThroughBinarySearch(arr, num, rightReturn + 1, arr.Length-1);
                left = Math.Max(left, leftReturn);
                right = Math.Max(right, rightReturn);
            }

            return new int[]{ left, right};
        }

        private int FindIndexThroughBinarySearch(int[] arr, int num, int low, int high)
        {
            int mid = (low + high) / 2;
            int index = -1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (arr[mid] == num)
                {
                    index = mid;
                    break;
                }
                else if (arr[mid] > num)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return index;
        }
    }
}
