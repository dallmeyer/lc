class Solution:
    def minSetSize(self, arr: List[int]) -> int:
        d = dict()
        
        for x in arr:
            if x not in d:
                d[x] = 0
                
            d[x] += 1
            
        # sort counts descending
        counts = sorted(d.items(), key=lambda x: x[1], reverse=True)
        
        # greedily remove most common elements
        k = len(arr)/2
        ans = 0
        while k > 0:
            k -= (counts.pop(0)[1])
            ans += 1
        
        return ans