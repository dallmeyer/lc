class Solution:
    def intersect(self, nums1: List[int], nums2: List[int]) -> List[int]:
        d1 = dict()
        d2 = dict()
        
        for x in nums1:
            if x not in d1:
                d1[x] = 0
            d1[x] += 1
            
        for x in nums2:
            if x not in d2:
                d2[x] = 0
            d2[x] += 1
            
        if len(d1) > len(d2):
            tmp = d1
            d1 = d2
            d2 = tmp
            
        # len(d1) <= len(d2)
        
        ans = []
        for x in d1:
            if x in d2:
                count = d1[x] if d1[x] < d2[x] else d2[x]
                for i in range(count):
                    ans.append(x)
                    
        return ans