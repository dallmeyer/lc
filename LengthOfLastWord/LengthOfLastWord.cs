public class Solution {
    public int LengthOfLastWord(string s) {
        int count = 0;
        bool space = false;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == ' ') {
                space = true;
                continue;
            }
            
            if (space) {
                count = 0;
                space = false;
            }
            count++;
        }
        
        return count;
    }
}