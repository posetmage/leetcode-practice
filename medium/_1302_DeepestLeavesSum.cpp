// 1302. Deepest Leaves Sum

class Solution {
public:
int deepestLeavesSum(TreeNode* root) {
  
        // better meaning: queue
        // pre-allocate memory, for speed
        deque<TreeNode*> pre_layer(25);
        deque<TreeNode*> this_layer(25);
        
        // real initialize
        pre_layer.resize(0);
        this_layer.resize(1);
        this_layer[0] = root;
        
        while (!this_layer.empty())
        {
            std::swap(pre_layer, this_layer);
            this_layer.resize(0);
            for (auto& node : pre_layer)
            {
                if (node->left)
                {
                    this_layer.push_back(node->left);
                }
                if (node->right)
                {
                    this_layer.push_back(node->right);
                }
            }
        }


        auto res = accumulate(
            pre_layer.begin(), pre_layer.end(), 0,
            [](int sum, TreeNode* node)
            {
                return sum + node->val;
            });
        return res;
    }
};
