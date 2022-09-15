public class Solution
{
    public bool CheckPossibility(int[] nums)
    {
        bool isOneElementChanged = false;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                if (isOneElementChanged)
                {
                    return false;
                }

                if (i > 0 && nums[i + 1] < nums[i - 1])
                {
                    nums[i + 1] = nums[i];
                }
                else
                {
                    nums[i] = nums[i + 1];
                }

                isOneElementChanged = true;
            }
        }
        return true;
    }
}
