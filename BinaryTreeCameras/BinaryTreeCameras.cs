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
    public int idx;
    //public Dictionary<TreeNode, int> lookup;
    public Dictionary<Tuple<TreeNode, bool, bool>, int> memo;
    
    public int MinCameraCover(TreeNode root) {
        idx = 0;
        //lookup = new Dictionary<TreeNode, int>();
        //assignPreOrder(root);
        memo = new Dictionary<Tuple<TreeNode, bool, bool>, int>();
        int a = helper(root, true, true);//, "");
        int b = helper(root, false, false);//, "");
        
        if (a != -1) {
            if (b != -1) {
                return (a < b) ? a : b;
            } else {
                return a;
            }
        } else {
            return b;
        }
    }
   
    /*
    public void assignPreOrder(TreeNode root) {
        if (root == null) {return;}
        lookup.Add(root, idx++);
        assignPreOrder(root.left);
        assignPreOrder(root.right);
    }
    */
    
    public int helper(TreeNode root, bool camOnRoot, bool rootMonitored) {//, string indent) {
        if (root == null) {
            //Console.WriteLine(indent + "null root, returning " + (camOnRoot ? -1 : 0));
            return camOnRoot ? -1 : 0;
        }
        
        Tuple<TreeNode,bool,bool> tup = new Tuple<TreeNode,bool,bool>(root, camOnRoot, rootMonitored);
        if (memo.ContainsKey(tup)) { return memo[tup]; }
        
        //Console.WriteLine(indent + lookup[root] + " " + camOnRoot + " " + rootMonitored);
        
        int count = 0;
        
        if (camOnRoot) {
            count++;
        }  
        
        if (rootMonitored) {
            if (root.left != null) {
                int leftCamOn = helper(root.left, true, true); //, indent+" ");
                int leftCamOff = helper(root.left, false, camOnRoot); //, indent+" ");
                //Console.WriteLine(indent + "left " + leftCamOn + " " + leftCamOff);
                if (leftCamOn != -1) {
                    if (leftCamOff != -1) {
                        count += (leftCamOn < leftCamOff) ? leftCamOn : leftCamOff;
                    } else {
                        count += leftCamOn;
                    }
                } else {
                    if (leftCamOff != -1) {
                        count += leftCamOff;
                    } else {
                        return -1;  // cannot proceed?
                    }
                }
            }
            
            if (root.right != null) {
                int rightCamOn = helper(root.right, true, true); //, indent+" ");
                int rightCamOff = helper(root.right, false, camOnRoot); //, indent+" ");
                //Console.WriteLine(indent + "right " + rightCamOn + " " + rightCamOff);
                if (rightCamOn != -1) {
                    if (rightCamOff != -1) {
                        count += (rightCamOn < rightCamOff) ? rightCamOn : rightCamOff;
                    } else {
                        count += rightCamOn;
                    }
                } else {
                    if (rightCamOff != -1) {
                        count += rightCamOff;
                    } else {
                        return -1;  // cannot proceed?
                    }
                }
            }
            
            memo.Add(tup, count);
            //Console.WriteLine(indent + lookup[root] + " " + camOnRoot + " " + rootMonitored + " returning " + count);
            return count;
        } else {
            // must ensure at least 1 child has camera
            int min = -1;
        
            if (root.left != null && root.right != null) {                
                // at least one w/ camera
                int leftCamOn = helper(root.left, true, true); //, indent+" ");
                int leftCamOff = helper(root.left, false, camOnRoot); //, indent+" ");
                int rightCamOn = helper(root.right, true, true); //, indent+" ");
                int rightCamOff = helper(root.right, false, camOnRoot); //, indent+" ");
                //Console.WriteLine(indent + "left " + leftCamOn + " " + leftCamOff + ", right " + rightCamOn + " " + rightCamOff);
                
                int temp;
                if (leftCamOn != -1) {
                    if (rightCamOn != -1) {
                        // both cams on
                        temp = leftCamOn + rightCamOn;
                        if (min == -1 || temp < min) {min = temp;}
                    }
                    if (rightCamOff != -1) {
                        // left on, right off
                        temp = leftCamOn + rightCamOff;
                        if (min == -1 || temp < min) {min = temp;}
                    }
                }
                if (rightCamOn != -1 && leftCamOff != -1) {
                    // right on, left off
                    temp = leftCamOff + rightCamOn;
                    if (min == -1 || temp < min) {min = temp;}
                }
            } else if (root.left != null) {
                //right is null
                min = helper(root.left, true, true); //, indent+" ");
            } else if (root.right != null) {
                //left is null
                min = helper(root.right, true, true); //, indent+" ");
            } 
        
            //Console.WriteLine(indent + lookup[root] + " " + camOnRoot + " " + rootMonitored + " returning " + min);
            memo.Add(tup, min);
            return min;
        }
    }
}