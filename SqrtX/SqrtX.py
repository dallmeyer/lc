class Solution:
    def mySqrt(self, x: int) -> int:
        lo = 0
        hi = x
        
        while lo < hi:
            mid = int(lo + (hi-lo)/2)+1
            #print(lo,mid,hi)
            
            if mid*mid <= x:
                # mid is a lower bound for our answer, lets see if theres a better larger answer
                lo = mid
            else:
                # mid is too big, throw it out
                hi = mid-1
                
        return lo