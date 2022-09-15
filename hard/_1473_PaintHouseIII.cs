// 1473. Paint House III

public class Solution
{    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        // Last Color, neighborhoods, Cost 
        Dictionary<int, Dictionary<int, int>> crnt = new Dictionary<int, Dictionary<int, int>>();
        Dictionary<int, Dictionary<int, int>> prev = new Dictionary<int, Dictionary<int, int>>();
        Dictionary<int, Dictionary<int, int>> temp;

        if (houses[houses.Length - 1] == 0)
        {
            for (int c = 1; c <= n; c++)
            {
                prev[c] = new Dictionary<int, int>();
                prev[c][1] = cost[houses.Length - 1][c - 1];
            }
        }
        else
        {
            prev[houses[houses.Length - 1]] = new Dictionary<int, int>();
            prev[houses[houses.Length - 1]][1] = 0;
        }

        for (int i = houses.Length - 2; i >= 0; i--)
        {
            if (houses[i] == 0)
            {
                for (int c = 1; c <= n; c++)
                {
                    crnt[c] = new Dictionary<int, int>();
                    ProcessColor(prev, crnt[c], c, cost[i][c - 1], target);
                }
            }
            else
            {
                crnt[houses[i]] = new Dictionary<int, int>();
                ProcessColor(prev, crnt[houses[i]], houses[i], 0, target);
            }

            temp = prev;
            prev = crnt;
            crnt = temp;
            crnt.Clear();
        }

        int min = int.MaxValue;

        foreach (int key in prev.Keys)
        {
            if (prev[key].ContainsKey(target) && prev[key][target] < min)
            {
                min = prev[key][target];
            }
        }
        return (min == int.MaxValue) ? -1 : min;
    }

    private void ProcessColor(
        Dictionary<int, Dictionary<int, int>> prev,                              
        Dictionary<int, int> crnt, 
        int color, int cost, int target)
    {
        int toAdd = 0;

        foreach (int pColor in prev.Keys)
        {
            toAdd = (pColor == color) ? 0 : 1;

            foreach (int neighborhoods in prev[pColor].Keys)
            {
                if (neighborhoods + toAdd > target) { continue; }

                if (crnt.ContainsKey(neighborhoods + toAdd))
                {
                    if (crnt[neighborhoods + toAdd] > prev[pColor][neighborhoods] + cost)
                    {
                        crnt[neighborhoods + toAdd] = prev[pColor][neighborhoods] + cost;
                    }
                }
                else
                {
                    crnt[neighborhoods + toAdd] = prev[pColor][neighborhoods] + cost;
                }

            }
        }
    }
}
