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
    private static int max;
    
    public int MaxDepth(TreeNode root) {
        max = 0;
        
        recurse(root, 0);
        
        return max;
    }
    
    private static void recurse(TreeNode root, int d) {
        if (root == null) {
            if (max < d) {max = d;}
            return;
        }
        
        recurse(root.left, d+1);
        recurse(root.right, d+1);
    }
}