// 120. Triangle

class Solution {
public:
    int minimumTotal(vector<vector<int>>& triangle) {
        for (size_t i = 0; i < triangle.size() - 1; i++)
        {
            auto& upper_layer = triangle[i];
            auto& this_layer = triangle[i + 1];            

            this_layer.front() += upper_layer.front();
            this_layer.back() += upper_layer.back();

            for (size_t j = 1; j < upper_layer.size(); j++)
            {
                this_layer[j] += std::min(upper_layer[j - 1], upper_layer[j]);
            }
        }
        return *std::min_element(triangle.back().begin(), triangle.back().end());
    }
};
