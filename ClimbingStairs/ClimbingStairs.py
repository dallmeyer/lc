class Solution:
    def climbStairs(self, n: int) -> int:
        if n == 0 or n == 1:
            return 1
        
        a = 1
        b = 1
        i = 1
        while i != n:
            c = a+b
            a = b
            b = c
            i += 1
        
        return b