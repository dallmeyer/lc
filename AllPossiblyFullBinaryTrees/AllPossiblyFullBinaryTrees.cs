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
    static Dictionary<int, IList<TreeNode>> trees;
    
    public IList<TreeNode> AllPossibleFBT(int N) {
        trees = new Dictionary<int, IList<TreeNode>>();
     
        if (N % 2 == 0) {return new List<TreeNode>();}
        
        TreeNode root = new TreeNode();
        trees[1] = new List<TreeNode>();
        trees[1].Add(clone(root));
        
        for (int i = 3; i <= N; i += 2) {    // size of tree
            trees[i] = new List<TreeNode>();
            
            for (int j = 1; j < i-1; j += 2) {    // size of left/right subtrees
                foreach (TreeNode l in trees[j]) {
                    foreach (TreeNode r in trees[i-1-j]) {
                        root = new TreeNode();
                        root.left = clone(l);
                        root.right = clone(r);
                        trees[i].Add(root);
                    }
                }
            }
        }
        
        return trees[N];
    }
    
    private static TreeNode clone(TreeNode root) {
        if (root == null) {return null;}
        
        TreeNode t = new TreeNode(root.val, clone(root.left), clone(root.right));
        return t;
    }
}