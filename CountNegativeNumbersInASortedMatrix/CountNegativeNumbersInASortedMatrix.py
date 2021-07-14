class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        m = len(grid)
        n = len(grid[0])
        
        r = m-1
        c = 0
        
        ans = 0
        while c < n:
            while r >= 0 and grid[r][c] < 0:
                r -= 1
                
            ans += (m-r-1)
            c += 1
            
        return ans