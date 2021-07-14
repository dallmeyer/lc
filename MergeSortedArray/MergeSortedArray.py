class Solution:
    def merge(self, nums1: List[int], m: int, nums2: List[int], n: int) -> None:
        """
        Do not return anything, modify nums1 in-place instead.
        """
        mn = m+n-1
        m = m-1
        n = n-1
        while mn >= 0:
            if m < 0 or (n >= 0 and nums1[m] < nums2[n]):
                nums1[mn] = nums2[n]
                mn -= 1
                n -= 1
            else:
                nums1[mn] = nums1[m]
                mn -= 1
                m -= 1
                