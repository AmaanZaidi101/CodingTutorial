using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Heap
    {
        List<int> heap;
        public Heap()
        {
            heap = new List<int>() { 50, 40, 25, 20, 35, 10, 15 }; //Max heap
        }

        public bool Add(int val)
        {
            try
            {
                heap.Add(val);
                RebuildHeapForAddition();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Remove()
        {
            int valToReturn = heap[0];
            int lastVal = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            heap.RemoveAt(0);
            heap.Insert(0,lastVal);
            RebuildHeapForRemoval();
            return valToReturn;
        }

        private void RebuildHeapForRemoval()
        {
            int parentIndex = 0;
            int leftChildIndex = parentIndex * 2 + 1;
            int rightChildIndex = parentIndex * 2 + 2;
            
            while (leftChildIndex < heap.Count || rightChildIndex < heap.Count)
            {
                //left child is greater than parent and also greater than right child or right child doesnt exist
                if(heap[leftChildIndex] > heap[parentIndex] && (rightChildIndex > heap.Count || heap[leftChildIndex] >= heap[rightChildIndex]))
                {
                    Swap(leftChildIndex, parentIndex);
                    parentIndex = leftChildIndex;
                }
                //right child is greater than parent and also greater than left child
                else if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[parentIndex] && heap[rightChildIndex] > heap[leftChildIndex])
                {
                    Swap(rightChildIndex, parentIndex);
                    parentIndex = rightChildIndex;
                }
                else
                {
                    break;
                }

                leftChildIndex = parentIndex * 2 + 1;
                rightChildIndex = parentIndex * 2 + 2;
            }
        }

        private void RebuildHeapForAddition()
        {
            int childIndex = heap.Count - 1;
            int parentIndex = (int)Math.Floor((decimal)(childIndex - 1) / 2);
            while(parentIndex >=0 && heap[childIndex] > heap[parentIndex])
            {
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
                parentIndex = (int)Math.Floor((decimal)(childIndex - 1) / 2);
            }
        }

        private void Swap(int childIndex, int parentIndex)
        {
            int tmp = heap[parentIndex];
            heap[parentIndex] = heap[childIndex];
            heap[childIndex] = tmp;
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (var item in heap)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
