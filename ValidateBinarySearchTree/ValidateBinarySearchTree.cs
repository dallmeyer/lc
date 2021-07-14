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
    private class Output {
        public int min;
        public int max;
        public bool isValidBst;
    }
    
    public bool IsValidBST(TreeNode root) {
        if (root == null) return true;
        
        Output x = Helper(root);
        return x.isValidBst;
    }
    
    private Output Helper(TreeNode root) {
        if (root == null || root.val == null) {
            return null;
        }
        
        Output node = new Output();
        node.min = root.val;
        node.max = root.val;
        node.isValidBst = true;
        
        Output left = Helper(root.left);
        Output right = Helper(root.right);
            
        if (left != null) {
            node.isValidBst = node.isValidBst && left.isValidBst;
            
            if (left.max >= root.val) {
                node.isValidBst = false;
            }
            
            node.min = left.min;    //if left.min >= root.val, isValidBst will already be false so no need to worry about min/max           
        }
            
        if (right != null) {
            node.isValidBst = node.isValidBst && right.isValidBst;
            
            if (right.min <= root.val) {
                node.isValidBst = false;
            }
            
            node.max = right.max;    //if right.max <= root.val, isValidBst will already be false so no need to worry about min/max           
        }
        
        return node;
    }
}