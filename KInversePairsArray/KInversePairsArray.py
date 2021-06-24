class Solution:
    def kInversePairs(self, n: int, k: int) -> int:
        ans = [1]
        for i in range(2,n+1):
            prev = ans
            ans = []
            
            w = []
            wSum = 0
            for j in range(k+1):
                val = prev[j] if j < len(prev) else 0
                
                w.append(val)
                wSum += val
                
                if len(w) > i:
                    wSum -= w.pop(0)
                    
                ans.append(wSum)
        
        return (ans[k]%1000000007) if k < len(ans) else 0
                