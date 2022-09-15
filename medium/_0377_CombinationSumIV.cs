public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target + 1];
        dp[0] = 1;

        for (int i = 1; i < dp.Length; i++)
        {
            nums.ToList().ForEach(x =>
            {
                if (i - x >= 0)
                {
                    dp[i] += dp[i - x];
                }
            });
        }

        return dp[target];
    }
}
