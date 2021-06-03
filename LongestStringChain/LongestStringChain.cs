public class Solution {
    private static int StringCompareLen(string a, string b) {
        return a.Length - b.Length;
    }
    
    public int LongestStrChain(string[] words) {
        Dictionary<string, int> a = new Dictionary<string, int>();
        
        foreach (string w in words) {   // O(1000)
            a[w] = 1;
        }
        
        Array.Sort(words, StringCompareLen);   // O(1000 log(1000))
        
        int max = 1;
        foreach (string w in words) {   // O(1000)
            for (int i = 0; i < w.Length; i++) {    // O(16)
                string s = w.Substring(0, i) + w.Substring(i+1);
                if (a.ContainsKey(s)) {
                    a[w] = a[s]+1;
                    if (max < a[w]) {
                        max = a[w];
                    }
                }
            }
        }
        
        return max;
    }
}