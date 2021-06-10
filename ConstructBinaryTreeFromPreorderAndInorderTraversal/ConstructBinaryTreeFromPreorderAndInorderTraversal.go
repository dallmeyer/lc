/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func buildTree(preorder []int, inorder []int) *TreeNode {
    if len(inorder) == 0 {
        return nil
    }
    
    root := preorder[0]
    i := 0
    for ; i < len(inorder); i++ {
        if root == inorder[i] {
            break
        }
    }
    
    ans := TreeNode{Val: root}
    ans.Left = buildTree(preorder[1:i+1], inorder[:i])
    ans.Right = buildTree(preorder[i+1:], inorder[i+1:])
    
    return &ans
}