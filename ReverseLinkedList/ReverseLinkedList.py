# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def reverseList(self, head: ListNode) -> ListNode:
        stk = []
        while head is not None:
            stk.append(head)
            head = head.next
            
        head = None
        cur = None
        while len(stk) > 0:
            tmp = stk.pop()
            
            if cur is None:
                cur = tmp
                head = tmp
            else:
                cur.next = tmp
                cur = cur.next
                
        if cur is not None:
            cur.next = None
        
        return head