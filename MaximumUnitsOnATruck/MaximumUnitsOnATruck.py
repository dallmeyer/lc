class Solution:
    def maximumUnits(self, boxTypes: List[List[int]], truckSize: int) -> int:
        boxTypes.sort(key=lambda x: (-x[1]))
        
        ans = 0
        
        for boxType in boxTypes:
            if truckSize == 0:
                break
                
            use = min(truckSize, boxType[0])
            truckSize -= use
            ans += (boxType[1]*use)
        
        return ans