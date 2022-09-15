// 807. Max Increase to Keep City Skyline

class Solution {
public:
    int maxIncreaseKeepingSkyline(vector<vector<int>>& grid) {
        auto n = grid.size();
		vector<int> viewed_top(n);
		vector<int> viewed_left(n);
		
		for (size_t i = 0; i < n; i++)
		{
			for (size_t j = 0; j < n; j++)
			{
				viewed_top[i] = max(viewed_top[i], grid[i][j]);
				viewed_left[j] = max(viewed_left[j], grid[i][j]);
			}
		}

		int output = {};
		for (size_t i = 0; i < n; i++)
		{
			for (size_t j = 0; j < n; j++)
			{
				output += min(viewed_top[i], viewed_left[j]) - grid[i][j];
			}
		}

		return output;
    }
};