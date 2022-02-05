using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class SortFunctions
    {
        private int[] array;
        private int length;
        public SortFunctions(int[] _array)
        {
            array = _array;
            length = array.Length;
        }

        public void SelectionSort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(i, minIndex);
            }
        }

        public void BubbleSort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length-i-1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        Swap(j, j + 1);
                    }
                }
            }
        }

        public void InsertionSort()
        {
            for (int i = 1; i < array.Length; i++)
            {
                int marker = array[i];
                int j = i - 1;
                while(j >= 0 && array[j]> marker)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = marker; 
            }
        }

        public void MergeSort(int start, int end)
        {
            if (start >= end)
                return;
            int mid = (start + end) / 2;

            MergeSort(start, mid);
            MergeSort(mid + 1, end);

            Merge(start, mid, end);
        }

        private void Merge(int start, int mid, int end)
        {
            int n1 = mid - start + 1;
            int n2 = end - mid;
            int i = 0, j = 0, index = start;

            int[] left = new int[n1];
            int[] right = new int[n2];

            for (int k = 0; k < n1; k++)
            {
                left[k] = array[start + k];
            }
            for (int k = 0; k < n2; k++)
            {
                right[k] = array[mid + 1 + k];
            }

            while(i < n1 && j < n2)
            {
                if(left[i] < right[j])
                {
                    array[index] = left[i];
                    i++;
                }
                else
                {
                    array[index] = right[j];
                    j++;
                }
                index++;
            }
            while (i < n1)
            {
                array[index] = left[i];
                i++;
                index++;
            }
            while (j < n2)
            {
                array[index] = right[j];
                j++;
                index++;
            }
        }

        public void QuickSort(int start, int end, int pivotPosition)
        {
            if (start >= end)
                return;

            int i = start;
            int j = end;

            while(i < j)
            {
                //find an element greater than pivot on left side
                while(i <= end && array[i] < array[pivotPosition])
                {
                    i++;
                }
                //find an element less than pivot on right side
                while (j >= start && array[j] >= array[pivotPosition])
                {
                    j--;
                }
                //if i>=j then we have found pivot position otherwise interchange i and j
                if (i >= j)
                    break;
                else
                    Swap(i, j);
            }
            
            Swap(i, pivotPosition);
            QuickSort(start, i-1, i-1);
            QuickSort(i + 1, end, end);
        }

        public void HeapSort()
        {
            //Build initial heap
            int n = array.Length;
            for(int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(i, n);
            }
            //reduce array length to work on every iteration
            for (int i = n-1; i > 0; i--)
            {
                //swap last element and root
                Swap(i, 0);
                //recreate heap
                Heapify(0, i);
            }
        }

        private void Heapify(int i, int n)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;

            if(largest != i)
            {
                Swap(i, largest);
                Heapify(largest, n);
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
        private void Swap(int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
