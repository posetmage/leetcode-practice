// 1282. Group the People Given the Group Size They Belong To


class Solution {
public:
    vector<vector<int>> groupThePeople(vector<int>& groupSizes) {
		auto max = *max_element(std::begin(groupSizes), std::end(groupSizes));
		vector<vector<int>> collects(max);
		for (int i = 0; i < groupSizes.size(); ++i)
		{
			collects[groupSizes[i] - 1].push_back(i);
		}
		
		vector<vector<int>> output;
		for (auto & collect : collects)
		{
			if (collect.size())
			{
				auto num = groupSizes[collect[0]];
				for (size_t i = 0; i < collect.size() / num; i++)
				{
					output.push_back(vector<int>(collect.begin() + i, collect.begin() + i + num));
				}
			}
		}

		return output;    
    }
};