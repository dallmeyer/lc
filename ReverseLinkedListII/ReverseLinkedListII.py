# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def reverseBetween(self, head: ListNode, left: int, right: int) -> ListNode:
        stk = []
        revHead = None
        cur = head
        i = 1
        while i < left:
            revHead = cur
            cur = cur.next
            i += 1
        
        '''if revHead is None:
            print("revHead: None")
        else:
            print("revHead:", revHead.val)
        
        if cur is None:
            print("cur: None")
        else:
            print("cur:", cur.val)'''
        
        # revHead is the last element before section to be reversed (possibly None if reversing head), needs to be re-joined at end
        # cur is first element to be reversed, i == left at this point
        
        # build stack to reverse
        while i <= right:
            stk.append(cur)
            cur = cur.next
            i += 1
           
        '''if cur is None:
            print("cur: None")
        else:
            print("cur:", cur.val)'''
        
        # cur is first element after section to be reversed, needs to be re-joined at end
        
        # pop stack for reversal
        while len(stk) > 0:
            tmp = stk.pop()
            if revHead is None: #reversal includes original head
                head = tmp
                revHead = tmp
            else:
                revHead.next = tmp
                revHead = tmp
                
        if cur is None:
            revHead.next = None
        else:
            revHead.next = cur
            
        return head