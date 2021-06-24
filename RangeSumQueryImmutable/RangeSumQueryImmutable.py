class NumArray:
    def __init__(self, nums: List[int]):  
        self.pre = [0 for i in range(len(nums))]
        self.pre[0] = nums[0]
        for i in range(1,len(nums)):
            self.pre[i] = self.pre[i-1] + nums[i]
            
        #print(self.pre)

    def sumRange(self, left: int, right: int) -> int:
        ans = self.pre[right]
        if left > 0:
            ans -= self.pre[left-1]
            
        return ans


# Your NumArray object will be instantiated and called as such:
# obj = NumArray(nums)
# obj.update(index,val)
# param_2 = obj.sumRange(left,right)