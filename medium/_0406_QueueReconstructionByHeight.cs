public class Solution
{
    public int[][] ReconstructQueue(int[][] people)
    {
        var res = new List<int[]>();
        people
            .OrderByDescending(x => x[0]).ThenBy(x => x[1])
            .ToList().ForEach(p => res.Insert(p[1], p));
        
        return res.ToArray();
    }
}
