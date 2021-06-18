class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        count = dict()
        
        for x in nums:
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