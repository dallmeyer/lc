class Solution:
    def kClosest(self, points: List[List[int]], k: int) -> List[List[int]]:
        n = len(points)
        
        distSq = []
        for x in points:
            distSq.append(x[0]*x[0] + x[1]*x[1])
            
        heap = []
        heapq.heapify(heap)
        
        for i in range(n):
            heapq.heappush(heap, [distSq[i], points[i]])
            
        ans = []
        for i in range(k):
            ans.append(heapq.heappop(heap)[1])
            
        return ans