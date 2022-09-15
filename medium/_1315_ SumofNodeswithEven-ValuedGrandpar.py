# 1315. Sum of Nodes with Even-Valued Grandparent

"""https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/discuss/477048/JavaC%2B%2BPython-1-Line-Recursive-Solution"""

class Solution:
    def sumEvenGrandparent(self, root: TreeNode, p=1, gp=1) -> int:
            return self.sumEvenGrandparent(root.left, root.val, p)  + self.sumEvenGrandparent(root.right, root.val, p)  + root.val * (1 - gp % 2) if root else 0
