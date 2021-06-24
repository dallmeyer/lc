class Solution:
    def numMatchingSubseq(self, s: str, words: List[str]) -> int:
        occur = [[] for i in range(26)]
        
        for i in range(len(s)):
            occur[ord(s[i])-ord('a')].append(i)
            
        ans = 0
        for w in words:
            i = 0
            nextOccur = [0 for j in range(26)]
            match = True
            
            for c in w:
                cIdx = ord(c)-ord('a')
                
                while True:
                    if nextOccur[cIdx] < len(occur[cIdx]):
                        if occur[cIdx][nextOccur[cIdx]] >= i:
                            #print("Using idx ", occur[cIdx][nextOccur[cIdx]], " in s for character ", c, " in ", w)
                            i = occur[cIdx][nextOccur[cIdx]]
                            nextOccur[cIdx] += 1
                            break
                        else:
                            nextOccur[cIdx] += 1
                    else:   # no more occurrences of cIdx that come at i or later
                        match = False
                        break
                        
                        
            if match:
                #print(w, "matches")
                ans += 1
            #else:
                #print(w, "doesnt match")
        
        
        return ans