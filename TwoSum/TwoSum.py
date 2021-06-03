class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        n = len(nums)
        
        v = dict()
        for i in range(n):
            x = nums[i]
            need = target - x
            if need in v:
                return [i, v[need]]
            
            v[x] = i
            
        return None