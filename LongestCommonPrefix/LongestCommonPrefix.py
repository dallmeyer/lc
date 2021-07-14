class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        ans = ""
        for i in range(len(strs[0])):
            c = strs[0][i]
            for j in range(1,len(strs)):
                if i >= len(strs[j]) or c != strs[j][i]:
                    return ans
            
            ans += c
                
        return ans