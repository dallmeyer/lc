public class BrowserHistory {

    private class HistoryNode {
        public string url;
        public HistoryNode prev, next;
        public HistoryNode(string s) {
            url = s;
        }
    }
    
    private HistoryNode cur;
    
    public BrowserHistory(string homepage) {
        cur = new HistoryNode(homepage);
    }
    
    public void Visit(string url) {
        HistoryNode next = new HistoryNode(url);
        cur.next = next;    // may trim previously forward nodes
        next.prev = cur;
        cur = next;
    }
    
    public string Back(int steps) {
        while (steps > 0 && cur.prev != null) {
            cur = cur.prev;
            steps--;
        }
        
        return cur.url;
    }
    
    public string Forward(int steps) {
        while (steps > 0 && cur.next != null) {
            cur = cur.next;
            steps--;
        }
        
        return cur.url;
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */