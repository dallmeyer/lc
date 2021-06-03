class Solution:
    def rotate(self, nums: List[int], k: int) -> None:
        """
        Do not return anything, modify nums in-place instead
        """
        n = len(nums)
        v = [False for i in range(n)]
        
        for i in range(n):
            if v[i] == False:
                j = i
                nxt = nums[i]

                while v[j] == False:
                    x = (j + k) % n
                    tmp = nums[x]
                    
                    nums[x] = nxt
                    nxt = tmp
                    v[j] = True
                    j = x