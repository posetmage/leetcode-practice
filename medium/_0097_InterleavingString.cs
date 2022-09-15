// 97. Interleaving String

public class Solution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }
        var dp = new bool[s1.Length + 1, s2.Length + 1];

        dp[0, 0] = true;

        for (int i = 1; i <= s1.Length; i++)
        {
            dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
        }
        for (int j = 1; j <= s2.Length; j++)
        {
            dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];
        }

            
        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                int l = i + j - 1;

                if (s2[j - 1] == s3[l])
                {
                    dp[i, j] |= dp[i, j - 1];
                }
                if (s1[i - 1] == s3[l])
                {
                    dp[i, j] |= dp[i - 1, j];
                }
            }
        }

        return dp[s1.Length, s2.Length];
    }
}
