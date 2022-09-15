// 1647. Minimum Deletions to Make Character Frequencies Unique

public class Solution
{
    public int MinDeletions(string s)
    {
        var arr = new int[26];
        s.ToList().ForEach(c => arr[(int)(c - 'a')]++);

        arr = arr.Where(x => x > 0).OrderByDescending(c => c).ToArray();

        int sum = 0;
        int diff = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] >= arr[i - 1]) 
            {
                diff = Math.Min(arr[i] - (arr[i - 1] - 1), arr[i]);
                sum += diff;
                arr[i] -= diff;
            }

        }

        return sum;
    }
}
