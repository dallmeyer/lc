class MedianFinder:    
    def __init__(self):
        self.maxLowerPq = []
        self.minUpperPq = []
        heapq.heapify(self.maxLowerPq)   # negative vals
        heapq.heapify(self.minUpperPq)        

    def addNum(self, num: int) -> None:
        if len(self.maxLowerPq) == 0 or num <= -self.maxLowerPq[0]:
            heapq.heappush(self.maxLowerPq, -num)
            
            if len(self.maxLowerPq) - len(self.minUpperPq) == 2:
                # need to balance
                heapq.heappush(self.minUpperPq, -heapq.heappop(self.maxLowerPq))
        else:
            heapq.heappush(self.minUpperPq, num)
            
            if len(self.minUpperPq) - len(self.maxLowerPq) == 2:
                # need to balance
                heapq.heappush(self.maxLowerPq, -heapq.heappop(self.minUpperPq))
                
        #print(self.maxLowerPq, self.minUpperPq)

    def findMedian(self) -> float:
        d = len(self.maxLowerPq) - len(self.minUpperPq)
        #print(d)
        
        if d < 0:
            return self.minUpperPq[0]
        if d > 0:
            return -self.maxLowerPq[0]
        
        return float(self.minUpperPq[0] - self.maxLowerPq[0]) / 2.0


# Your MedianFinder object will be instantiated and called as such:
# obj = MedianFinder()
# obj.addNum(num)
# param_2 = obj.findMedian()