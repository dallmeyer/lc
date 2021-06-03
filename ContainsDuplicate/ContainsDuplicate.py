class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        v = set()
        for x in nums:
            if x in v:
                return True
            v.add(x)
        return False