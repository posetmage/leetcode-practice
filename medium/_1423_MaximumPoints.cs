// 1423. Maximum Points You Can Obtain from Cards

public class Solution
{    
    public int MaxScore(int[] cardPoints, int k)
    {
        int sum = cardPoints.Take(k).Sum();
        int max = sum;
        for (int i = 0; i < k; ++i) 
        {
            sum -= cardPoints[k - 1 - i];
            sum += cardPoints[cardPoints.Length - i - 1];

            max = Math.Max(sum, max);
        }

        return max;
    }
}
