// 2161. Partition Array According to Given Pivot

class Solution {
public:
    vector<int> pivotArray(vector<int>& nums, int pivot) {
        vector<int> output;
        output.reserve(nums.size());

        int pivot_cnt = {};
        for (auto i: nums)
        {
            if (i < pivot) 
            {
                output.push_back(i);
            }
            else if (i == pivot)
            {
                pivot_cnt++;
            }
        }

        for (size_t i = 0; i < pivot_cnt; i++)
        {
            output.push_back(pivot);
        }

        for (auto i : nums)
        {
            if (i > pivot)
            {
                output.push_back(i);
            }
        }

        return output;
    }
};
