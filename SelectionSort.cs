﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class SelectionSort
    {
        /// <summary>
        /// Constructor which immediately sorts selected array.
        /// </summary>
        /// <param name="arr"></param>
        public SelectionSort(int[] arr)
        {
            Sort(arr);
        }
        public SelectionSort() { }

        public int[] Sort(int[] arr)
        {
            int[] ans = new int[arr.Length];
            arr.CopyTo(ans, 0);
            int n = arr.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (ans[j] < ans[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = ans[min_idx];
                ans[min_idx] = ans[i];
                ans[i] = temp;
            }
            return ans;
        }
    }
}
