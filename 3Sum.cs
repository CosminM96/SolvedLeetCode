using System;
using System.Collections.Generic;

public class Solution 
{

    public static void HeapSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;

        int n = arr.Length;

        // Build a max-heap from the array
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Extract elements from heap one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root (maximum) to end
            Swap(arr, 0, i);

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    /// <summary>
    /// Heapifies a subtree rooted at index i
    /// n is the size of the heap
    /// </summary>
    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;        // Initialize largest as root
        int left = 2 * i + 1;   // Left child
        int right = 2 * i + 2;  // Right child

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != i)
        {
            Swap(arr, i, largest);

            // Recursively heapify the affected sub-tree
            Heapify(arr, n, largest);
        }
    }

    /// <summary>
    /// Swaps two elements in the array
    /// </summary>
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    
    public IList<IList<int>> ThreeSum(int[] nums) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        
        if (nums == null || nums.Length < 3)
            return result;
        
        HeapSort(nums); // Sort the array - crucial for skipping duplicates, HeapSort is more efficient for LeetCode checks than generic sort
        
        for (int i = 0; i < nums.Length - 2; i++) 
        {
            // Skip duplicate values for i
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            
            // Two pointers: left and right
            int left = i + 1;
            int right = nums.Length - 1;
            int target = -nums[i];
            
            while (left < right) 
            {
                int sum = nums[left] + nums[right];
                
                if (sum == target) 
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    
                    // Skip duplicates for left
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    // Skip duplicates for right
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                    
                    left++;
                    right--;
                }
                else if (sum < target) 
                {
                    left++;
                }
                else 
                {
                    right--;
                }
            }
        }
        
        return result;
    }
}
