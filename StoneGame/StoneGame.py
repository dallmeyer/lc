class Solution:
    def stoneGame(self, piles: List[int]) -> bool: 
		# return true
	
        n = len(piles)
        dp = [[None for j in range(n)] for i in range(n)]
        
        for d in range(n):
            #print(dp)
            for i in range(n-d):
                j = i+d
                
                if i == j:
                    dp[i][j] = [piles[i], 0]
                else:
                    left = piles[i] + dp[i+1][j][1]
                    right = piles[j] + dp[i][j-1][1]
                    
                    if left > right:
                        dp[i][j] = [left, dp[i+1][j][0]]
                    else:
                        dp[i][j] = [right, dp[i][j-1][0]]
        
        ans = dp[0][n-1]
        return ans[0] > ans[1]