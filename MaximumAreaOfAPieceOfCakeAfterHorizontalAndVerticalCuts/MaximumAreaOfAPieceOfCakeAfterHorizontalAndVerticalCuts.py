class Solution:
    def maxArea(self, h: int, w: int, horizontalCuts: List[int], verticalCuts: List[int]) -> int:
        horizontalCuts.sort()
        # start with first slice
        maxH = horizontalCuts[0]
        # consider inner slices
        for i in range(1,len(horizontalCuts)):
            d = horizontalCuts[i] - horizontalCuts[i-1]
            if maxH < d:
                maxH = d
        # consider last slice
        d = h - horizontalCuts[len(horizontalCuts)-1]
        if maxH < d:
            maxH = d
        
        verticalCuts.sort()
        # start with first slice
        maxV = verticalCuts[0]
        # consider inner slices
        for i in range(1,len(verticalCuts)):
            d = verticalCuts[i] - verticalCuts[i-1]
            if maxV < d:
                maxV = d
        # consider last slice
        d = w - verticalCuts[len(verticalCuts)-1]
        if maxV < d:
            maxV = d
        
        return (maxH * maxV) % 1000000007
        