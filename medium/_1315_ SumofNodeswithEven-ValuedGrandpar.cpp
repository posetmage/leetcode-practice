// 1315. Sum of Nodes with Even-Valued GrandparentSolution

class Solution 
{
public:
	int sumEvenGrandparent(TreeNode* root, int parent_val = 1, int grand_parent_val = 1) 
	{
		int sum = 0;
		if (root)
		{
			if (grand_parent_val % 2 == 0)
			{
				sum += root->val;
			}

			sum += sumEvenGrandparent(root->left, root->val, parent_val);
			sum += sumEvenGrandparent(root->right, root->val, parent_val);
		}			
		return sum;
	}
};