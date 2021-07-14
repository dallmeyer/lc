class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False
        
        counts = dict()
        for c in s:
            if c not in counts:
                counts[c] = 0
            counts[c] += 1
            
        for c in t:
            if c not in counts:
                return False
            counts[c] -= 1
            if counts[c] < 0:
                return False
            