class Solution:
    def peakIndexInMountainArray(self, arr: List[int]) -> int:
        lo = 0
        hi = len(arr)-1
        
        while lo+1 < hi:
            mid = int(lo + (hi-lo)/2)
            print(lo,mid,hi)
            
            # assuming mid should never reach 0 or len(arr)-1
            if arr[mid-1] > arr[mid]:
                # look left; ans must be mid-1 or less
                hi = mid-1
            else: # elif arr[mid-1] < arr[mid]:
                # look right; ans must be mid or greater
                lo = mid
            
        if arr[lo] < arr[hi]:
            return hi
        return lo