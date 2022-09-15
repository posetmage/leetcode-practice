// 654. Maximum Binary Tree

class Solution {
public:
    void CreateTreeRecursive(TreeNode** root,
        vector<int>::iterator iter_begin,
        vector<int>::iterator iter_end)
    {
        if (iter_begin == iter_end)
        {
            return;
        }
        *root = new TreeNode();
        auto iter_max = std::max_element(iter_begin, iter_end);
        (*root)->val = *iter_max;

        CreateTreeRecursive(&((*root)->left), iter_begin, iter_max);
        CreateTreeRecursive(&((*root)->right), iter_max + 1, iter_end);
    }

    TreeNode* constructMaximumBinaryTree(vector<int>& nums)
    {
        TreeNode* root = {};
        CreateTreeRecursive(&root, nums.begin(), nums.end());
        return root;
    }
};
