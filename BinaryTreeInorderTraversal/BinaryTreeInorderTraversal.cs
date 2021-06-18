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
    private static IList<int> ans;
    
    public IList<int> InorderTraversal(TreeNode root) {
        ans = new List<int>();
        
        recurse(root);
        
        return ans;
    }
    
    private static void recurse(TreeNode root) {
        if (root == null) {return;}
        
        recurse(root.left);
        ans.Add(root.val);
        recurse(root.right);
    }
}