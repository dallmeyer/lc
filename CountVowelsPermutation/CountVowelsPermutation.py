class Solution:
    def countVowelPermutation(self, n: int) -> int:
        dp = [1 for i in range(5)]
        MOD = 1000000007
        
        for d in range(1,n):
            ndp = [0 for i in range(5)]
            
            ndp[0] = (dp[1]) % MOD
            ndp[1] = (dp[0] + dp[2]) % MOD
            ndp[2] = (dp[0] + dp[1] + dp[3] + dp[4]) % MOD
            ndp[3] = (dp[2] + dp[4]) % MOD
            ndp[4] = (dp[0]) % MOD
            
            dp = ndp
            
        ans = 0
        for x in dp:
            ans += x
            
        return ans % MOD