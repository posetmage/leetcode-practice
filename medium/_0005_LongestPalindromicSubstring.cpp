// 5. Longest Palindromic Substring

class Solution {
public:
    void FindMaxPal(const string& s, int local_head, int local_tail, int& max_len, int& max_head, int& max_tail)
    {
        int i = 0;
        while (i < min<int>(local_head, s.size() - local_tail - 1))
        {
            if (s[local_head - (i + 1)] != s[local_tail + (i + 1)])
            {
                break;
            }
            ++i;
        }
        local_head -= i;
        local_tail += i;

        auto len = local_tail - local_head + 1;
        if (len > max_len)
        {
            max_head = local_head;
            max_tail = local_tail;
            max_len = len;
        }
    }

    string longestPalindrome(string s) {
        if (s.size() < 2)
        {
            return s;
        }

        int max_len = 1;
        int max_head = 0;
        int max_tail = 0;

        for (int i = 1; i < s.size(); ++i)
        {
            // even case
            FindMaxPal(s, i, i - 1, max_len, max_head, max_tail);
            // odd case
            FindMaxPal(s, i - 1, i - 1, max_len, max_head, max_tail);
        }

        return s.substr(max_head, max_len);
    }
};
