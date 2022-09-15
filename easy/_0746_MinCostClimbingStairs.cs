// 746. Min Cost Climbing Stairs

public class Solution {
    public int MinCostClimbingStairs(int[] cost) {        
        int[] dp = new int[cost.Length + 1];
        dp[0] = cost[0];
        dp[1] = cost[1];
        
        for(int i = 2; i < cost.Length; i++)
        {
            dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
        }
        
        return Math.Min(dp[cost.Length - 2], dp[cost.Length - 1]);
    }
}
