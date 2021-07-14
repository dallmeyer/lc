class Solution:
    def kWeakestRows(self, mat: List[List[int]], k: int) -> List[int]:
        heap = []
        heapq.heapify(heap)
        
        m = len(mat)
        n = len(mat[0])
        
        for i in range(m):
            j = 0
            while j < n:
                if mat[i][j] == 0:
                    break
                j += 1
                
            heapq.heappush(heap, [j, i])
            
        ans = []
        for i in range(k):
            ans.append(heapq.heappop(heap)[1])
            
        return ans