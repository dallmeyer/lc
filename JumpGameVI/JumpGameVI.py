class Solution:
    def maxResult(self, nums: List[int], k: int) -> int:
        n = len(nums)
        last = dict()
        heap = []
        heapq.heapify(heap)
        
        best = -1
        
        for i in reversed(range(n)):
            if i == n-1:
                best = nums[i]
            else:
                best = nums[i] + (-1*heap[0])
            
            last[best] = i
            heapq.heappush(heap, -1 * best)
            
            # check max values and pop them if their last appearance was >k moves ago
            while last[-1*heap[0]] - i >= k:
                heapq.heappop(heap)
            
            
        return best