public class Solution {
    public int Candy(int[] ratings) {
        var candies = new int[ratings.Length];
        // if increasing; inc++ else inc = 0
        for (int i = 1; i < candies.Length; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {            
                candies[i] = (candies[i - 1] + 1);
            }
        }
        // inverse direction
        for (int i = candies.Length - 2; i >= 0; i--)
        {
            if (ratings[i + 1] < ratings[i])
            {
                candies[i] = Math.Max(candies[i], (candies[i + 1] + 1));
            }
        }

        return candies.Sum() + candies.Length;
    }
}
