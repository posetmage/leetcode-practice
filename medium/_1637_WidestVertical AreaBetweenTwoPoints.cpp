// 1637. Widest Vertical Area Between Two Points Containing No Points

class Solution {
public:
int maxWidthOfVerticalArea(vector<vector<int>>& nums) {
    sort(nums.begin(),nums.end());
    int ans=0;
    for(int i = 0; i< nums.size() - 1; ++i)
    {
        ans = max(ans, nums[i + 1][0] - nums[i][0]);
    }
    return ans;
}
};

// std::set solution
class Solution {
public:
    int maxWidthOfVerticalArea(vector<vector<int>>& points) {
        set<int> x_pose = {};

        for (auto& point: points)
        {
            x_pose.insert(point[0]);
        }

        auto previous = *x_pose.begin();

        auto max = 0;
        for (auto& x : x_pose)
        {
            max = std::max(max, x - previous);
            previous = x;
        }


        return max;
    }
};
