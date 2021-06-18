class Solution:
    def stoneGameVI(self, aliceValues: List[int], bobValues: List[int]) -> int:
        n = len(aliceValues)
        
        imp = [[aliceValues[i]+bobValues[i],i] for i in range(n)]
        
        imp.sort(key=lambda x: (-x[0]))  # sort desc by sum of A+B
        
        a = 0
        b = 0
        for j in range(n):
            i = imp[j][1]
            
            if j % 2 == 0:
                a += aliceValues[i]
            else:
                b += bobValues[i]
        
        ans = a-b
        if ans < 0:
            return -1
        if ans > 0:
            return 1
        return 0

        
        