class Solution:
    def hammingWeight(self, n: int) -> int:
        ans = 0
        bit = 1
        
        for i in range(32):
            if n & bit > 0:
                ans += 1
            bit *= 2
            
        return ans