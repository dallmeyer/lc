public class Solution {
    private class CircleNode {
        public int i;
        public CircleNode next;
        
        public CircleNode(int i) {
            this.i = i;
        }
    }
    
    public int FindTheWinner(int n, int k) {
        // setup circle list
        CircleNode head = new CircleNode(1);
        CircleNode cur = head;
        for (int i = 2; i <= n; i++) {
            cur.next = new CircleNode(i);
            cur = cur.next;
        }
        cur.next = head;
        
        CircleNode prev = cur;
        cur = head;
        while(cur.next != cur) {
            for (int i = 0; i < k-1; i++) {
                // k-1 since node itself should be counted towards k
                prev = prev.next;   //prev = cur;
                cur = cur.next;
            }
            
            // remove cur
            prev.next = cur.next;
            cur = cur.next;
        }
        
        return cur.i;
    }
}