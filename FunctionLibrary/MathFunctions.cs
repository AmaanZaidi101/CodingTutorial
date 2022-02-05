using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionLibrary
{
    public static class ArrayFunctions
    {
        public static int[] FindTwoSums(int[] arr, int sum)
        {
            if (arr.Length == 0)
                return null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > sum)
                    continue;
                else if (arr[i] == sum)
                    return new int[] { i };
                else
                {
                    int remainder = sum - arr[i];
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] == remainder)
                            return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        public static int[] FindTwoSumsOptimized(int[] arr, int sum)
        {
            if (arr.Length == 0)
                return null;
            Dictionary<int, int> hashmap = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int remainder = sum - arr[i];
                int j;

                if (hashmap.TryGetValue(arr[i], out j))
                {
                    return new int[] { j, i };
                }

                hashmap.Add(remainder, i);
            }

            return null;
        }

        public static int GetMaxWaterContainer(int[] heights)
        {
            int maxArea = 0;
            for (int i = 0; i < heights.Length-1; i++)
            {
                for (int j = i+1; j < heights.Length; j++)
                {
                    int area = Math.Min(heights[i], heights[j]) * (j - i);
                    maxArea = Math.Max(area, maxArea);
                }
            }
            return maxArea;
        }

        //start at opposite ends for max width and only move the pointer with min height of two
        public static int GetMaxWaterContainerOptimized(int[] heights)
        {
            int maxArea = 0;
            int p1 = 0;
            int p2 = heights.Length - 1;
            while(p1 < p2)
            {
                int area = (p2 - p1) * Math.Min(heights[p1], heights[p2]);
                maxArea = Math.Max(area, maxArea);

                //shift the pointer with lesser height to make it have greater height
                if (heights[p1] < heights[p2])
                    p1++;
                else
                    p2--;
            }
            return maxArea;
        }

        public static int CollectRainWater(int[] blocks)
        {
            int left = 0;
            int right = 0;
            int maxLeftHeight = 0;
            int maxRightHeight = 0;
            int totalWater = 0;

            for (int current = 1; current < blocks.Length-1; current++)
            {
                left = current - 1;
                right = current + 1;

                maxLeftHeight = blocks[left];
                maxRightHeight = blocks[right];

                while(left >=0)
                {
                    maxLeftHeight = Math.Max(maxLeftHeight, blocks[left]);
                    left--;
                }
                while (right < blocks.Length)
                {
                    maxRightHeight = Math.Max(maxRightHeight, blocks[right]);
                    right++;
                }

                int water = Math.Min(maxRightHeight, maxLeftHeight) - blocks[current];

                if (water > 0)
                    totalWater += water;

            }

            return totalWater;
        }

        public static int CollectRainWaterAgain(int[] blocks)
        {
            int totalArea = 0;
            int left = 0;
            int leftPointer = 0;
            int right = blocks.Length-1;
            int rightPointer = blocks.Length - 1;
            
           
            while (leftPointer < rightPointer)
            {
                while (leftPointer < blocks.Length && blocks[leftPointer] <= 0)
                {
                    leftPointer++;
                }
                left = leftPointer;
                while (left < rightPointer)
                {
                    if (blocks[rightPointer] > 0 && (blocks[rightPointer] >= blocks[left] || 
                        (blocks[rightPointer] < blocks[left] && blocks[rightPointer]>=blocks[right])
                        ))
                        right = rightPointer;
                    rightPointer--;
                }
                //Console.WriteLine($"Left {left} Right {right}");
                int area = Math.Min(blocks[left], blocks[right]) * (right - left - 1);
                for (int i = left+1; i < right; i++)
                {
                    area -= blocks[i] > 0 ? blocks[i] : 0;
                }
                //Console.WriteLine($"Area {area}");

                totalArea += area;

                //Console.WriteLine($"Total Area {totalArea}");
                leftPointer = right;
                rightPointer = blocks.Length - 1;
                right = blocks.Length-1;
            }

            return totalArea;

        }

        public static int CollectRainWaterOptimised(int[] blocks)
        {
            if (blocks.Length <= 1)
                return 0;
            int leftPtr = 0;
            int rightPtr = blocks.Length - 1;
            int maxLeft = blocks[leftPtr];
            int maxRight = blocks[rightPtr];
            int totalWater = 0;

            while(leftPtr < rightPtr)
            {
                if(blocks[leftPtr] <= blocks[rightPtr])
                {
                    if(blocks[leftPtr] < maxLeft)
                    {
                        totalWater += (maxLeft - blocks[leftPtr]);
                    }
                    else
                    {
                        maxLeft = blocks[leftPtr];
                    }
                    leftPtr++;
                }
                else
                {
                    if(blocks[rightPtr] < maxRight)
                    {
                        totalWater += (maxRight - blocks[rightPtr]);
                    }
                    else
                    {
                        maxRight = blocks[rightPtr];
                    }
                    rightPtr--;
                }
            }
            return totalWater;
        }

    }
}
