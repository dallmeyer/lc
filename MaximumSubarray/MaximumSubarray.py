class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        prev = nums[0]
        best = prev
        for i in range(1,len(nums)):
            x = nums[i]
            if prev <= 0:
                prev = x
            else:
                prev += x
                
            if best < prev:
                best = prev
        
        return best