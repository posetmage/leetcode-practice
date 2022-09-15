// 1769. Minimum Number of Operations to Move All Balls to Each Box    

// https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/discuss/1075669/C%2B%2B-O(N)-keep-track-of-of-balls-to-the-right-and-left

class Solution {
public:
    vector<int> minOperations(string boxes) {
        int N = boxes.size();  
        vector<int> output(N);        
                
        int sum = 0;
        int right = 0;
        int left = 0;
        for (int i = 0; i < N; ++i) 
        {
            if (boxes[i] == '1') 
            {
                sum += i;
                ++right;
            }
        }
        
        for (int i = 0; i < N; ++i) 
        {
            output[i] = sum;
            if (boxes[i] == '1') 
            {
                --right;
                    ++left;
            }
            sum += left - right;
        }
        return output;
    }
};