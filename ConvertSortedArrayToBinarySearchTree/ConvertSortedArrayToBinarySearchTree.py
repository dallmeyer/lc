# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def sortedArrayToBST(self, nums: List[int]) -> TreeNode:
        return self.helper(nums, 0, len(nums))
        
    def helper(self, nums: List[int], lo: int, hi: int) -> TreeNode:
        if lo >= hi:
            return None
        
        mid = int(lo + (hi-lo)/2)
        left = self.helper(nums, lo, mid)
        right = self.helper(nums, mid+1, hi)
        return TreeNode(nums[mid], left, right)