public class Solution {
    public int FindKthLargest(int[] nums, int k) {          
        Array.Sort(nums);
        if (nums.Length >= k)
        {
            return nums[nums.Length - k];
        }
        return 0;
    }
}
