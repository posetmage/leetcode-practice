# 1282. Group the People Given the Group Size They Belong To

"""https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/discuss/446370/Python-HashMap"""

class Solution(object):
    def groupThePeople(self, groupSizes):
        """
        :type groupSizes: List[int]
        :rtype: List[List[int]]
        """
        count = collections.defaultdict(list)
        for i, size in enumerate(groupSizes):
            count[size].append(i)
        return [l[i:i + s]for s, l in count.items() for i in xrange(0, len(l), s)]