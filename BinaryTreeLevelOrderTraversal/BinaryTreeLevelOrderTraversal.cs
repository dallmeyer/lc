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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> ans = new List<IList<int>>();
        
        Queue<TreeNode> cur = new Queue<TreeNode>();
        cur.Enqueue(root);
        while (cur.Any()) {
            Queue<TreeNode> nxt = new Queue<TreeNode>();
            
            IList<int> lvl = new List<int>();
            
            while (cur.Any()) {
                TreeNode t = cur.Dequeue();
                if (t == null) {continue;}
                
                lvl.Add(t.val);
                nxt.Enqueue(t.left);
                nxt.Enqueue(t.right);
            }
            
            if (lvl.Any()) {
                ans.Add(lvl);
            }
            cur = nxt;
        }
        
        return ans;
    }
}