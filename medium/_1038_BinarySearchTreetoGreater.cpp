// 1038. Binary Search Tree to Greater Sum Tree

class Solution {
public:
    void Order(TreeNode* & current, vector<TreeNode*> &sequence_stack) {
        if (current) {
            Order(current->right, sequence_stack);
            sequence_stack.push_back(current);
            Order(current->left, sequence_stack);
        }
    }

    TreeNode* bstToGst(TreeNode* root) {
        vector<TreeNode*> sequence_stack = {};
        Order(root, sequence_stack);

        for (size_t i = 0; i < sequence_stack.size() - 1; i++)
        {
            sequence_stack[i + 1]->val += sequence_stack[i + 0]->val;
        }


        return root;
    }
};
