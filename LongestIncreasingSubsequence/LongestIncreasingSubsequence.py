class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        n = len(nums)
        dp = [nums[0]]
        
        for i in range(1,n):
            for j in range(len(dp)):
                if nums[i] < dp[j] and (j == 0 or nums[i] > dp[j-1]):
                    dp[j] = nums[i]
                    break
            if nums[i] > dp[len(dp)-1]:
                    dp.append(nums[i])
                    
            #print(dp)
            
        return len(dp)