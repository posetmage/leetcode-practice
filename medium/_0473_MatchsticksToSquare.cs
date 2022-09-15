// 473. Matchsticks to Square

public class Solution
{    
    private bool DFS(int index, int[] sum, int side,  int[] matchsticks)
    {
        if (index == matchsticks.Length)
        {
            return true;
        }

        var element = matchsticks[index];
        for (var i = 0; i < 4; i++)
        {
            if (sum[i] + element <= side)
            {
                sum[i] += element;

                if (DFS(index + 1, sum, side, matchsticks))
                {
                    return true;
                }
                
                sum[i] -= element;
            }
        }

        return false;
    }
 
    public bool Makesquare(int[] matchsticks)
    {
        if (matchsticks.Length < 4)
        {
            return false;
        }

        var perimeter = matchsticks.Sum();
        var side = perimeter / 4;
        if (perimeter % 4 > 0)
        {
            return false;
        }

        var sum = new int[4];
        DFS(0, sum, side, matchsticks.OrderByDescending(x => x).ToArray());        
        return sum.All(x => x == side);
    }
}
