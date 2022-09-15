public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        if (nums == null || nums.Length == 0)
            return null;
        
        return BuildBST(nums, 0, nums.Length - 1);
    }
    
    private TreeNode BuildBST(int[] nums, int startIndex, int endIndex)
    {
        TreeNode currentRoot = null;
        int currentRootIndex = endIndex + (startIndex - endIndex) / 2;
        
        if (startIndex <= endIndex)
        {
            currentRoot = new TreeNode(nums[currentRootIndex]);
            currentRoot.left = BuildBST(nums, startIndex, currentRootIndex - 1);
            currentRoot.right = BuildBST(nums, currentRootIndex + 1, endIndex);
        }
        
        return currentRoot;
    }
}
