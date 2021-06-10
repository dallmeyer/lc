public class MyCalendar {
    
    private class Node {
        public int start;
        public int end;
        
        public Node (int s, int e) {
            start = s;
            end = e;
        }
        
        public override String ToString() {
            return start + "-" + end;
        }
    }
    
    private static List<Node> x;
    
    public MyCalendar() {
        x = new List<Node>();
    }
    
    public bool Book(int start, int end) {
        /*Console.WriteLine();
        Console.WriteLine("Before: ");
        foreach (Node n in x) {Console.Write(n + ", ");}
        Console.WriteLine();*/
        
        int i = 0;
        for ( ; i < x.Count; i++) {
            if (x[i].start >= end) {break;}  // if we reach an element that is completely after new booking, we're good
            
            if (x[i].end <= start) {continue;}  // if element is completely before new booking, keep checking
            
            return false;
        }
        
        // position i was first time an element came after new booking
        x.Insert(i, new Node(start, end));
        
        /*Console.WriteLine("After: ");
        foreach (Node n in x) {Console.Write(n + ", ");}
        Console.WriteLine();*/
        
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */