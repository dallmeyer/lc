# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution:
    def lowestCommonAncestor(self, root: 'TreeNode', p: 'TreeNode', q: 'TreeNode') -> 'TreeNode':
        self.parDict = dict()
        pd = self.getDepth(root, p)
        qd = self.getDepth(root, q)
        
        while qd > pd:
            q = self.parDict[q]
            qd -= 1
        
        while pd > qd:
            p = self.parDict[p]
            pd -= 1
            
        while p != q:
            p = self.parDict[p]
            q = self.parDict[q]
            
        return p
        
        
    def getDepth(self, cur: 'TreeNode', x: 'TreeNode') -> int:
        if cur is None:
            return -1
        
        if cur == x:
            return 0
        
        if cur.left is not None:
            self.parDict[cur.left] = cur
            d = self.getDepth(cur.left, x)
            if d > -1:
                return d+1
        
        if cur.right is not None:
            self.parDict[cur.right] = cur
            d = self.getDepth(cur.right, x)
            if d > -1:
                return d+1
            
        return -1