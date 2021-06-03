class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        n = len(nums)
        
        zc = 0
        for i in range(n):
            if nums[i] == 0:
                zc += 1
            else:
                nums[i-zc] = nums[i]
                
        for i in range(n-zc,n):
            nums[i] = 0