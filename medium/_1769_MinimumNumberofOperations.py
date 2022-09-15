# 1769. Minimum Number of Operations to Move All Balls to Each Box    

"""https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/discuss/1075518/Clean-Python-3-two-passes-O(N)"""

"""看不懂"""

class Solution:
    def minOperations(self, boxes: str) -> List[int]:
        n = len(boxes)
        output, num_right, num_left, cnt_right, cnt_left = [0] * n, 0, 0, 0, 0
        
        for i in range(n):

            output[i] += cnt_right * i 
            output[i] -= num_right
            cnt_right += int(boxes[i])
            num_right += i * int(boxes[i])

            output[n - i - 1] += cnt_left * i
            output[n - i - 1] -= num_left
            cnt_left += int(boxes[n - i - 1])
            num_left += i * int(boxes[n - i - 1])

        return output