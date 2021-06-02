public class Solution {
    public int MaxProduct(string[] words) {
        int n = words.Length;
        int[] bm = new int[n];
        for (int i = 0; i < n; i++) {
            foreach (char c in words[i]) {
                int ci = (int) c-'a';
                bm[i] = bm[i] | (1 << ci);
            }
        }
        
        int max = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i+1; j < n; j++) {
                int len = (words[i].Length * words[j].Length);
                if (max >= len) {
                    continue;
                }
                
                bool pass = true;
                for (int ci = 0; ci < 26; ci++) {
                    if ( (bm[i] & (1 << ci)) > 0 && (bm[j] & (1 << ci)) > 0 ) {
                        pass = false;
                        break;
                    }
                }
                if (pass) {
                    max = len;
                }
            }
        }
        
        return max;
    }
}