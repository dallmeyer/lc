public class Solution {
    public string RemoveDuplicates(string s) {
        Stack<char> stk = new Stack<char>();
        foreach (char c in s) {
            if (stk.Any() == false || stk.Peek() != c) {
                stk.Push(c);
            } else {
                stk.Pop();
            }
        }
        
        string ans = "";
        while (stk.Any()) {
            ans = stk.Pop() + ans;
        }
        
        return ans;
    }
}