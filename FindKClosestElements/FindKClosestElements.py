class Solution:
    def findClosestElements(self, arr: List[int], k: int, x: int) -> List[int]:
        heap = []
        heapq.heapify(heap)
        
        for y in arr: #O(n...)
            e = [-abs(x-y), -y] #sort by distance descending (so we pop largest distances), then by value descending (so we pop larger values first if distance is a tie)
            heapq.heappush(heap, e) #O(n log k)
            if len(heap) > k:
                heapq.heappop(heap) #O(n log k)
                
        ans = []
        for e in heap:  # O(k)
            ans.append(-e[1])
            
        ans.sort() # O(k log k)
        return ans