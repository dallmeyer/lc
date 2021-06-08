class Solution:
    def grayCode(self, n: int) -> List[int]:
        cur = [0, 1]
        
        for i in range(1,n):
            two = (1 << i)
            m = len(cur)
            
            for j in reversed(range(m)):
                cur.append(two+cur[j])
            
        return cur