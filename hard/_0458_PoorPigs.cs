public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
        return (int)Math.Ceiling(Math.Log(buckets, minutesToTest / minutesToDie + 1));

    }
}
