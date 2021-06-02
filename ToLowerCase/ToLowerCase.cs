public class Solution {
    public string ToLowerCase(string s) {
        char[] cc = s.ToCharArray();
        int d = (int) 'a' - 'A';
        
        for (int i = 0; i < cc.Length; i++) {
            char c = cc[i];
            if ('A' <= c && c <= 'Z') {
                cc[i] = (char) ((int) c + d);
            }
        }
        
        return new string(cc);
    }
}