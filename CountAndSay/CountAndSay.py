class Solution:
    def countAndSay(self, n: int) -> str:
        if n == 1:
            return "1"
        
        prev = self.countAndSay(n-1)
        
        ans = ""
        digit = prev[0]
        count = 1
        for i in range(1,len(prev)):
            if prev[i] == digit:
                count += 1
            else:
                ans += str(count)
                ans += str(digit)
                digit = prev[i]
                count = 1
        
        ans += str(count)
        ans += str(digit)
        
        return ans