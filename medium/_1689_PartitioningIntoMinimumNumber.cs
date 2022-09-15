// 1689. Partitioning Into Minimum Number Of Deci-Binary Numbers

public class Solution
{
    public int MinPartitions(string n)
    {
        return (int)(n.ToCharArray().Max() - '0');
    }
}
