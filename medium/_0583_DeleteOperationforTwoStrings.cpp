// 583. Delete Operation for Two Strings

// Speed up, reduce memory 
class Solution {
public:
    int minDistance(string word1, string word2) {
        int out = word1.size() + word2.size();

        word1 = 'y' + word1;
        word2 = 'x' + word2;
        vector<int> buffer1(word2.size());
        vector<int> buffer2(word2.size());        
        int* last_layer = buffer1.data();
        int* this_layer = buffer2.data();
        
        for (size_t i = 1; i < word1.size(); i++)
        {
            for (size_t j = 1; j < word2.size(); j++)
            {
                if (word1[i] == word2[j]) 
                {
                    this_layer[j] = last_layer[j - 1] + 1;
                }
                else
                {
                    this_layer[j] = max(last_layer[j], this_layer[j - 1]);
                }
            }

            auto temp = this_layer;
            this_layer = last_layer;
            last_layer = temp;

        }

        auto res = last_layer[word2.size() - 1];

        return out - 2 * res;
    }
};

// Origin version
class Solution {
public:
    int minDistance(string word1, string word2) {

        int out = word1.size() + word2.size();
        vector<vector<int>> table;

        word1 = 'y' + word1;
        word2 = 'x' + word2;

        table.resize(word1.size());
        for (auto &t :table)
        {
            t.resize(word2.size());
        }
        
        for (size_t i = 1; i < word1.size(); i++)
        {
            for (size_t j = 1; j < word2.size(); j++)
            {
                if (word1[i] == word2[j]) 
                {
                    table[i][j] = table[i - 1][j - 1] + 1;
                }
                else
                {
                    table[i][j] = max(table[i - 1][j], table[i][j - 1]);
                }
            }
        }

        return out - 2 * table.back().back();
    }
};
