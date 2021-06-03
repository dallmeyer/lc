class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        n = len(digits)
        ans = digits[:]
        
        extra = True
        for i in reversed(range(n)):
            ans[i] += 1
            if ans[i] == 10:
                ans[i] = 0
            else:
                extra = False
                break
        
        if extra == True:
            ans.insert(0, 1)
        
        return ans