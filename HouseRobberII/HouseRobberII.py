class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 1:
            return nums[0]
        
        # first assume you rob the first house (and cannot rob the last house)
        r = nums[0]
        d = None
        
        for i in range(1,len(nums)):
            #print(r,d,i)
            x = nums[i]
            if d is None:
                d = r
                r = None
            else: #d is not None
                if r is None:
                    r = d + x
                    d = d
                else: #r is not None
                    tmp = d + x
                    d = max(d,r)
                    r = tmp
            
            #print(r,d,i)
                    
        ans = d
        
        # now assume you DONT rob the first hosue (so can do whatever with last house)
        r = 0
        d = 0
        
        for i in range(1,len(nums)):
            x = nums[i]
            tmp = d + x
            d = max(d,r)
            r = tmp
            
        ans = max(ans,max(d,r))
        
        return ans