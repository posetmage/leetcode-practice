// 968. Binary Tree Cameras

class Solution {
public:
    struct Node
    {
        enum NODETYPE
        {
            EMPTY,
            ORPHAN,
            MONITORED,
            CAMERA
        };
        int sum = {};
        NODETYPE type = {};
    };

    Node DFS(TreeNode* root) {
        Node output = {};
        if (root)
        {
            auto node_l = DFS(root->left);
            auto node_r = DFS(root->right);
            auto type_l = node_l.type;
            auto type_r = node_r.type;            

            if (type_l == Node::ORPHAN || type_r == Node::ORPHAN)
            {
                // if at least 1 child is not monitored, 
                // we need to place a camera at current node 
                output.type = Node::CAMERA;
                output.sum = 1;
            }
            else if (type_l == Node::CAMERA || type_r == Node::CAMERA)
            {
                // if at least 1 child has camera, the current node is monitored.
                // Thus, we don't need to place a camera here 
                output.type = Node::MONITORED;
            }
            else
            {
                // if both children are monitored but have no camera, 
                // we don't need to place a camera here. 
                // We place the camera at its parent node at the higher level. 
                output.type = Node::ORPHAN;
            }                      
            output.sum += node_l.sum;
            output.sum += node_r.sum;
        }
        return output;
    }

    int minCameraCover(TreeNode* root) {
        TreeNode fake_root = {};
        fake_root.left = root;        
        return DFS(&fake_root).sum;
    }
};
