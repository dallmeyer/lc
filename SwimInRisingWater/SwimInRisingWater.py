class Solution:
    def swimInWater(self, grid: List[List[int]]) -> int:
        rDelta = [-1, 1, 0, 0]
        cDelta = [0, 0, -1, 1]
        
        N = len(grid)
        best = [[N*N*N for j in range(N)] for i in range(N)]
        best[0][0] = grid[0][0]
        
        q = [[0, 0]]
        
        while len(q) > 0:
            cur = q.pop()
            r = cur[0]
            c = cur[1]
            
            for d in range(4):
                r2 = r + rDelta[d]
                c2 = c + cDelta[d]
                
                if 0 <= r2 < N and 0 <= c2 < N:
                    reqT = max(best[r][c], grid[r2][c2])
                    if best[r2][c2] > reqT:
                        best[r2][c2] = reqT
                        q.append([r2,c2])
    
        return best[N-1][N-1]
        