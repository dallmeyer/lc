class Solution:
    def hammingDistance(self, x: int, y: int) -> int:
        ans = 0
        bit = 1
        
        for i in range(31):
            if (x ^ y) & bit > 0:
                ans += 1
            bit *= 2
            
        return ans