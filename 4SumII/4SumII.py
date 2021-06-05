class Solution:
    def fourSumCount(self, nums1: List[int], nums2: List[int], nums3: List[int], nums4: List[int]) -> int:
        d12 = dict()
        
        n = len(nums1)
        for i in range(n):
            for j in range(n):
                s12 = nums1[i]+nums2[j]
                
                if s12 not in d12:
                    d12[s12] = 0
                d12[s12] += 1
            
        ans = 0
        for i in range(n):
            for j in range(n):
                need = 0-nums3[i]-nums4[j]
                if need in d12:
                    ans += d12[need]
                
        return ans