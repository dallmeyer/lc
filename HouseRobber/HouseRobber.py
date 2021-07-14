class Solution:
    def rob(self, nums: List[int]) -> int:
        r = nums[0]
        d = 0
        
        for i in range(1,len(nums)):
            x = nums[i]
            tmp = d+x
            d = max(r,d)
            r = tmp
            
        return max(r,d)