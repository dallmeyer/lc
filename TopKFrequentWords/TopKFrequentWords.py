class Solution:
    def topKFrequent(self, words: List[str], k: int) -> List[str]:
        count = dict()
        
        for x in words:
            if x not in count:
                count[x] = 0
            count[x] += 1
            
        heap = []
        heapq.heapify(heap)
        
        for x in count:
            heapq.heappush(heap, [-count[x], x])
            
        ans = []
        for i in range(k):
            ans.append(heapq.heappop(heap)[1])
            
        return ans