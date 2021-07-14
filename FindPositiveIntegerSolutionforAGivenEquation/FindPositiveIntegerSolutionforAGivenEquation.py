"""
   This is the custom function interface.
   You should not implement it, or speculate about its implementation
   class CustomFunction:
       # Returns f(x, y) for any given positive integers x and y.
       # Note that f(x, y) is increasing with respect to both x and y.
       # i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
       def f(self, x, y):
  
"""

class Solution:
    def findSolution(self, customfunction: 'CustomFunction', z: int) -> List[List[int]]:
        ans = []
        
        # find x bound when y = 1
        y = 1
        lo = z
        
        while lo > 0 and y <= z:
            #print(lo, y,  customfunction.f(lo, y))
            
            while lo-1 > 0 and customfunction.f(lo-1, y) >= z:
                lo -= 1
                #print("moved lo", lo, y, customfunction.f(lo, y), customfunction.f(lo, y), customfunction.f(lo, y), z)
                
            if customfunction.f(lo, y) == z:
                ans.append([lo, y])
                #print("added", lo, y,  customfunction.f(lo, y))
                lo -= 1
                
            y += 1
            #print("moved y", lo, y,  customfunction.f(lo, y))
                
                
        return ans