// 128. Longest Consecutive Sequence

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var hash = new HashSet<int>();

        nums.ToList().ForEach(x => hash.Add(x));

        nums = hash.ToArray();

        int sequence = 0;
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // with 1st element of longest subsequence
            if (!hash.Contains(nums[i] - 1))
            {
                sequence = nums[i];
                // sequence will reach to last element of longest subsequence
                while (hash.Contains(sequence)) 
                {
                    sequence++; 
                }

                result = Math.Max(result, sequence - nums[i]);
            }
        }

        return result;
    }
}
