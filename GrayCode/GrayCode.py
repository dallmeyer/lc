class Solution:
    def grayCode(self, n: int) -> List[int]:
        prev = [0, 1]
        
        for i in range(1,n):
            two = (1 << i)
            m = len(prev)
            
            cur = []
            for j in range(0,m):
                cur.append(prev[j])
            
            for j in reversed(range(m)):
                cur.append(two+prev[j])
                
            prev = cur
            
        return prev