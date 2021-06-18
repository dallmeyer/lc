public class Solution {
    private static IList<string> ans;
    
    public IList<string> GenerateParenthesis(int n) {
        ans = new List<string>();
        
        gen(0, 0, n, "");
        
        return ans;
    }
    
    private static void gen(int i, int open, int n, string s) {
        if (i == n) {
            // close any open parens
            for (int j = 0; j < open; j++) {
                s += ")";
            }
            
            ans.Add(s);
            return;
        }
        
        if (open > 0) {
            string s2 = s + ")";           
            gen(i, open-1, n, s2);
        }
        
        string s3 = s + "(";
        gen(i+1, open+1, n, s3);
    }
}