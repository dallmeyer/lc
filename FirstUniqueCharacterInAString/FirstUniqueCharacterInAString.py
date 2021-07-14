class Solution:
    def firstUniqChar(self, s: str) -> int:
        last = [-2 for i in range(26)]
        
        for i in range(len(s)):
            cIdx = ord(s[i]) - ord('a')
            
            if last[cIdx] == -2:
                last[cIdx] = i
            elif last[cIdx] == -1:
                continue
            else:
                last[cIdx] = -1
        
        ans = -1
        for idx in last:
            if idx < 0:
                continue
            
            if ans == -1 or ans > idx:
                ans = idx
        
        return ans