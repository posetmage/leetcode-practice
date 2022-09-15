// 98. Validate Binary Search Tree

public class Solution {
    public bool IsValidBST(TreeNode root) {
        return DFS(root, long.MinValue, long.MaxValue);
    }

    private bool DFS(TreeNode root, long min, long max) {
        if (root == null) return true;
        if (min < root.val && root.val < max) {
            var leftResult = DFS(root.left, min, root.val);
            var rightResult = DFS(root.right, root.val, max);

            if (leftResult && rightResult) {
                return true;
            }
        }

        return false;
    }
}
