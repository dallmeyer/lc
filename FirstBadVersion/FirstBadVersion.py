# The isBadVersion API is already defined for you.
# @param version, an integer
# @return an integer
# def isBadVersion(version):

class Solution:
    def firstBadVersion(self, n):
        """
        :type n: int
        :rtype: int
        """
        lo = 0
        hi = n
        
        while lo < hi:
            mid = int(lo + (hi-lo)/2)
            
            if isBadVersion(mid):
                hi = mid
            else:
                lo = mid+1
                
        return lo