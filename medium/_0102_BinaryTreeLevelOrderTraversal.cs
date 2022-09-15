// 102. Binary Tree Level Order Traversal

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var levelMap = new Dictionary<int, List<int>>();
        GetTreeLevels(root, 1, levelMap);
        return levelMap.Select(x => x.Value).Cast<IList<int>>().ToList();
    }
    
    private void GetTreeLevels(TreeNode root, int level, Dictionary<int, List<int>> levelMap)
    {
        if(root == null) 
        {
            return;
        }
        
        if(levelMap.ContainsKey(level)) 
        {
            levelMap[level].Add(root.val);
        }
        else 
        {
            levelMap.Add(level, new List<int>(){ root.val });
        }
        GetTreeLevels(root.left, level + 1, levelMap);
        GetTreeLevels(root.right, level + 1, levelMap);
        
        return;
    }
}
