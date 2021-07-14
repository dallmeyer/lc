# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def mergeTwoLists(self, l1: ListNode, l2: ListNode) -> ListNode:
        if l1 is None:
            return l2
        if l2 is None:
            return l1
        
        head = None
        cur = None
        
        while l1 is not None and l2 is not None:
            if l1.val < l2.val:
                if cur is None:
                    head = l1
                    cur = l1
                else:
                    cur.next = l1
                    cur = l1
                
                l1 = l1.next
            else:
                if cur is None:
                    head = l2
                    cur = l2
                else:
                    cur.next = l2
                    cur = l2
                
                l2 = l2.next
                
        if l1 is not None:
            cur.next = l1
        elif l2 is not None:
            cur.next = l2
            
        return head
                
                
            