public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> s = new Stack<int>();
        
        foreach (string t in tokens) {
            if (t == "+") {
                int b = s.Pop();
                int a = s.Pop();
                s.Push(a+b);
            } else if (t == "-") {
                int b = s.Pop();
                int a = s.Pop();
                s.Push(a-b);                
            } else if (t == "*") {
                int b = s.Pop();
                int a = s.Pop();
                s.Push(a*b);                
            } else if (t == "/") {
                int b = s.Pop();
                int a = s.Pop();
                s.Push(a/b);                
            } else {
                s.Push(Int32.Parse(t));
            }
        }
        
        return s.Pop();
    }
}