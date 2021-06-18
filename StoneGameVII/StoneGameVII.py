class Solution:
    def stoneGameVII(self, stones: List[int]) -> int:
        n = len(stones)
        
        pre = [stones[0]]
        for i in range(1,n):
            pre.append(pre[i-1] + stones[i])
        
        dp = [[None for j in range(n)] for i in range(n)]
        
        for d in range(n):
            #print(dp)
            for i in range(n-d):
                j = i+d
                
                if i == j:
                    dp[i][j] = [0, 0]
                else:
                    # pick up stones[i], awarded sum from i+1 to j
                    left = [pre[j]-pre[i] + dp[i+1][j][1], dp[i+1][j][0]]
                    
                    # pick up stones[j], awarded sum from i to j-1
                    right = [pre[j-1] + dp[i][j-1][1], dp[i][j-1][0]]
                    if i > 0:
                        right[0] -= pre[i-1]
                    
                    if left[0]-left[1] > right[0]-right[1]:
                        dp[i][j] = left
                    else:
                        dp[i][j] = right
        
        ans = dp[0][n-1]
        return ans[0]-ans[1]