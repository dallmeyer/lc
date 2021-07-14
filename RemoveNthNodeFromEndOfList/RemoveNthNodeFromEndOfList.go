/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func removeNthFromEnd(head *ListNode, n int) *ListNode {
    turtle := head
    hare := head
    
    for i := 0; i < n; i++ {
        hare = hare.Next
    }
    
    if hare == nil {
        temp := head
        head = temp.Next
        temp.Next = nil
        
        return head
    }
    
    for hare.Next != nil {
        hare = hare.Next
        turtle = turtle.Next
    }
    
    if turtle.Next == head {
        // just trim head/turtle
        head = head.Next
        turtle.Next = nil
        
        return head
    }
    
    temp := turtle.Next
    turtle.Next = temp.Next
    temp.Next = nil
    
    return head
}