// 1465. Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts

public class Solution
{
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);

        int h_max = horizontalCuts[0];
        h_max = Math.Max(h_max, h - horizontalCuts.Last());
        for (int i = 0; i < horizontalCuts.Length - 1; ++i)
        {
            h_max = Math.Max(h_max, horizontalCuts[i + 1] - horizontalCuts[i]);
        }

        int w_max = verticalCuts[0];
        w_max = Math.Max(w_max, w - verticalCuts.Last());
        for (int i = 0; i < verticalCuts.Length - 1; ++i)
        {
            w_max = Math.Max(w_max, verticalCuts[i + 1] - verticalCuts[i]);
        }

        return (int)(((long)(h_max) * w_max) % 1000000007);
    }
}
