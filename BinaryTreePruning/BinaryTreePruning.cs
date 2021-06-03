/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode PruneTree(TreeNode root) {
        bool has1 = false;
        if (root.val == 1) {
            has1 = true;
        }
        
        if (root.left != null) {
            root.left = PruneTree(root.left);
            if (root.left != null) {
                has1 = true;
            }
        }
        
        if (root.right != null) {
            root.right = PruneTree(root.right);
            if (root.right != null) {
                has1 = true;
            }
        }
        
        if (has1) {
            return root;
        } else {
            return null;
        }
    }
}