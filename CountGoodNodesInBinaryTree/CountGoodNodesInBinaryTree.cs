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
    private static int count;
    public int GoodNodes(TreeNode root) {
        count = 0;
        re(root, Int32.MinValue);
        return count;
    }
    
    private static void re(TreeNode root, int max) {
        if (root == null) {return;}
        
        if (root.val >= max) {
            max = root.val;
            count++;
        }
        
        re(root.left, max);
        re(root.right, max);
    }
}