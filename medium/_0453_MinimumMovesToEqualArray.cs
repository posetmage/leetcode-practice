// 453. Minimum Moves to Equal Array Elements

// The operator equals to minus one number at one time
// That means it take nums.Sum() times to decreasing all number to 0
// We do not need to decreasing to zero, just to nums.Min()
// That means all numbers stop at nums.Min()
// Thus, the total step reduce nums.Length * nums.Min() times

public class Solution
{
    public int MinMoves(int[] nums)
    {
        return nums.Sum() - nums.Min() * nums.Length;
    }
}
