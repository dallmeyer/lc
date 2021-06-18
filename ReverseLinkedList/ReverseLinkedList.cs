/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        Stack<ListNode> stk = new Stack<ListNode>();
        while (head != null) {
            stk.Push(head);
            head = head.next;
        }
        
        head = null;
        ListNode cur = null;
        while (stk.Any()) {
            ListNode tmp = stk.Pop();
            
            if (cur == null) {
                head = tmp;
            } else {
                cur.next = tmp;
            }
                
            cur = tmp;
        }
        if (cur != null) {
            cur.next = null;
        }
        
        return head;
    }
}