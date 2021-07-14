class Solution:
    def findPeakElement(self, nums: List[int]) -> int:
        n = len(nums)
        
        # some base cases to get out the way
        if n == 1:
            return 0
        if n == 2:
            return 0 if nums[0] > nums[1] else 1
        
        lo = 0
        hi = len(nums)
        
        
        while hi-lo > 1:
            mid = int(lo + (hi-lo)/2)
            x = nums[mid]
            peakLeft = (mid == 0 or x > nums[mid-1])
            peakRight = (mid == n-1 or x > nums[mid+1])
            
            # true peak
            if peakLeft and peakRight:
                return mid
            
            # valley or up to the right, keep checking right
            elif not peakRight:
                lo = mid
                
            # up to the left, keep checking left
            else:
                hi = mid
                
        return int(lo + (hi-lo)/2)