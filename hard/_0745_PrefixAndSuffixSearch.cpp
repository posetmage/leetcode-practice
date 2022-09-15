// 745. Prefix and Suffix Search

class Trie {
public:
    /** Initialize your data structure here. */
    Trie() : root_(new TrieNode()) {}

    /** Inserts a word into the trie. */
    void insert(const string& word, int index) {
        TrieNode* p = root_.get();
        for (const char c : word) {
            if (!p->children[c - 'a'])
            {
                p->children[c - 'a'] = make_shared<TrieNode>();
            }
            p = p->children[c - 'a'].get();
            // Update index
            p->index = index;
        }
        p->is_word = true;
    }


    /** Returns the index of word that has the prefix. */
    int startsWith(const string& prefix) const {
        const TrieNode* p = root_.get();
        for (const char c : prefix) {
            p = p->children[c - 'a'].get();
            if (p == nullptr) break;
        }

        if (!p)
        {
            return -1;
        }
        return p->index;
    }
private:
    struct TrieNode {
        // we allocate a~z and one more for `{`
        TrieNode() :index(-1), is_word(false), children(27, nullptr) {}

        ~TrieNode() {}

        int index = {};
        int is_word = {};
        vector<shared_ptr<TrieNode>> children;
    };

    std::unique_ptr<TrieNode> root_;
};

class WordFilter {
public:
    // ascii 97 is a, 122 is z, 123 is `{`
    // others others are far away, and will out of array range

    WordFilter(vector<string>& words) {
        for (int i = 0; i < words.size(); ++i) {
            const string& w = words[i];
            string key = "{" + w;
            trie_.insert(key, i);
            for (int j = 0; j < w.size(); ++j) {
                key = w[w.size() - j - 1] + key;
                trie_.insert(key, i);
            }
        }
    }

    int f(string prefix, string suffix) {
        return trie_.startsWith(suffix + "{" + prefix);
    }
private:
    Trie trie_;
};
