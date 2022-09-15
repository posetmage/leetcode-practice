// 34. Find First and Last Position of Element in Sorted Array

public class Solution
{
    int BinarySearch(int[] inputArray, int key) 
    {
        int min = 0;
        int max = inputArray.Length - 1;
        while (min <= max)
        {
            int mid = (min + max) / 2;
            if (key == inputArray[mid])
            {
                return mid;
            }
            else if (key < inputArray[mid])
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return -1;
    }
    
    public int[] SearchRange(int[] nums, int target)
    {
        int start = -1;
        int end = -1;

        var find = BinarySearch(nums, target);
        if (find > -1)
        {
            start = find;
            end = find;

            while (start > 0 && nums[start - 1] == target)
            {
                start--;
            }

            while (end < nums.Length - 1 && nums[end + 1] == target)
            {
                end++;
            }
        }

        return new int[] { start, end };
    }
}
