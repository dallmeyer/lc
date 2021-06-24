class NumArray:
    n = 0
    nums = []
    bit = []
    
    def __init__(self, nums: List[int]):
        self.n = len(nums)
        self.nums = [0 for i in range(self.n)]
        self.bit = [0 for i in range(self.n+1)]
        
        for i in range(self.n):
            self.update(i, nums[i])

    def update(self, index: int, val: int) -> None:
        diff = val - self.nums[index]
        self.nums[index] = val
        index += 1
        
        while 0 <= index <= self.n:
            #print(index)
            self.bit[index] += diff
            index += (index & (-index));

    def sumRange(self, left: int, right: int) -> int:
        index = right+1
        ans = 0
        
        while 0 < index <= self.n:
            ans += self.bit[index]
            index -= (index & (-index))
            
        if left > 0:
            index = left
            while 0 < index <= self.n:
                #print(index)
                ans -= self.bit[index]
                index -= (index & (-index))
        
        return ans


# Your NumArray object will be instantiated and called as such:
# obj = NumArray(nums)
# obj.update(index,val)
# param_2 = obj.sumRange(left,right)