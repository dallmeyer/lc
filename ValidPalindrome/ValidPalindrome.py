class Solution:
    def isPalindrome(self, s: str) -> bool:
        i = 0
        j = len(s)-1
        
        while i < j:
            ci = s[i].lower()
            if not ('a' <= ci <= 'z' or '0' <= ci <= '9'):
                i += 1
                continue
            
            cj = s[j].lower()
            if not ('a' <= cj <= 'z' or '0' <= cj <= '9'):
                j -= 1
                continue
                
            if ci != cj:
                return False
            else:
                i += 1
                j -= 1
                
        return True