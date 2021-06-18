class Solution:
    def nearestValidPoint(self, x: int, y: int, points: List[List[int]]) -> int:
        minD = -1
        minIdx = -1
        
        n = len(points)
        
        for i in range(n):
            
            if points[i][0] == x:
                d = abs(y - points[i][1])
                if minD == -1 or minD > d:
                    minD = d
                    minIdx = i
            elif points[i][1] == y:
                d = abs(x - points[i][0])
                if minD == -1 or minD > d:
                    minD = d
                    minIdx = i
                    
        return minIdx