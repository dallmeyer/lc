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
    public void Flatten(TreeNode root) {
        Flat(root);
        
        //while (root != null) {
        //    Console.WriteLine($"{root.val} {root.left?.val} {root.right?.val}");
        //    root = root.right;
        //}
    }
    
    // returns tail of the flattened list
    private static TreeNode Flat(TreeNode root) {
        if (root == null) {
            return null;
        }
        //Console.WriteLine($"root: {root.val}");
        
        TreeNode nxt = root;
        TreeNode l = root.left;
        TreeNode r = root.right;
        nxt.left = null;    // to be reset one level up in stack
        
        if (l != null) {
            TreeNode tmp = nxt;
            nxt = Flat(l);  // move to end of left subtree
            
            //Console.WriteLine($"left subtree {l.val} to {nxt.val}");
            tmp.right = l;  // attach left subtree to root
            //l.left = tmp;
        }
        
        if (r != null) {
            TreeNode tmp = nxt;
            nxt = Flat(r);
            
            //Console.WriteLine($"right subtree {r.val} to {nxt.val}");
            tmp.right = r;
            //r.left = tmp;
        }
        
        //Console.WriteLine($"exit root: {root.val}");
        return nxt;
    }
}