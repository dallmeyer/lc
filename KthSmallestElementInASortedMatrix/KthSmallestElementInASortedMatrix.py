class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        n = len(matrix)
        
        pos = []
        heap = []
        heapq.heapify(heap)
        
        for i in range(n):
            pos.append(0)
            heapq.heappush(heap, [matrix[i][0], i])
        
        while True:
            tmp = heapq.heappop(heap)
            k -= 1
            if k == 0:
                return tmp[0]
            
            i = tmp[1]
            pos[i] += 1
            
            if pos[i] < n:
                heapq.heappush(heap, [matrix[i][pos[i]], i])    
        
        return 0