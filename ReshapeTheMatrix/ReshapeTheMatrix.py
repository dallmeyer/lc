class Solution:
    def matrixReshape(self, mat: List[List[int]], r: int, c: int) -> List[List[int]]:
        m = len(mat)
        n = len(mat[0])
        
        if m*n/r != c:
            return mat
        
        ans = [[None for j in range(c)] for i in range(r)]
        
        i = 0
        j = 0
        ii = 0
        jj = 0
        
        while i < m and j < n:
            ans[ii][jj] = mat[i][j]
            
            j += 1
            if j == n:
                j = 0
                i += 1
            
            jj += 1
            if jj == c:
                jj = 0
                ii += 1
                
        return ans