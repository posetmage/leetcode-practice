# 807. Max Increase to Keep City Skyline

"""https://leetcode.com/problems/max-increase-to-keep-city-skyline/discuss/120681/C%2B%2BJavaPython-Easy-and-Concise-Solution"""

class Solution(object):
    def maxIncreaseKeepingSkyline(self, grid):
        """
        :type grid: List[List[int]]
        :rtype: int
        """
        row, col = map(max, grid), map(max, zip(*grid))
        return sum(min(i, j) for i in row for j in col) - sum(map(sum, grid))