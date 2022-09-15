// 2315. Count Asterisks

public class Solution
{
    public int CountAsterisks(string s)
    {
        bool counting = true;
        int sum = 0;
        foreach(char c in s)
        {
            if(counting && c == '*')
            {
                ++sum;
            }
            if (c == '|') 
            {
                counting = !counting;
            }
        }

        return sum;
    }
}
