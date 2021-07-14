class Solution:
    def findLength(self, nums1: List[int], nums2: List[int]) -> int:
        m = len(nums1)
        n = len(nums2)
        
        dp = [0 for j in range(n)]
        
        ans = 0
        for i in range(m):
            dp2 = [0 for j in range(n)]
            for j in range(n):
                if nums1[i] == nums2[j]:
                    if i > 0 and j > 0:
                        dp2[j] = dp[j-1] + 1
                    else:
                        dp2[j] = 1
                    
                    if dp2[j] > ans:
                        ans = dp2[j]
            
            dp = dp2
            
        return ans