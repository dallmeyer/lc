# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def isPalindrome(self, head: ListNode) -> bool:
        slow = head
        fast = head
        
        while fast is not None and fast.next is not None:
            slow = slow.next
            fast = fast.next.next
            
        if fast is None:
            # even
            slow = slow
        else:
            # odd
            slow = slow.next
        
        prv = None
        nxt = None
        while slow is not None:
            nxt = slow.next
            slow.next = prv
            prv = slow
            slow = nxt
            
        while prv is not None:
            if prv.val != head.val:
                return False
            prv = prv.next
            head = head.next
            
        return True
        