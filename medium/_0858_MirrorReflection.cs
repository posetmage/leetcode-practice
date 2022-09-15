// 858. Mirror Reflection

public class Solution
{
	public int MirrorReflection(int p, int q)
	{
		if (p == q)
			return 1;
		if (q == 0)
			return 0;

		bool rightSide = true;
		int sum = q;
		int overflow = 0;
		while (sum != 0)
		{
			sum += q;
			if (sum >= p)
			{
				sum %= p;
				overflow++;
			}
			rightSide = !rightSide;
		}

		if (!rightSide)
			return 2;

		return overflow % 2 == 1 ? 1 : 0;
	}
}
