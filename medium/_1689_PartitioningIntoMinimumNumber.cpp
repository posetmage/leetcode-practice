// 1689. Partitioning Into Minimum Number Of Deci-Binary Numbers

class Solution {
public:
    int minPartitions(string n) {
        return *max_element(std::begin(n), std::end(n)) - '0'; 
    }
};