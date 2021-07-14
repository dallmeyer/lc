# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isSymmetric(self, root: TreeNode) -> bool:        
        if root is None:
            return True
        
        lq = [root.left]
        rq = [root.right]
        
        while len(lq) > 0:
            l = lq.pop(0)
            r = rq.pop(0)
            
            if l is None and r is None:
                continue
            
            if l is None or r is None:
                return False
            
            if l.val != r.val:
                return False
            
            lq.append(l.left)
            lq.append(l.right)
            
            rq.append(r.right)
            rq.append(r.left)
            
        return True